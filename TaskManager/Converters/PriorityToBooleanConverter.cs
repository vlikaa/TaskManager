using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;

namespace TaskManager.Converters;

public class PriorityToBooleanConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is not ProcessPriorityClass selectedPriority || parameter is not string menuPriority)
		{
			return false;
		}
		
		return selectedPriority.ToString() == menuPriority;
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		return new object();
		
		// if (value is bool isChecked && isChecked && parameter is string menuPriority)
		// {
		// 	return menuPriority;
		// }
		// return null;
	}
}