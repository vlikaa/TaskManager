using System.Windows;
using TaskManager.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TaskManager.Views;

namespace TaskManager.ViewModels;

[INotifyPropertyChanged]
public partial class MainViewModel : BaseViewModel
{
	private readonly MainView _mainView;
	private readonly ViewModelFactory _factory;

	public MainViewModel(MainView mainView, ViewModelFactory factory)
	{
		_mainView = mainView;
		_factory = factory;
		
		ViewModel = _factory.Create(typeof(DetailsViewModel));
	}
	
	[RelayCommand]
	private void MenuButton()
	{
		ToggleWidth();
	}
	
	[RelayCommand]
	private void DetailsButton()
	{
		ViewModel = _factory.Create(typeof(DetailsViewModel));
		
		IsDetailsActive = true;
		IsSettingsActive = false;
	}
	
	[RelayCommand]
	private void SettingsButton()
	{
		ViewModel = _factory.Create(typeof(SettingsViewModel));

		IsDetailsActive = false;
		IsSettingsActive = true;
	}
	
	[RelayCommand]
	private void MoveWindow()
	{
		_mainView.DragMove();
	}
	
	[RelayCommand]
	private void Minimize()
	{
		_mainView.WindowState = WindowState.Minimized;
	}
    
	[RelayCommand]
	private void ChangeState()
	{
		_mainView.WindowState = _mainView.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
	}
	
	[RelayCommand]
	private void Close()
	{
		_mainView.Close();
	}

	private void ToggleWidth()
	{
		ButtonWidth = ButtonWidth == 50 ? 240 : 50;
	}
	
	[ObservableProperty] private bool _isDetailsActive = true; 
	[ObservableProperty] private bool _isSettingsActive; 
	[ObservableProperty] private int _buttonWidth = 50; 
	[ObservableProperty] private BaseViewModel _viewModel;
}