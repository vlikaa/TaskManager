using System.Globalization;
using System.Windows.Data;

namespace TaskManager.Converters;

public class MemoryFormatter : IValueConverter
{
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		return value is not long memoryValue ? "-" : $"{memoryValue:n0} K";
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}