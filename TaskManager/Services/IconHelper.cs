using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;

namespace TaskManager.Services;

public class IconHelper
{
	public static BitmapSource ToBitmapSource(Icon? icon)
	{
		if (icon is null)
		{
			throw new ArgumentException("Icon is null!");
		}

		using var memoryStream = new MemoryStream();
		using var bitmap = icon.ToBitmap();
		
		bitmap.Save(memoryStream, ImageFormat.Png);
		memoryStream.Seek(0, SeekOrigin.Begin);

		var bitmapImage = new BitmapImage();
		bitmapImage.BeginInit();
		bitmapImage.StreamSource = memoryStream;
		bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
		bitmapImage.EndInit();

		return bitmapImage;
	}
}