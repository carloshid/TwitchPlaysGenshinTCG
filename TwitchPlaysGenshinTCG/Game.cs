using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchPlaysGenshinTCG
{
    internal class Game
    {
        // TODO : change this
        private static TurnStatus turnStatus = TurnStatus.ChooseCards;

        // Current number of cards
        private static int cardsInHand = 0;

        public static TurnStatus getTurnStatus() 
        {
            return turnStatus;
        }

        public static void setTurnStatus(TurnStatus status)
        {
            turnStatus = status;
        }

        public static int getCardAmount()
        {
            return cardsInHand;
        }




    }

    public enum TurnStatus 
    { 
        Waiting,
        ChooseCards,
        ChooseDice,
        Action,
        SelectCharacter
    }
}
