using System;
using System.Text;
using __B21_Ex02_UI;
using Ex02_Logic;

namespace Ex02_UI
{
    public class UI
    {
        
        private GameManager m_Game;

        public static bool m_QSelected;
        private int m_UsersChoiceOfGameMode;
        private int m_UserSelectedBoardSize;
        private GameForm m_GameForm;
        private GameSettingsForm m_SettingsForm;

        public const string k_QuitSymbolOne = "Q";
        public const string k_QuitSymbolTwo = "q";

        public UI()
        {
            m_SettingsForm = new GameSettingsForm();

        }
        public static void CheckForUserWithdraw()
        {
            if (m_QSelected)
            {
                OutputManager.PrintGameOver();
            }
        }
        public void StartOverMenu()
        {
            OutputManager.PrintScoreBoard(m_Game.PlayerOne.WinsCounter, m_Game.PlayerTwo.WinsCounter);
            OutputManager.PrintUserRequestForAnotherRound();
            int continueGame = InputManager.GetValidNumFromUser((int)GameManager.eGameModes.GameModeOptionOne, (int)GameManager.eGameModes.GameModeOptionTwo);
            if (continueGame == (int)GameManager.eGameModes.GameModeOptionOne)
            {
                m_Game.InitGame(m_UserSelectedBoardSize,m_UsersChoiceOfGameMode);
                OutputManager.DrawBoard(m_Game.GameBoard);
                PlayGame();
            }
            else
            {
                OutputManager.PrintGameOver();
            }
        }

        public Board.Square GetHumanMoveDetailsFromUser()
        {
            Board.Square selectedSquare  = new Board.Square();
            bool isSquareTaken = false;     
            do
            {
                OutputManager.PrintInvalidSquareError();
                InputManager.GetSquareFromPlayer(m_UserSelectedBoardSize, ref selectedSquare);
                if(!m_QSelected)
                {
                    isSquareTaken = m_Game.GameBoard.CheckIfSquareTaken(selectedSquare);
                }
            }
            while(isSquareTaken && !m_QSelected) ;
            return selectedSquare;
        }
        public void PlayGame()
        {
            while (m_Game.IsGameActive)
            {
                OutputManager.DrawBoard(m_Game.GameBoard);
                if(m_Game.isHumanTurn())
                {
                    Board.Square userSelectedSquare = GetHumanMoveDetailsFromUser();
                    if(m_QSelected)
                    {
                        OutputManager.PrintGameOver();
                        break;
                    }
                    m_Game.PlayHumanTurn(userSelectedSquare);
                }
                else
                {
                    m_Game.PlayComputerTurn();
                }
                if(m_Game.CheckWinOrTie())
                {
                    OutputManager.DrawBoard(m_Game.GameBoard);
                    m_Game.UpdateEndRoundResult();
                    OutputManager.PrintGameResult(m_Game.IsTieGame, m_Game.PlayerOneWon);
                    StartOverMenu();
                }
            }
        }
        public void RunGame()
        {
            m_SettingsForm.ShowDialog();
            if(m_SettingsForm.StartSelected)
            {
                getDataFromSettingsForm();
                buildGameFromSettings();
                m_GameForm.ShowDialog();
                m_Game = new GameManager();

                CheckForUserWithdraw();

                PlayGame();
                
            }

        }

        private void getDataFromSettingsForm()
        {
            m_UserSelectedBoardSize = m_SettingsForm.RowsUpDown;
            m_UsersChoiceOfGameMode = (int)GameManager.eGameModes.GameModeOptionTwo;
            if (m_SettingsForm.Player2checkBox)
            {
                m_UsersChoiceOfGameMode = (int)GameManager.eGameModes.GameModeOptionOne;
            }
        }

        private void buildGameFromSettings()
        {
            m_Game = new GameManager();
            m_Game.InitGame(m_UserSelectedBoardSize, m_UsersChoiceOfGameMode);
            StringBuilder name1 = new StringBuilder(m_SettingsForm.Player1TextBox);
            name1.Append(":");
            StringBuilder name2 = new StringBuilder(m_SettingsForm.Player2TextBox);
            name2.Append(":");
            m_GameForm = new GameForm(m_Game.GameBoard,name1.ToString(),name2.ToString());
        }
    }
}
