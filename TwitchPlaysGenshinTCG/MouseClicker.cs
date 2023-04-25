using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;

namespace TwitchPlaysGenshinTCG
{
    // Class for handling clicking on the screen
    internal class MouseClicker
    {

        private static Random rand = new Random(); // Used to generate random values for the sleeping times

        public static void LeftClick(int x, int y) 
        {
            MouseOperations.SetCursorPosition(x, y);    // Move cursor
            Thread.Sleep(rand.Next(400, 600)); // Sleep for 0.4-0.6 seconds
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);   // Click
            Thread.Sleep(rand.Next(20, 30)); // Sleep for 20-30 ms
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp); // Release mouse
        }
    }
}
