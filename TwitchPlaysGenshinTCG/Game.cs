using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchPlaysGenshinTCG
{
    internal class Game
    {
        private static TurnStatus turnStatus = TurnStatus.None;

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

        public static void setCardAmount(int cards) 
        {
            cardsInHand = cards;
        }



    }

    public enum TurnStatus 
    { 
        Waiting,
        ChooseCards,
        ChooseDice,
        Action,
        SelectCharacter,
        None
    }
}
