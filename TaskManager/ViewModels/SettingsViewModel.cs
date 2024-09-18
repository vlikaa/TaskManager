using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

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
	
	[ObservableProperty] private bool _isDarkTheme = true;
	[ObservableProperty] private bool _isLightTheme;
}