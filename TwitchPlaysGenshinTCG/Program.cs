using System.Diagnostics;
using System.Configuration;
using System.Runtime.InteropServices;

namespace TwitchPlaysGenshinTCG
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

          
        }

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