using System;

namespace Ex02_Logic
{
    public class GameManager
    {
        public const int k_MaxBoardSize = 9;
        public const int k_MinBoardSize = 3;
        public const char k_SymbolOne = 'X';
        public const char k_SymbolTwo = 'O';

        public enum eGameModes
        {
            GameModeOptionOne = 1,
            GameModeOptionTwo
        }

        private bool m_PlayerOneWon;
//        public static bool m_QSelected;
        private Player m_PlayerOne;
        private Player m_PlayerTwo;
        private bool m_IsGameActive;
        private Board m_GameBoard;
        private int m_TurnCounter;
        private bool m_IsTieGame;

        public bool IsGameActive
        {
            get
            {
                return m_IsGameActive;
            }
        }
        public Player PlayerOne
        {
            get
            {
                return m_PlayerOne;
            }
        }
        public Player PlayerTwo
        {
            get
            {
                return m_PlayerTwo;
            }
        }
        public bool IsTieGame
        {
            get
            {
                return m_IsTieGame;
            }
        }
        public bool PlayerOneWon
        {
            get
            {
                return m_PlayerOneWon;
            }
        }

        

        public Board GameBoard
        {
            get { return m_GameBoard; }
        }

        public GameManager()
        {
            m_PlayerOneWon = false;
            m_IsTieGame = false;
            m_PlayerOne = new Player(k_SymbolOne, true);
            m_PlayerTwo = new Player(k_SymbolTwo, true);
            m_IsGameActive = true;
            m_GameBoard = null;
        }

        public void InitGame(int i_BoardSize, int i_UsersChoiceOfGameMode) 
        {
            m_TurnCounter = 0;
            m_GameBoard = new Board(i_BoardSize);
            if (i_UsersChoiceOfGameMode == (int)eGameModes.GameModeOptionOne)
            {
                m_PlayerTwo.IsHuman = false;
            }
        }

      

        public void UpdateEndRoundResult()
        {
            m_PlayerOneWon = false;
            if(!m_IsTieGame)
            {
                if(m_TurnCounter % 2 != 0)
                {
                    m_PlayerTwo.WinsCounter++;
                }
                else
                {
                    m_PlayerOne.WinsCounter++;
                    m_PlayerOneWon = true;
                }
            }
        }

        

        private Board.Square getComputerSmartChoice()
        {
            Board.Square selectedSquare = new Board.Square();
            for (int i = 0; i < m_GameBoard.BoardSize * m_GameBoard.BoardSize; i++)
            {
                Random random = new Random();
                int indexInList = random.Next(m_GameBoard.AvailableSquares.Count);
                selectedSquare = m_GameBoard.AvailableSquares[indexInList];
                m_GameBoard.AddShape(k_SymbolTwo, selectedSquare);
                bool isNewMoveMadeWin = CheckWinOrTie();
                if(isNewMoveMadeWin)
                {
                    m_GameBoard.RemoveShape(k_SymbolTwo, selectedSquare);
                }
                else
                {
                    m_GameBoard.RemoveShape(k_SymbolTwo, selectedSquare);
                    break;
                }
            }

            return selectedSquare;
        }

        public void CheckTie()
        {
            if(m_TurnCounter == (int)Math.Pow(m_GameBoard.BoardSize, 2) - 1)
            {
                m_IsTieGame = true;
            }
        }

        public bool isHumanTurn()
        {
            bool humanTurn = true;
            if (m_TurnCounter % 2 != 0)
            {
                humanTurn = m_PlayerTwo.IsHuman;
            }

            return humanTurn;
        }

        public void PlayHumanTurn(Board.Square i_Square)
        {
            if(m_TurnCounter % 2 == 0)
            {
                m_PlayerOne.MakeMove(m_GameBoard, i_Square);
            }
            else
            {
                m_PlayerTwo.MakeMove(m_GameBoard, i_Square);
            }

            m_TurnCounter++;
        }

        public void PlayComputerTurn()
        {
            Board.Square computerAiChoice = getComputerSmartChoice();
            m_PlayerTwo.MakeMove(m_GameBoard, computerAiChoice);
            m_TurnCounter++;
        }
        
        public bool CheckWinOrTie()
        {
            bool hasPlayerWon = false;
            for (int i = 1; i <= m_GameBoard.BoardSize; i++)
            {
                for (int j = 1; j <= m_GameBoard.BoardSize; j++)
                {
                    if (m_GameBoard.CheckForDownSequence(i, j) || m_GameBoard.CheckForRightSequence(i, j) || m_GameBoard.CheckForRightDiagonalSequence(i, j) || m_GameBoard.CheckForLeftDiagonalSequence(i, j))
                    {
                        hasPlayerWon = true;
                        break;
                    }
                }
            }

            if(!hasPlayerWon)
            {
                CheckTie();
            }
            return hasPlayerWon;
        }
    }
}
