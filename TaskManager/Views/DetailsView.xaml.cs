using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TaskManager.Views;

public partial class DetailsView
{
	public DetailsView()
	{
		InitializeComponent();
	}
	
	private void DataGrid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
	{
		if (!e.Handled)
		{
			e.Handled = true;
			var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
			{
				RoutedEvent = UIElement.MouseWheelEvent,
				Source = sender
			};
			var parent = ((Control)sender).Parent as UIElement;
			parent?.RaiseEvent(eventArg);
		}
	}
}