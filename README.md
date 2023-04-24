# Twitch Plays Genshin TCG

## How to use:

1. Change [username] and [token] in the App.config file to the username and oauth token of a Twitch account that will read the message from chat
2. Change [channel] in the App.config file to the username of the Twitch account from which to read the messages
3. Copy the App.config from the base directory to the TwitchPlaysGenshinTCG directory
4. Build the project and run the created executable or run it directly from an IDE
5. Click the "Start" button
6. Type the corresponding commands in chat while the game is open

## Supported commands:

| Command           | Action                                        |
| ----------------- | --------------------------------------------- |
| !card [n]         | Plays the n-th card in hand                   |
| !skill            | Uses the active character's elemental skill   |
| !burst            | Uses the active character's elemental burst   |
| !attack           | Uses the active character's normal attack     |
| !swap [n]         | Swaps to the n-th character                   |
| !concede          | Concedes the match                            |
| !end              | Ends the current turn                         |
| !tune [n]         | Elemental tune using the n-th card            |

Additional, when selecting cards or dice to reroll, use ! follewed by numbers from 1 to 8 which correspond to the ones to reroll, or !none:
Ex:
!4	-	rerolls the 4th card or dice
!1 3 7	-	rerolls the 1st, 3rd and 7th cards or dice
!none	-	keeps all the cards or dice