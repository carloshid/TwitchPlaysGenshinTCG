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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TwitchPlaysGenshinTCG
{
    /// <summary>
    /// Interaction logic for NumberLabel.xaml
    /// </summary>
    public partial class NumberLabel : UserControl
    {
        public NumberLabel()
        {
            InitializeComponent();
            this.Width = 36;
            this.Height = 36;
        }

        public NumberLabel(int n)
        {
            InitializeComponent();
            this.Width = 36;
            this.Height = 36;
            Number.Content = n;
        }
    }
}
