using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TwitchPlaysGenshinTCG
{
    internal class GameActions
    {

        private static Random rand = new Random(); // Used to generate random values for the sleeping times

        // Use the current character's elemental skill
        public static void useElementalSkill() {
            MouseClicker.LeftClick(1717, 960); // Click the elemental skill button to select it
            Thread.Sleep(rand.Next(1000, 2000)); // Sleep for 1-2 seconds
            MouseClicker.LeftClick(1717, 960); // Click the elemental skill button again to cast it
        }

        // Use the current character's elemental burst
        public static void useElementalBurst()
        {
            MouseClicker.LeftClick(1825, 960); // Click the elemental burst button to select it
            Thread.Sleep(rand.Next(1000, 2000)); // Sleep for 1-2 seconds
            MouseClicker.LeftClick(1825, 960); // Click the elemental burst button again to cast it
        }

        // Use the current character's normal attack
        public static void useNormalAttack()
        {
            MouseClicker.LeftClick(1610, 960); // Click the elemental burst button to select it
            Thread.Sleep(rand.Next(1000, 2000)); // Sleep for 1-2 seconds
            MouseClicker.LeftClick(1610, 960); // Click the elemental burst button again to cast it
        }

        // End the current round
        public static void endRound()
        {
            MouseClicker.LeftClick(80, 540); // Click the round timer button on the left
            Thread.Sleep(rand.Next(1000, 2000)); // Sleep for 1-2 seconds
            MouseClicker.LeftClick(350, 540); // Click on "End round"
        }

        // Swap characters (swapTo can be 1-3)
        public static void swapCharacter(int swapTo)
        {
            MouseClicker.LeftClick(540 + 210 * swapTo, 780); // Click the character to select it
            Thread.Sleep(rand.Next(1000, 2000)); // Sleep for 1-2 seconds
            MouseClicker.LeftClick(1825, 960); // Click the swap button to select it
            Thread.Sleep(rand.Next(1000, 2000)); // Sleep for 1-2 seconds
            MouseClicker.LeftClick(1825, 960); // Click the swap button again to swap
        }

        // Reroll dice (each dice is 1-8)
        public static void rerollDice(int[] dice)
        {
            int x, y;
            foreach (int number in dice) 
            {
                x = 625 + ((number - 1)/ 2) * 225;
                y = 650 - (number % 2) * 240;
                MouseClicker.LeftClick(x, y); // Click a specific dice
                Thread.Sleep(rand.Next(500, 1000)); // Sleep for 0.5-1 second
            }
            MouseClicker.LeftClick(970, 950); // Click the "Confirm" button
        }

        // Reroll cards (each card is 1-5)
        public static void rerollCards(int[] cards)
        {
            int x;
            int y = 550;
            foreach (int number in cards)
            {
                x = 90 + number * 290;
                MouseClicker.LeftClick(x, y); // Click a specific card
                Thread.Sleep(rand.Next(500, 1000)); // Sleep for 0.5-1 second
            }
            MouseClicker.LeftClick(970, 950); // Click the "Confirm" button
        }

        // Concede
        public static void concede()
        {
            MouseClicker.LeftClick(1867, 48); // Click the settings button (top right)
            Thread.Sleep(rand.Next(1000, 2000)); // Sleep for 1-2 seconds
            MouseClicker.LeftClick(1600, 260); // Click on "Concede"
            Thread.Sleep(rand.Next(1000, 2000)); // Sleep for 1-2 seconds
            MouseClicker.LeftClick(1170, 760); // Click on "Confirm"
        }

        // Select character (1-3)
        public static void selectCharacter(int character)
        {
            MouseClicker.LeftClick(540 + 210 * character, 780); // Click the character to select it
            Thread.Sleep(rand.Next(1000, 2000)); // Sleep for 1-2 seconds
            MouseClicker.LeftClick(540 + 210 * character, 780); // Click the character to confirm
        }

        // Use card (card value between 1 and # of cards in hand)
        public static void useCard(int card)
        {
            // TODO
        }

        // Elemental tuning (card value between 1 and # of cards in hand)
        public static void elementalTuning(int card)
        {
            // TODO
        }

    }
}
