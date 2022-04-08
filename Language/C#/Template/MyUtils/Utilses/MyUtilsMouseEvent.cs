using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace WindowsFormsApp0
{
    public static class MyUtilsMouseEvent
    {
        [Flags]
        public enum MouseEventFlags
        {
            Move = 0x0001,         //表示发生移动
            LeftDown = 0x0002,     //表示按下鼠标左键
            LeftUp = 0x0004,       //表示松开鼠标左键
            RightDown = 0x0008,    //表示按下鼠标右键
            RightUp = 0x0010,      //表示松开鼠标右键
            MiddleDown = 0x0020,   //表示按下鼠标中键
            MiddleUp = 0x0040,     //表示松开鼠标中键
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,
            VirtualDesk = 0x4000,
            Absolute = 0x8000      //表示参数dx、dy含有规范化的绝对坐标。如果不设置此位，参数含有相对数据：相对于上次位置的改动位置。
        }

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out MousePoint lpMousePoint);

        //dwFlags：标志位集，指定点击按钮和鼠标动作的多种情况。此参数里的各位可以是下列值的任何合理组合：     
        //    //M00SEEVENTF_LEFTDOWN并不表示按了一次左键，M00SEEVENTF_LEFTDOWN | M00SEEVENTF_LEFTUP才表示按了一次左键；   
        //dx：指定鼠标沿x轴的绝对位置或者从上次鼠标事件产生以来移动的数量，依赖于MOOSEEVENTF_ABSOLUTE的设置。给出的绝对数据作为鼠标的实际x坐标，给出的相对数据作为移动的mickeys数。一个mickey表示鼠标移动的数量，表明鼠标已经移动。
        //dy：指定鼠标沿y轴的绝对位置或者从上次鼠标事件产生以来移动的数量，依赖于MOOSEEVENTF_ABSOLUTE的设置。给出的绝对数据作为鼠标的实际y坐标，给出的相对数据作为移动的mickeys数。一个mickey表示鼠标移动的数量，表明鼠标已经移动。
        //dwData：如果dwFlags为MOOSEEVENTF_WHEEL，则dwData指定鼠标轮移动的数量。正值表明鼠标轮向前转动，即远离用户的方向；负值表明鼠标轮向后转动，即朝向用户。一个轮击定义为WHEEL_DELTA，即120。   
        //    //如果dwFlags不是MOOSEEVENTF_WHEEL，则dWData应为零。   
        //dwExtralnfo：指定与鼠标事件相关的附加32位值。应用程序调用函数GetMessgeExtrajnfo来获得此附加信息。
        //    //MOOSEEVENTF_WHEEL：在Windows NT中如果鼠标有一个轮，表明鼠标轮被移动。移动的数量由dwData给出。
        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        public static void SetCursorPosition(int x, int y)
        {
            SetCursorPos(x, y);
        }

        public static void SetCursorPosition(MousePoint point)
        {
            SetCursorPos(point.X, point.Y);
        }

        public static MousePoint GetCursorPosition()
        {
            MousePoint currentMousePoint;
            bool gotPoint = GetCursorPos(out currentMousePoint);
            if (!gotPoint)
            {
                currentMousePoint = new MousePoint(0, 0);
            }

            return currentMousePoint;
        }

        public static void MouseEvent(MouseEventFlags value)
        {
            MousePoint position = GetCursorPosition();
            mouse_event((int)value, position.X, position.Y, 0, 0);
        }

        public static void MouseEvent(MouseEventFlags value, Point position)
        {
            mouse_event((int)value, position.X, position.Y, 0, 0);
        }

        public static void MouseEvent(MouseEventFlags value, int X, int Y)
        {
            mouse_event((int)value, X, Y, 0, 0);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MousePoint
        {
            public int X;
            public int Y;

            public MousePoint(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }
}
