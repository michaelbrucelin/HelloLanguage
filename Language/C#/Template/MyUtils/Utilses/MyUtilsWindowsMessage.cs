using System;
using System.Runtime.InteropServices;
using System.Text;

namespace WindowsFormsApp0
{
    public static class MyUtilsWindowsMessage
    {
        //USB插拔的消息id
        public const int WM_DEVICECHANGE = 0x0219;
        //左键单击的消息id
        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_COPYDATA = 0x004A;

        //自定义的结构
        public struct My_lParam
        {
            public int i;
            public string s;
        }

        //使用COPYDATASTRUCT来传递字符串
        [StructLayout(LayoutKind.Sequential)]
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }

        //消息发送API，参数：信息发往的窗口的句柄、消息ID、参数1、参数2
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        //消息发送API，参数：信息发往的窗口的句柄、消息ID、参数1、参数2
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, ref My_lParam lParam);

        //消息发送API，参数：信息发往的窗口的句柄、消息ID、参数1、参数2
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, ref COPYDATASTRUCT lParam);

        //异步消息发送API，参数：信息发往的窗口的句柄、消息ID、参数1、参数2
        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        public static extern int PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        //异步消息发送API，参数：信息发往的窗口的句柄、消息ID、参数1、参数2
        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        public static extern int PostMessage(IntPtr hWnd, int Msg, int wParam, ref My_lParam lParam);

        //异步消息发送API，参数：信息发往的窗口的句柄、消息ID、参数1、参数2
        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        public static extern int PostMessage(IntPtr hWnd, int Msg, int wParam, ref COPYDATASTRUCT lParam);

        public static int SendMessage(IntPtr handle, string message, Encoding encoding)
        {
            byte[] bytes = encoding.GetBytes(message);
            COPYDATASTRUCT cds;
            cds.dwData = (IntPtr)100;
            cds.lpData = message;
            cds.cbData = bytes.Length + 1;

            return SendMessage(handle, WM_COPYDATA, 0, ref cds);
        }

        public static int SendMessage(IntPtr handle, string message)
        {
            return SendMessage(handle, message, Encoding.Default);
        }
    }
}
