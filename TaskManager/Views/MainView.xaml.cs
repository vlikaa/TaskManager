using System.Windows;

namespace TaskManager.Views;

public partial class MainView
{
	public MainView()
	{
		InitializeComponent();

		// double test = 50;
		// Button.Width = test;
	}
	
	private double _correctWidth = 50;

	private void CustomButton_OnClick(object sender, RoutedEventArgs e)
	{
		_correctWidth = _correctWidth == 50 ? 240 : 50;
		
		DetailsButton.Width = _correctWidth;
		SettingsButton.Width = _correctWidth;
	}
}