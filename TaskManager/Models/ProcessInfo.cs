using System.Runtime.InteropServices;
using System.Windows.Media.Imaging;
using TaskManager.Enums;

namespace TaskManager.Models;

public class ProcessInfo
{
	public BitmapSource? Icon { get; set; }
	public string? Name { get; set; }
	public int Id { get; set; }
	public Status Status { get; set; }
	public string? UserName { get; set; }
	public string Cpu { get; set; }
	public long Memory { get; set; }
	public Architecture Architecture { get; set; }
	public string? Description { get; set; }
}