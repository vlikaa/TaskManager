using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using TaskManager.Models;
using TaskManager.Services;
using TaskManager.SystemFunctions;
using Timer = System.Threading.Timer;

namespace TaskManager.ViewModels;

[INotifyPropertyChanged]
public partial class DetailsViewModel : BaseViewModel
{
	
	private Timer _timer;


	public DetailsViewModel()
	{
		
		// _timer = new Timer(OnTimerElapsed, null, 0, 1000);
		//
		UpdateProcesses();
	}

	private void OnTimerElapsed(object? state)
	{
		UpdateProcesses();
	}

	private void UpdateProcesses()
	{
		var processes = Process.GetProcesses();
		
		Application.Current.Dispatcher.Invoke(() =>
		{
			Processes.Clear();
			
			foreach (var process in processes)
			{
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
		});
	}

	[ObservableProperty] private ProcessInfo? _selectedProcess = null;
	[ObservableProperty] private ObservableCollection<ProcessInfo> _processes = [];
}