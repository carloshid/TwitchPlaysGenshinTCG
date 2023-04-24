using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Windows.Input;
using System.Windows.Interop;


namespace TwitchPlaysGenshinTCG
{
    /// <summary>
    /// Interaction logic for Overlay.xaml
    /// </summary>
    public partial class Overlay : Window
    {
        const int WS_EX_TRANSPARENT = 0x00000020;
        const int GWL_EXSTYLE = (-20);

        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hwnd, int index);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);

        public static void SetWindowExTransparent(IntPtr hwnd)
        {
            var extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
            SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle | WS_EX_TRANSPARENT);
        }

        public static void SetWindowExNotTransparent(IntPtr hwnd)
        {
            var extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
            SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle & ~WS_EX_TRANSPARENT);
        }

        public Overlay()
        {
            InitializeComponent();

            this.WindowState = WindowState.Maximized;
            this.WindowStyle = WindowStyle.None;
            this.Topmost = true;
            this.IsHitTestVisible = false;


        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            // Make overlay and everything in it transparent to the mouse
            var windowHwnd = new WindowInteropHelper(this).Handle;
            SetWindowExTransparent(windowHwnd);

            // To make specific elements not transparent to the mouse, use the following for each element
            // var hwndSource = (HwndSource)HwndSource.FromVisual(element);
            // var hwnd = hwndSource.Handle;
            // SetWindowExNotTransparent(hwnd);
        }

        public void addNumberLabel(int x, int y, int n) 
        {
            NumberLabel numberLabel = new NumberLabel(n);
            numberLabel.HorizontalAlignment = HorizontalAlignment.Left;
            numberLabel.VerticalAlignment = VerticalAlignment.Top;
            numberLabel.Margin = new Thickness(x-10, y-10, 0, 0);
            numberLabel.Padding = new Thickness(0, 0, 0, 0);
            this.grid.Children.Add(numberLabel);

        }
    }
}
