using System.Text;
using Ex05_Logic;

namespace Ex05_UI
{
    public class Ui
    {
        private readonly GameSettingsForm r_SettingsForm;
        private GameForm m_GameForm;

        public Ui()
        {
            r_SettingsForm = new GameSettingsForm();
        }

        public void RunGame()
        {
            r_SettingsForm.ShowDialog();
            if(r_SettingsForm.StartSelected)
            {
                buildGameFromSettings();
                m_GameForm.ShowDialog();
            }
        }

        private void buildGameFromSettings()
        {
            int userSelectedBoardSize = r_SettingsForm.RowsUpDown;
            int usersChoiceOfGameMode = (int)GameManager.eGameModes.HumanGameMode;
            if (!r_SettingsForm.Player2checkBox)
            {
                usersChoiceOfGameMode = (int)GameManager.eGameModes.ComputerGameMode;
            }

            GameManager game = new GameManager();
            game.InitGame(userSelectedBoardSize, usersChoiceOfGameMode);
            StringBuilder name1 = new StringBuilder(r_SettingsForm.Player1TextBox);
            name1.Append(":");
            StringBuilder name2 = new StringBuilder(r_SettingsForm.Player2TextBox);
            name2.Append(":");
            m_GameForm = new GameForm(name1.ToString(), name2.ToString(), game, usersChoiceOfGameMode);
        }
    }
}
