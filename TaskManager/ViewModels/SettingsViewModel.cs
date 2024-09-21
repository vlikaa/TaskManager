using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using TaskManager.Enums;
using TaskManager.Messages;

namespace TaskManager.ViewModels;

[INotifyPropertyChanged]
public partial class SettingsViewModel : BaseViewModel
{
	[RelayCommand]
	private void ChangeTheme(string theme)
	{
		var newTheme = new ResourceDictionary
		{
			Source = theme switch
			{
				"Light" => new Uri("pack://application:,,,/Themes/LightTheme.xaml"),
				"Dark" => new Uri("pack://application:,,,/Themes/DarkTheme.xaml"),
				_ => new Uri("pack://application:,,,/Themes/LightTheme.xaml")
			}
		};

		switch (theme)
		{
			case "Light":
				newTheme.Source = new Uri("pack://application:,,,/Themes/LightTheme.xaml");
				IsLightTheme = true;
				IsDarkTheme = false;
				break;
			case "Dark":
				newTheme.Source = new Uri("pack://application:,,,/Themes/DarkTheme.xaml");
				IsDarkTheme = true;
				IsLightTheme = false;
				break;
		}

		Application.Current.Resources.MergedDictionaries.RemoveAt(1);
		Application.Current.Resources.MergedDictionaries.Add(newTheme);
	}
	
	
	[RelayCommand]
	private void ChangeInterval(string intervalName)
	{
		if (!Enum.TryParse(intervalName, out IntervalType intervalType))
		{
			return;
		}
		
		CurrentInterval = intervalType;
			
		var interval = intervalType switch
		{
			IntervalType.High => 500,
			IntervalType.Normal => 1000,
			IntervalType.Low => 5000,
			_ => 0
		};

		WeakReferenceMessenger.Default.Send(
			new ChangeIntervalMessage(interval));
	}
	
	[ObservableProperty] private bool _isDarkTheme = true;
	[ObservableProperty] private bool _isLightTheme;
	
	[ObservableProperty] private IntervalType _currentInterval = IntervalType.Normal;
}