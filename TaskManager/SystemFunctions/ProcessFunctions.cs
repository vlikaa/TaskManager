using System.Runtime.InteropServices;
using TaskManager.Enums;

namespace TaskManager.SystemFunctions;

public static class ProcessFunctions
{
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

	public static Status GetProcessStatus(int processId)
	{
		IntPtr processHandle = OpenProcess(0x0400 | 0x0010, false, processId);
		
		if (processHandle == IntPtr.Zero)
			return Status.Running;

		int status = NtQueryInformationProcess(processHandle, ProcessBasicInformation, out _, (uint)Marshal.SizeOf(typeof(PROCESS_BASIC_INFORMATION)), IntPtr.Zero);

		CloseHandle(processHandle);

		return status == 0 ? Status.Suspended : Status.Running; 
	}

}