using System.Windows.Forms;

namespace Ex02_UI
{
    public class OutputManager
    {
        private static void printMessageToUser(string i_Message, string i_Caption)
        {
            MessageBox.Show(i_Message, i_Caption);
        }

        public static void PrintGameResult(bool i_IsTieGame, string i_WinnerName)
        {
            if (i_IsTieGame)
            {
                printMessageToUser(
                    @"Tie!
Would You like to play another round? ", 
"A Tie!");
            }
            else
            {
                string toPrint = string.Format(
                    @"The Winner is {0} !
Would You like to play another round?", 
i_WinnerName);
                printMessageToUser(toPrint, "A Win!");
            }
        }

        public static bool AskUserForAnotherRound()
        {
            bool selectedYes = false;
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Do you want to play another round?", "Another round?", buttons);
            if (result == DialogResult.Yes)
            {
                selectedYes = true;
            }

            return selectedYes;
        }

        public static void PrintNoNameError()
        {
            printMessageToUser("Please select a player name", "Name Not Selected!");
        }
    }
}
