using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace TwitchPlaysGenshinTCG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Thread twitchThread;
        private Overlay overlay;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e) 
        {
            twitchThread = new Thread(new ThreadStart(App.StartTwitchClient));
            twitchThread.Start();

            overlay = new Overlay();
            overlay.Show();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            TwitchChatClient.stop = true;

            if (overlay != null) 
            {
                overlay.Close();
            }
        }

        private void Cards(object sender, RoutedEventArgs e)
        {
            int cards = new ScreenScanner().updateCardAmount();
            Debug.WriteLine(cards);
        }
    }
}
