using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TaskManager.Models;
using TaskManager.Services;
using TaskManager.SystemFunctions;
using Timer = System.Timers.Timer;

namespace TaskManager.ViewModels;

[INotifyPropertyChanged]
public partial class DetailsViewModel : BaseViewModel
{
	public DetailsViewModel()
	{
		UpdateProcesses();
		
		var timer = new Timer
		{
			Interval = _interval,
			Enabled = true
		};

		timer.Elapsed += (_, _) =>
		{
			UpdateProcesses();
		};

		if (Application.Current.MainWindow == null)
		{
			return;
		}
		
		Keyboard.AddKeyDownHandler(Application.Current.MainWindow, OnKeyDown);
		Keyboard.AddKeyUpHandler(Application.Current.MainWindow, OnKeyUp);
	}

	[RelayCommand]
	private void StartNewTask()
	{
		Process.Start("explorer.exe", "shell:::{2559a1f3-21d7-11d4-bdaf-00c04f60b9f0}");
	}

	[RelayCommand]
	private void EndTask()
	{
		if (SelectedProcess is null)
		{
			return;
		}

		try
		{
			var process = Process.GetProcessById(SelectedProcess.Id);
			
			process.Kill();
		}
		catch (Exception)
		{
			// ignored
		}
	}

	private void UpdateProcesses()
	{
		if (!_updateEvent.IsSet)
		{
			return;
		}
		
		var processes = Process.GetProcesses();
		Application.Current.Dispatcher.Invoke(() =>
		{
			foreach (var process in processes)
			{
				var value = Processes.FirstOrDefault(p => p.Id == process.Id);

				if (value is not null)
				{
					value.Memory = process.WorkingSet64 / 1024;

					continue;
				}

				Processes.Add(new ProcessInfo
				{
					Icon = IconHelper.GetProcessIcon(process.Id),
					Name = process.ProcessName,
					Id = process.Id,
					Status = ProcessFunctions.GetProcessStatus(process.Id),
					// UserName = ProcessFunctions.GetProcessUser(process),
					// Cpu = ProcessFunctions.GetProcessInstanceName(process.Id),
					Memory = process.WorkingSet64 / 1024,
					Architecture = ProcessFunctions.GetProcessArchitecture(process.Id)
				});
			}

			var processIds = processes.Select(p => p.Id);
			var processesToRemove = Processes.Where(p => !processIds.Contains(p.Id));

			foreach (var process in processesToRemove)
			{
				Processes.Remove(process);
			}
		});
	}
	
	private void OnKeyDown(object sender, KeyEventArgs e)
	{
		if (e.Key != Key.LeftCtrl && e.Key != Key.RightCtrl) return;

		_updateEvent.Reset();
	}

	private void OnKeyUp(object sender, KeyEventArgs e)
	{
		if (e.Key != Key.LeftCtrl && e.Key != Key.RightCtrl) return;
		
		_updateEvent.Set();
	}
	
	private double _interval = 1000;
	private readonly ManualResetEventSlim _updateEvent = new(true);
	[ObservableProperty] private ProcessInfo? _selectedProcess;
	[ObservableProperty] private ObservableCollection<ProcessInfo> _processes = [];
}