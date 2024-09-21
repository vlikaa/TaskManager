using System.Windows;
using System.Diagnostics;
using TaskManager.Models;
using System.Windows.Input;
using TaskManager.Services;
using CommunityToolkit.Mvvm.Input;
using TaskManager.SystemFunctions;
using Timer = System.Timers.Timer;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using TaskManager.Messages;

namespace TaskManager.ViewModels;

[INotifyPropertyChanged]
public partial class DetailsViewModel : BaseViewModel
{
	public DetailsViewModel()
	{
		UpdateProcesses();
		
		var timer = new Timer
		{
			Interval = 1000,
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
		
		WeakReferenceMessenger.Default.Register<ChangeIntervalMessage>(this,
			(_, message) =>
			{
				if (message.Interval == 0)
				{
					_updateEvent.Reset();
					
					return;
				}
				
				_updateEvent.Set();
				
				timer.Interval = message.Interval;
			});
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
	
	[RelayCommand]
	private void ChangePriority(string priority)
	{
		if (SelectedProcess == null)
		{
			return;
		}
		
		try
		{
			var correctProcess = Process.GetProcessById(SelectedProcess.Id);

			correctProcess.PriorityClass = priority switch
			{
				"RealTime" => ProcessPriorityClass.RealTime,
				"High" => ProcessPriorityClass.High,
				"AboveNormal" => ProcessPriorityClass.AboveNormal,
				"Normal" => ProcessPriorityClass.Normal,
				"BelowNormal" => ProcessPriorityClass.BelowNormal,
				"Idle" => ProcessPriorityClass.Idle,
				_ => correctProcess.PriorityClass
			};
		}
		catch (Exception)
		{
			// ignored
		}
	}

	[RelayCommand]
	private void OpenFileLocation()
	{
		if (SelectedProcess is null)
		{
			return;
		}
		
		try
		{
			var filePath = SelectedProcess.FileName;

			if (string.IsNullOrEmpty(filePath))
			{
				return;
			}
			
			Process.Start("explorer.exe", $"/select,\"{filePath}\"");
		}
		catch
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
					
					try
					{
						value.Priority = process.PriorityClass;
					}
					catch (Win32Exception)
					{
						value.Priority = ProcessPriorityClass.Normal;
					}

					continue;
				}
				
				Processes.Add(new ProcessInfo
				{
					Icon = IconHelper.GetProcessIcon(process.Id),
					Name = process.ProcessName,
					Id = process.Id,
					Status = ProcessHelper.GetProcessStatus(process.Id),
					// UserName = ProcessFunctions.GetProcessUser(process),
					// Cpu = ProcessFunctions.GetProcessInstanceName(process.Id),
					Memory = process.WorkingSet64 / 1024,
					Architecture = ProcessHelper.GetProcessArchitecture(process.Id),
					Priority = ProcessHelper.GetPriority(process.Id),
					FileName = ProcessHelper.GetProcessFileName(process.Id)
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
		if (e.Key != Key.LeftCtrl && e.Key != Key.RightCtrl)
		{
			return;
		}

		_updateEvent.Reset();
	}

	private void OnKeyUp(object sender, KeyEventArgs e)
	{
		if (e.Key != Key.LeftCtrl && e.Key != Key.RightCtrl)
		{
			return;
		}
		
		_updateEvent.Set();
	}
	
	private readonly ManualResetEventSlim _updateEvent = new(true);
	[ObservableProperty] private ProcessInfo? _selectedProcess;
	[ObservableProperty] private ObservableCollection<ProcessInfo> _processes = [];
}