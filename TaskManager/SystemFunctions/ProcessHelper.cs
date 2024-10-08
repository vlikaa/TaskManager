﻿using System.Diagnostics;
using System.Management;
using System.Runtime.InteropServices;
using TaskManager.Enums;

namespace TaskManager.SystemFunctions;

public static class ProcessHelper
{
	[DllImport("kernel32.dll")]
	private static extern bool IsWow64Process(IntPtr processHandle, out bool isWow64);
	
	const int ProcessBasicInformation = 0;

	[StructLayout(LayoutKind.Sequential)]
	struct PROCESS_BASIC_INFORMATION
	{
		public IntPtr Reserved1;
		public IntPtr PebBaseAddress;
		public IntPtr Reserved2_0;
		public IntPtr Reserved2_1;
		public IntPtr UniqueProcessId;
		public IntPtr Reserved3;
	}

	[DllImport("ntdll.dll")]
	static extern int NtQueryInformationProcess(IntPtr processHandle, int processInformationClass, out PROCESS_BASIC_INFORMATION processInformation, uint processInformationLength, IntPtr returnLength);

	[DllImport("kernel32.dll", SetLastError = true)]
	static extern IntPtr OpenProcess(int processAccess, bool bInheritHandle, int processId);

	[DllImport("kernel32.dll", SetLastError = true)]
	static extern bool CloseHandle(IntPtr hObject);

	public static Status GetProcessStatus(int id)
	{
		try
		{
			IntPtr processHandle = OpenProcess(0x0400 | 0x0010, false, id);
		
			if (processHandle == IntPtr.Zero)
				return Status.Running;

			var status = NtQueryInformationProcess(processHandle, ProcessBasicInformation, out _, (uint)Marshal.SizeOf(typeof(PROCESS_BASIC_INFORMATION)), IntPtr.Zero);

			CloseHandle(processHandle);

			return status == 0 ? Status.Suspended : Status.Running; 
		}
		catch
		{
			return Status.Suspended;
		}
	}
	
	public static string GetProcessUser(Process process)
	{
		var query = $"SELECT * FROM Win32_Process WHERE ProcessId = {process.Id}";
		
		using var searcher = new ManagementObjectSearcher(query);
		using var processList = searcher.Get();

		var outParameters = new object[2];
		
		foreach (var o in processList)
		{
			try
			{
				var obj = (ManagementObject)o;
				var result = Convert.ToInt32(obj.InvokeMethod("GetOwner", outParameters));
				if (result == 0)
				{
					return $"{outParameters[1]}\\{outParameters[0]}";
				}
			}
			catch
			{
				return "N/A";
			}
		}

		return "N/A";
	}
	
	public static string GetProcessInstanceName(int id)
	{		Console.WriteLine("HI");

		var processCategory = new PerformanceCounterCategory("Process");
		var instanceNames = processCategory.GetInstanceNames();

		foreach (var instanceName in instanceNames)
		{
			using var counter = new PerformanceCounter("Process", "ID Process", instanceName, true);
			if ((int)counter.RawValue == id)
			{
				return instanceName;
			}
		}

		throw new ArgumentException($"Процесс с ID {id} не найден.");
	}

	public static Architecture GetProcessArchitecture(int id)
	{
		try
		{
		    var process = Process.GetProcessById(id);
		    
			if (IsWow64Process(process.Handle, out var isWow64))
			{
				return isWow64 ? Architecture.X64 : Architecture.X86;
			}

			throw new Exception("Unable to determine process architecture.");
		}
		catch
		{
			return Architecture.X64;
		}
	}

	public static ProcessPriorityClass GetPriority(int id)
	{
		try
		{
			var process = Process.GetProcessById(id);

			return process.PriorityClass;
		}
		catch
		{
			// ignored
		}

		return ProcessPriorityClass.Normal;
	}

	public static string GetProcessFileName(int processId)
	{
		try
		{
			var process = Process.GetProcessById(processId);

			return process.MainModule == null ? string.Empty : process.MainModule.FileName;
		}
		catch
		{
			return string.Empty;
		}
	}
}