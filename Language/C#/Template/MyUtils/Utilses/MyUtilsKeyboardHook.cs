﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowsFormsApp0
{
    public class MyUtilsKeyboardHook
    {
        // This is the Constructor. This is the code that runs every time you create a new GlobalKeyboardHook object
        public MyUtilsKeyboardHook()
        {
            llkh = new LLKeyboardHook(HookProc);
            // This starts the hook. You can leave this as comment and you have to start it manually (the thing I do in the tutorial, with the button)
            // Or delete the comment mark and your hook will start automatically when your program starts (because a new GlobalKeyboardHook object is created)
            // That's why there are duplicates, because you start it twice! I'm sorry, I haven't noticed this...
            // hook(); <-- Choose!
        }
        ~MyUtilsKeyboardHook()
        {
            UnHook();
        }

        [DllImport("user32.dll")]
        private static extern int CallNextHookEx(IntPtr hhk, int code, int wParam, ref keyBoardHookStruct lParam);
        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, LLKeyboardHook callback, IntPtr hInstance, uint theardID);
        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hInstance);
        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string lpFileName);

        public delegate int LLKeyboardHook(int Code, int wParam, ref keyBoardHookStruct lParam);

        public struct keyBoardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        const int WH_KEYBOARD_LL = 13;
        const int WM_KEYDOWN = 0x0100;
        const int WM_KEYUP = 0x0101;
        const int WM_SYSKEYDOWN = 0x0104;
        const int WM_SYSKEYUP = 0x0105;

        LLKeyboardHook llkh;
        public List<Keys> HookedKeys = new List<Keys>();

        IntPtr HookZero = IntPtr.Zero;

        public event KeyEventHandler KeyDown;
        public event KeyEventHandler KeyUp;

        public void Hook()
        {
            IntPtr hInstance = LoadLibrary("User32");
            HookZero = SetWindowsHookEx(WH_KEYBOARD_LL, llkh, hInstance, 0);
        }

        public void UnHook()
        {
            UnhookWindowsHookEx(HookZero);
        }

        public int HookProc(int Code, int wParam, ref keyBoardHookStruct lParam)
        {
            if (Code >= 0)
            {
                Keys key = (Keys)lParam.vkCode;
                if (HookedKeys.Contains(key))
                {
                    KeyEventArgs kArg = new KeyEventArgs(key);
                    if ((wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) && (KeyDown != null))
                    {
                        KeyDown(this, kArg);
                    }
                    else if ((wParam == WM_KEYUP || wParam == WM_SYSKEYUP) && (KeyUp != null))
                    {
                        KeyUp(this, kArg);
                    }
                    if (kArg.Handled)
                    {
                        return 1;
                    }
                }
            }

            return CallNextHookEx(HookZero, Code, wParam, ref lParam);
        }
    }
}
