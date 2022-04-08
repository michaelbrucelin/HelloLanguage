using System;
using System.Runtime.InteropServices;
using System.Text;

namespace WindowsFormsApp0
{
    public static class MyUtilsWin32
    {
        public const int ErrorSuccess = 0;

        public enum NetJoinStatus
        {
            NetSetupUnknownStatus = 0,
            NetSetupUnjoined,
            NetSetupWorkgroupName,
            NetSetupDomainName
        }
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int NetGetJoinInformation(string server, out IntPtr domain, out NetJoinStatus status);

        [DllImport("Netapi32.dll")]
        public static extern int NetApiBufferFree(IntPtr Buffer);

        //获取操作系统双击的时间间隔
        [DllImport("user32.dll", EntryPoint = "GetDoubleClickTime")]
        public static extern int GetDoubleClickTime();

        //在Winform中打开Console
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AllocConsole();

        //在Winform中释放Console
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FreeConsole();

        //获取文件大小，与Windows操作系统一致的显示
        [DllImport("Shlwapi.dll", CharSet = CharSet.Auto)]
        public static extern long StrFormatKBSize(long fileSize, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder buffer, int bufferSize);
        /// <summary>
        /// Converts a numeric value into a string that represents the number expressed as a size value in bytes, kilobytes, megabytes, or gigabytes, depending on the size.
        /// </summary>
        /// <param name="filelength">The numeric value to be converted.</param>
        /// <returns>the converted string</returns>
        public static string GetHumanReadableFileLength(long filesize)
        {
            StringBuilder sb = new StringBuilder(11);
            StrFormatKBSize(filesize, sb, sb.Capacity);
            return sb.ToString();
        }

        //64?
        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWow64Process([In] IntPtr process, [Out] out bool wow64Process);

        //获取窗体的handle，根据标题或者类名获取窗体的handle
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        //获取窗体的handle
        [DllImport("User32.dll", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpClassName, string lpWindowName);

        //将一个窗体嵌入另一个窗体
        [DllImport("User32.dll", EntryPoint = "SetParent")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        //通过窗体句柄获取进程ID
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);

        //通过进程ID获取进程句柄
        [DllImport("kernel32.dll")]
        public static extern int OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        //根据进程显示窗体
        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;   //最左坐标
            public int Top;    //最上坐标
            public int Right;  //最右坐标
            public int Bottom; //最下坐标
        }

        //获取窗体的大小和位置
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        //根据进程设置窗体位置和尺寸，与SetWindowPos比，功能少一些
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        //根据进程设置窗体位置和尺寸，与MoveWindow比，功能更多一些
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);

        //根据handle获取进程id
        [DllImport("kernel32.dll")]
        public static extern int GetProcessId(IntPtr handle);

        //窗体闪烁，任务栏闪烁
        [DllImport("user32.dll")]
        public static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        [DllImport("user32.dll")]
        public static extern bool FlashWindow(IntPtr handle, bool invert);

        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            public UInt32 cbSize;
            public IntPtr hwnd;
            public UInt32 dwFlags;
            public UInt32 uCount;
            public UInt32 dwTimeOut;
        }

        public const UInt32 FLASHW_STOP = 0x00000000;
        public const UInt32 FLASHW_CAPTION = 0x00000001;
        public const UInt32 FLASHW_TRAY = 0x00000002;
        public const UInt32 FLASHW_ALL = 0x00000003;
        public const UInt32 FLASHW_TIMER = 0x00000004;
        public const UInt32 FLASHW_TIMERNOFG = 0x0000000C;
    }
}
