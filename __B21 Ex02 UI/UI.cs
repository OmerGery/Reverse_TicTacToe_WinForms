﻿using __B21_Ex02_UI;
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
            BuildGameFromSettings();
            m_GameForm.ShowDialog();
            m_Game = new GameManager();
            //    m_UserSelectedBoardSize = InputManager.GetValidNumFromUser(GameManager.k_MinBoardSize, GameManager.k_MaxBoardSize);
            //   m_UsersChoiceOfGameMode = InputManager.GetUsersChoiceOfGameMode();
            CheckForUserWithdraw();
            m_Game.InitGame(m_UserSelectedBoardSize, m_UsersChoiceOfGameMode);
            PlayGame();
        }

        private void BuildGameFromSettings()
        {
            m_GameForm = new GameForm();
            //char buttonsArray = m_Game.GameBoard.BoardMatrix;
            int amountOfRows = m_SettingsForm.RowsUpDown;
            m_GameForm.Height = m_GameForm.Width = amountOfRows * 75;
            m_GameForm.Player1Label =  m_SettingsForm.Player1TextBox + ":";
            m_GameForm.Player2Label = m_SettingsForm.Player2TextBox + ":";
        }
    }
}
