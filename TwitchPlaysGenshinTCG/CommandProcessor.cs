using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchPlaysGenshinTCG
{
    internal class CommandProcessor
    {

        public static void processCommand(string command) 
        {
            string[] split = command.ToLower().Split(" ");

            if (split[0].Equals("card"))
            {
                // Call method for using card
            }

            else if (split[0].Equals("skill")) 
            { 
                // Call method for using elemental skill
            }

            else if (split[0].Equals("burst"))
            {
                // Call method for using elemental burst
            }

            else if (split[0].Equals("attack"))
            {
                // Call method for using normal attack
            }

            else if (split[0].Equals("switch"))
            {
                // Call method for switching character
            }
        }

        


    }
}
