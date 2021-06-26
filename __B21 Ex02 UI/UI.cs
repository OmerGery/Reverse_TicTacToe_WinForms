using System;
using System.Text;
using __B21_Ex02_UI;
using Ex02_Logic;

namespace Ex02_UI
{
    public class UI
    {
        
       

        public static bool m_QSelected;
        private GameForm m_GameForm;
        private GameSettingsForm m_SettingsForm;

        public const string k_QuitSymbolOne = "Q";
        public const string k_QuitSymbolTwo = "q";

        public UI()
        {
            m_SettingsForm = new GameSettingsForm();

        }


        public void RunGame()
        {
            m_SettingsForm.ShowDialog();
            if(m_SettingsForm.StartSelected)
            {
                buildGameFromSettings();
                m_GameForm.ShowDialog();
            }
        }


        private void buildGameFromSettings()
        {
            int userSelectedBoardSize = m_SettingsForm.RowsUpDown;
            int usersChoiceOfGameMode = (int)GameManager.eGameModes.HumanGameMode;
            if (!m_SettingsForm.Player2checkBox)
            {
                usersChoiceOfGameMode = (int)GameManager.eGameModes.ComputerGameMode;
            }
            GameManager game = new GameManager();
            game.InitGame(userSelectedBoardSize, usersChoiceOfGameMode);
            StringBuilder name1 = new StringBuilder(m_SettingsForm.Player1TextBox);
            name1.Append(":");
            StringBuilder name2 = new StringBuilder(m_SettingsForm.Player2TextBox);
            name2.Append(":");
            m_GameForm = new GameForm(name1.ToString(),name2.ToString(), game,usersChoiceOfGameMode);
        }
    }
}
