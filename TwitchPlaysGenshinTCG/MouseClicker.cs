using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace TwitchPlaysGenshinTCG
{
    // Class for handling clicking on the screen
    internal class MouseClicker
    {

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        [StructLayout(LayoutKind.Sequential)]
        struct INPUT
        {
            public uint type;
            public MOUSEINPUT mi;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        const uint MOUSEEVENTF_LEFTUP = 0x0004;

        public static void LeftClick(int x, int y)
        {
            INPUT[] inputs = new INPUT[2];

            inputs[0].type = 0; // input type is mouse
            inputs[0].mi.dx = x * (65535 / 1920);
            inputs[0].mi.dy = y * (65535 / 1080);
            inputs[0].mi.mouseData = 0;
            inputs[0].mi.dwFlags = MOUSEEVENTF_LEFTDOWN;
            inputs[0].mi.time = 0;
            inputs[0].mi.dwExtraInfo = IntPtr.Zero;

            inputs[1].type = 0; // input type is mouse
            inputs[1].mi.dx = x * (65535 / 1920);
            inputs[1].mi.dy = y * (65535 / 1080);
            inputs[1].mi.mouseData = 0;
            inputs[1].mi.dwFlags = MOUSEEVENTF_LEFTUP;
            inputs[1].mi.time = 0;
            inputs[1].mi.dwExtraInfo = IntPtr.Zero;

            SendInput(2, inputs, Marshal.SizeOf(typeof(INPUT)));
        }
    }
}
