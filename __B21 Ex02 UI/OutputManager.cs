using System;
using System.Text;
using System.Windows.Forms;
using Ex02_Logic;
namespace Ex02_UI
{
    public class OutputManager
    {
        private static void printMessageToUser(string i_Message, string i_Caption)
        {
            MessageBox.Show(i_Message, i_Caption);
        }
        private static void printQuestionToUser(string i_Message, string i_Caption)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(i_Message, i_Caption, buttons);
            if (result == DialogResult.Yes)
            {
                //
            }
            else
            {
                // Do something  
            }
        }

        public static void PrintGameResult(bool i_IsTieGame, bool i_playerOneWon)
        {
            if (i_IsTieGame)
            {
                printMessageToUser("Game has ended with tie result", "Tie Game");
            }
            else if (i_playerOneWon)
            {
                printMessageToUser("Player 1 wins this round", "Win");
            }
            else
            {
                printMessageToUser("Player 2 wins this round", "Win");
            }
        }

        public static void PrintUserRequestForAnotherRound()
        {
            printQuestionToUser("Do you want to play another round?", "Another round?");
        }


        public static void PrintInvalidSquareError()
        {
            printMessageToUser("The Square you selected is taken, Select a valid Square", "Square taken");
        }

    }
}
