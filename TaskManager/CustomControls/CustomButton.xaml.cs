using System.Windows;
using MaterialDesignThemes.Wpf;

namespace TaskManager.CustomControls;

public partial class CustomButton
{
	public CustomButton()
	{
		InitializeComponent();
		
		DataContext = this;
	}

	public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
		nameof(Icon), typeof(PackIcon), typeof(CustomButton), new PropertyMetadata(default(PackIcon)));
	
	public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
		nameof(Text), typeof(string), typeof(CustomButton), new PropertyMetadata(default(string)));
	
	public PackIcon Icon
	{
		get => (PackIcon)GetValue(IconProperty);
		set => SetValue(IconProperty, value);
	}
	
	public string Text
	{
		get => (string)GetValue(TextProperty);
		set => SetValue(TextProperty, value);
	}
}