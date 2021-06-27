using System.Text;
using System.Windows.Forms;

namespace Ex05_UI
{
    public static class OutputManager
    {
        private static void printMessageToUser(string i_Message, string i_Caption)
        {
            MessageBox.Show(i_Message, i_Caption);
        }

        public static bool AskUserForAnotherRound(bool i_IsTieGame, string i_WinnerName)
        {
            bool anotherRound;
            if (i_IsTieGame)
            {
                anotherRound = printGameResult("A Tie!", "Tie!");
            }
            else
            {
                StringBuilder winnerStatment = new StringBuilder("The winner is ");
                winnerStatment.Append(i_WinnerName);
                winnerStatment.Append("!");
                anotherRound = printGameResult(winnerStatment.ToString(), "Win!");
            }

            return anotherRound;
        }

        private static bool printGameResult(string i_Statement, string i_Title)
        {
            bool selectedYes = false;
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            string toPrint = 
                string.Format(
                    @"{0}
Would you like to play another round?",
                    i_Statement);
            DialogResult result = MessageBox.Show(toPrint, i_Title, buttons);
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
