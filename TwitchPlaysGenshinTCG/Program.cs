using System.Diagnostics;
using System.Configuration;

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
            

            ScreenScanner sc = new ScreenScanner();
           
            double sim = sc.getSimilarity();
            
            Debug.WriteLine(sim);
            

            return;


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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

            while (true) { 
            }
          
        }
    }
}