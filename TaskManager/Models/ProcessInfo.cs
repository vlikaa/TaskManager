using TaskManager.Enums;
using System.Diagnostics;
using System.Windows.Media.Imaging;
using System.Runtime.InteropServices;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TaskManager.Models;

public partial class ProcessInfo : ObservableObject
{
	public BitmapSource? Icon { get; set; }
	[ObservableProperty] private string _name = string.Empty;
	// public string? Name { get; set; }
	public int Id { get; set; }
	public Status Status { get; set; }
	public string? UserName { get; set; }
	public string? Cpu { get; set; }

	[ObservableProperty] private long _memory;
	// public long Memory { get; set; }
	public Architecture Architecture { get; set; }
	public string? Description { get; set; }
	public ProcessPriorityClass Priority { get; set; }
	public string FileName { get; set; } = string.Empty;
}