using System.Windows;
using CommunityToolkit.Mvvm.Input;

namespace TaskManager.ViewModels;

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
				_ => new Uri("pack://application:,,,/Themes/SystemTheme.xaml")
			}
		};

		Application.Current.Resources.MergedDictionaries.Clear();
		Application.Current.Resources.MergedDictionaries.Add(newTheme);
	}
}