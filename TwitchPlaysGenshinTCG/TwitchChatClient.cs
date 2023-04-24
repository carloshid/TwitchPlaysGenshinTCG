using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Diagnostics;

namespace TwitchPlaysGenshinTCG
{
    internal class TwitchChatClient
    {
        private string name;
        private string token;
        public static bool stop = false;

        public TwitchChatClient(String name, String token)
        {
            this.name = name;
            this.token = token;
        }

        public async Task Start(String channelName)
        {
            TcpClient tcpClient = new TcpClient();
            await tcpClient.ConnectAsync("irc.chat.twitch.tv", 6667);

            StreamReader reader = new StreamReader(tcpClient.GetStream());
            StreamWriter writer = new StreamWriter(tcpClient.GetStream()) { NewLine = "\r\n", AutoFlush = true };

            // Authenticate with Twitch's IRC server and join the specified channel
            await writer.WriteLineAsync($"PASS {token}");
            await writer.WriteLineAsync($"NICK {name}");
            writer.WriteLine($"JOIN #{channelName}");
            writer.Flush();

            string message;
            string[] split;
            int messageIndex;
            // Continously read the messages in the chat
            while (!stop)
            {
                message = await reader.ReadLineAsync();
                if (stop) break;
                if (message == null) continue;

                split = message.Split(" ");

                // If pinged by Twitch, send a response
                if (message.StartsWith("PING"))
                {
                    await writer.WriteLineAsync($"PONG {split[1]}");
                }

                // If the message is a message sent by a user, process it
                else if (split.Length > 1 && split[1] == "PRIVMSG")
                {
                    messageIndex = message.IndexOf(':', 1) + 1;
                    message = message.Substring(messageIndex);
                    Debug.WriteLine(message);

                    if (message.StartsWith('!'))
                    {

                    }
                }
            }

            stop = false;

        }

    }

}
