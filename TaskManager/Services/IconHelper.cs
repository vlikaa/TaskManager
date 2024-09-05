using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Media.Imaging;

namespace TaskManager.Services;

public static class IconHelper
{
	public static BitmapSource GetProcessIcon(int processId)
	{
		try
		{
			var process = Process.GetProcessById(processId);
			var filePath = process.MainModule?.FileName;

			ArgumentException.ThrowIfNullOrEmpty(filePath);

			var icon = Icon.ExtractAssociatedIcon(filePath);

			if (icon != null)
			{
				using var iconStream = new MemoryStream();
				var bitmap = new BitmapImage();

				icon.Save(iconStream);
				iconStream.Seek(0, SeekOrigin.Begin);

				bitmap.BeginInit();
				bitmap.StreamSource = iconStream;
				bitmap.CacheOption = BitmapCacheOption.OnLoad;
				bitmap.EndInit();

				return bitmap;
			}
		}
		catch (Win32Exception) { }

		return GetFallbackImage();
	}
    
	private static BitmapSource GetFallbackImage()
	{
		var fallbackImagePath = "Images\\default icon.png";

		if (!File.Exists(fallbackImagePath)) return new BitmapImage();
		
		var bitmap = new BitmapImage();
		bitmap.BeginInit();
		bitmap.UriSource = new Uri(fallbackImagePath, UriKind.RelativeOrAbsolute);
		bitmap.CacheOption = BitmapCacheOption.OnLoad;
		bitmap.EndInit();

		return bitmap;
	}
}