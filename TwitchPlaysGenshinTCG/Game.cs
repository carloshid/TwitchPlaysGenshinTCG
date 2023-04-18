using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchPlaysGenshinTCG
{
    internal class Game
    {
        private static TurnStatus turnStatus;

        // Current number of cards
        private static int cardsInHand = 0;

        public static TurnStatus getTurnStatus() 
        {
            return turnStatus;
        }

        public static int getCardAmount()
        {
            return cardsInHand;
        }




    }

    internal enum TurnStatus 
    { 
        Waiting,
        ChooseCards,
        ChooseDice,
        Action
    }
}
