using Ex02_Logic;

namespace Ex02_UI
{
    public class UI
    {
        private GameManager m_Game;

        public static bool m_QSelected;
        private int m_UsersChoiceOfGameMode;
        private int m_UserSelectedBoardSize;
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

        public void PlayGame()
        {
            while (m_Game.IsGameActive)
            { 
                m_Game.PlayTurn();
                if(m_Game.CheckWin())
                {
                    m_Game.UpdateEndRoundResult();
                    OutputManager.PrintGameResult(m_Game.IsTieGame, m_Game.PlayerOneWon);
                    StartOverMenu();
                }
            }
        }
        public void RunGame()
        {
            m_Game = new GameManager();
            OutputManager.PrintRequestForBoardSize();
            m_UserSelectedBoardSize = InputManager.GetValidNumFromUser(GameManager.k_MinBoardSize, GameManager.k_MaxBoardSize);
            CheckForUserWithdraw();
            OutputManager.PrintRequestForGameMode();
            m_UsersChoiceOfGameMode = InputManager.GetValidNumFromUser((int)GameManager.eGameModes.GameModeOptionOne, (int)GameManager.eGameModes.GameModeOptionTwo);
            CheckForUserWithdraw();
            m_Game.InitGame(m_UserSelectedBoardSize, m_UsersChoiceOfGameMode);
            PlayGame();
        }
    }
}
