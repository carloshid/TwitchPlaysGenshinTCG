using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchPlaysGenshinTCG
{
    internal class CommandProcessor
    {

        // Commands typed in the chat, not limited to 1 per user for now
        private static Dictionary<string, int> votes = new Dictionary<string, int>();

        private static int[] cardVotes = new int[5];
        private static int[] diceVotes = new int[8];

        // Command is executed when it has at least 2 votes
        private static int threshhold = 1;

        // Current number of cards
        private static int cardsInHand = 0;

        /*
         * Possible commands:
         * "card [#]" ; "skill" ; "burst" ; "attack" ; "swap [#]" ; "concede" ; "end" ; "tune [#]" ; "confirm" ; "cancel"
         * when selecting dice or cards to reroll: numbers separated by space (ex. "1 2 4 7") or "none"
         */
        public static void processCommand(string command) 
        {
            string[] split = command.ToLower().Split(" ");

            if (split[0].Equals("card"))
            {
                int card;
                if (int.TryParse(split[1], out card))
                {
                    if (card <= cardsInHand)
                    {
                        addCommand(split[0] + " " + split[1]);
                    }
                }
            }

            else if (split[0].Equals("skill"))
            {
                // TODO: check if the skill is available to be used
                addCommand(split[0]);
            }

            else if (split[0].Equals("burst"))
            {
                // TODO: check if the burst is available to be used
                addCommand(split[0]);
            }

            else if (split[0].Equals("attack"))
            {
                // TODO: check if the attack is available to be used
                addCommand(split[0]);
            }

            else if (split[0].Equals("swap"))
            {
                int character;
                if (int.TryParse(split[1], out character))
                {
                    if (true) // TODO: check if the character can be swapped to
                    {
                        addCommand(split[0] + " " + split[1]);
                    }
                }
            }

            else if (split[0].Equals("select"))
            {
                int character;
                if (int.TryParse(split[1], out character))
                {
                    if (true) // TODO: check if the character can be swapped to
                    {
                        addCommand(split[0] + " " + split[1]);
                    }
                }
            }

            else if (split[0].Equals("concede"))
            {
                addCommand(split[0]);
            }

            else if (split[0].Equals("end"))
            {
                addCommand(split[0]);
            }

            else if (split[0].Equals("tune"))
            {
                int card;
                if (int.TryParse(split[1], out card))
                {
                    if (card <= cardsInHand)
                    {
                        addCommand(split[0] + " " + split[1]);
                    }
                }
            }

            else {
                int n1;
                int max = 0;
                if (Game.getTurnStatus() == TurnStatus.ChooseCards) 
                {
                    max = 5;
                }
                else if (Game.getTurnStatus() == TurnStatus.ChooseDice)
                {
                    max = 8;
                }
                List<int> numbers = new List<int>();
                if (int.TryParse(split[0], out n1)) 
                {
                    if (n1 <= 0 || n1 > max) 
                    {
                        return;
                    }
                    numbers.Add(n1);
                    for (int i = 1; i < max && i < split.Length; i++) 
                    {
                        int next;
                        if (int.TryParse(split[i], out next))
                        {
                            if (next <= 0 || next > max || numbers.Contains(next)) 
                            {
                                break;
                            }
                            numbers.Add(next);
                        }
                        else 
                        {
                            break;
                        }
                    }

                    if (Game.getTurnStatus() == TurnStatus.ChooseCards)
                    {
                        for (int i = 0; i < numbers.Count; i++) 
                        {
                            int curN = numbers[i];
                            cardVotes[curN - 1] += 1;
                        }

                        // TODO : change this
                        GameActions.rerollCards(numbers.ToArray());
                        Array.Clear(cardVotes, 0, cardVotes.Length);
                    }
                    else if (Game.getTurnStatus() == TurnStatus.ChooseDice)
                    {
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            int curN = numbers[i];
                            diceVotes[curN - 1] += 1;
                        }
                        
                        // TODO : change this
                        GameActions.rerollDice(numbers.ToArray());
                        Array.Clear(diceVotes, 0, diceVotes.Length);
                    }
                }     
            }

        }

        // Updates the threshhold to a different value
        public static void setThreshhold(int threshhold)
        { 
            CommandProcessor.threshhold = threshhold;
        }

        // Updates the number of cards
        public static void setCardsInHand(int cardsInHand)
        {
            CommandProcessor.cardsInHand = cardsInHand;
        }

        // Increments the value corresponding to the specified command by 1
        private static void addCommand(string command) 
        {
            if (votes.ContainsKey(command))
            {
                int curVotes = votes.GetValueOrDefault(command) + 1;
                if (curVotes >= threshhold)
                {
                    votes.Clear();
                    executeCommand(command);
                }
                else
                {
                    votes[command] = curVotes;
                }
            }
            else 
            {
                votes.Add(command, 1);
                if (threshhold == 1) 
                {
                    executeCommand(command);
                }
            }
        }

        private static void executeCommand(string command)
        {
            string[] split = command.ToLower().Split(" ");

            if (split[0].Equals("card"))
            {
                GameActions.useCard(int.Parse(split[1]));
            }

            else if (split[0].Equals("skill"))
            {
                GameActions.useElementalSkill();
            }

            else if (split[0].Equals("burst"))
            {
                GameActions.useElementalBurst();
            }

            else if (split[0].Equals("attack"))
            {
                GameActions.useNormalAttack();
            }

            else if (split[0].Equals("swap"))
            {
                GameActions.swapCharacter(int.Parse(split[1]));
            }

            else if (split[0].Equals("select"))
            {
                GameActions.selectCharacter(int.Parse(split[1]));
            }

            else if (split[0].Equals("concede"))
            {
                GameActions.concede();
            }

            else if (split[0].Equals("end"))
            {
                GameActions.endRound();
            }

            else if (split[0].Equals("tune"))
            {
                GameActions.elementalTuning(int.Parse(split[1]));
            }

            votes.Clear();
        }
    }
}
