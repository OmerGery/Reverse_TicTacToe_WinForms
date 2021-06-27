using System;

namespace Ex05_Logic
{
    public class GameManager
    {
        public const char k_SymbolOne = 'X';
        public const char k_SymbolTwo = 'O';
        private static Random s_Random;

        public enum eGameModes
        {
            ComputerGameMode = 1,
            HumanGameMode
        }

        private readonly Player r_PlayerOne;
        private readonly Player r_PlayerTwo;
        private Board m_GameBoard;
        private int m_TurnCounter;
        private bool m_IsTieGame;

        public Player PlayerOne
        {
            get
            {
                return r_PlayerOne;
            }
        }

        public Player PlayerTwo
        {
            get
            {
                return r_PlayerTwo;
            }
        }

        public bool IsTieGame
        {
            get
            {
                return m_IsTieGame;
            }
        }

        public Board GameBoard
        {
            get { return m_GameBoard; }
        }

        public GameManager()
        {
            s_Random = new Random();
            m_IsTieGame = false;
            r_PlayerOne = new Player(k_SymbolOne, true);
            r_PlayerTwo = new Player(k_SymbolTwo, true);
            m_GameBoard = null;
        }

        public void InitGame(int i_BoardSize, int i_UsersChoiceOfGameMode) 
        {
            m_IsTieGame = false;
            m_TurnCounter = 0;
            m_GameBoard = new Board(i_BoardSize);
            if (i_UsersChoiceOfGameMode == (int)eGameModes.ComputerGameMode)
            {
                r_PlayerTwo.IsHuman = false;
            }
        }

        public void UpdateEndRoundResult()
        {
            if(!m_IsTieGame)
            {
                if(m_TurnCounter % 2 != 0)
                {
                    r_PlayerTwo.WinsCounter++;
                }
                else
                {
                    r_PlayerOne.WinsCounter++;
                }
            }
        }

        private Board.Square getComputerSmartChoice()
        {
            Board.Square selectedSquare = new Board.Square();
            for (int i = 0; i < m_GameBoard.BoardSize * m_GameBoard.BoardSize; i++)
            {
                int indexInList = s_Random.Next(m_GameBoard.AvailableSquares.Count);
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

        private void checkTie()
        {
            if(m_TurnCounter == (int)Math.Pow(m_GameBoard.BoardSize, 2))
            {
                m_IsTieGame = true;
            }
        }

        public void PlayHumanTurn(Board.Square i_Square)
        {
            if(m_TurnCounter % 2 == 0)
            {
                r_PlayerOne.MakeMove(m_GameBoard, i_Square);
            }
            else
            {
                r_PlayerTwo.MakeMove(m_GameBoard, i_Square);
            }

            m_TurnCounter++;
        }

        public Board.Square PlayComputerTurn()
        {
            Board.Square computerAiChoice = getComputerSmartChoice();
            r_PlayerTwo.MakeMove(m_GameBoard, computerAiChoice);
            m_TurnCounter++;
            return computerAiChoice;
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
                checkTie();
            }

            return hasPlayerWon;
        }
    }
}
