using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TwitchPlaysGenshinTCG
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static async void StartTwitchClient()
        {
            var username = ConfigurationManager.AppSettings["Username"];
            var token = ConfigurationManager.AppSettings["Token"];
            var channel = ConfigurationManager.AppSettings["Channel"];

            if (username == null || token == null || channel == null)
            {
                throw new Exception("Invalid configuration");
            }

            Console.WriteLine("Starting");
            TwitchChatClient client = new TwitchChatClient(username, token);
            await client.Start(channel);
        }
    }
}
