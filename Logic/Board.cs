using System.Collections.Generic;

namespace Ex05_Logic
{
    public class Board
    {
        private readonly int r_BoardSize;
        private readonly char?[,] r_BoardMatrix;
        private readonly List<Square> r_AvailableSquares;

        public List<Square> AvailableSquares
        {
            get
            {
                return r_AvailableSquares;
            }
        }

        public struct Square
        {
            public int m_Row;
            public int m_Col;
        }

        public int BoardSize
        {
            get
            {
                return r_BoardSize;
            }
        }

        public Board(int i_SizeOfBoard)
        {
            r_BoardSize = i_SizeOfBoard;
            r_BoardMatrix = new char?[i_SizeOfBoard, i_SizeOfBoard];
            r_AvailableSquares = new List<Square>();
            for (int i = 1; i <= r_BoardSize; i++)
            {
                for (int j = 1; j <= r_BoardSize; j++)
                {
                    r_AvailableSquares.Add(new Square() { m_Row = i, m_Col = j });
                }
            }
        }

        public void AddShape(char i_Shape, Square i_AddedSquare)
        {
            r_BoardMatrix[i_AddedSquare.m_Row - 1, i_AddedSquare.m_Col - 1] = i_Shape;
            r_AvailableSquares.Remove(new Square() { m_Row = i_AddedSquare.m_Row, m_Col = i_AddedSquare.m_Col });
        }

        public void RemoveShape(char i_Shape, Square i_AddedSquare)
        {
            r_BoardMatrix[i_AddedSquare.m_Row - 1, i_AddedSquare.m_Col - 1] = null;
            r_AvailableSquares.Add(new Square() { m_Row = i_AddedSquare.m_Row, m_Col = i_AddedSquare.m_Col });
        }

        public bool CheckIfSquareTaken(Square i_SquareToCheck)
        {
            return r_BoardMatrix[i_SquareToCheck.m_Row - 1, i_SquareToCheck.m_Col - 1] != null;
        }

        public bool CheckForRightSequence(int i_RowToCheck, int i_ColToCheck)
        {
            char? symbolToCheck = r_BoardMatrix[i_RowToCheck - 1, i_ColToCheck - 1];
            bool isSequence = true;
            if (i_ColToCheck - 1 > 0 || symbolToCheck == null)
            {
                isSequence = false;
            }
            else
            {
                for (int i = 1; i < r_BoardSize; i++)
                {
                    if (r_BoardMatrix[i_RowToCheck - 1, i] != symbolToCheck)
                    {
                        isSequence = false;
                        break;
                    }
                }
            }

            return isSequence;
        }

        public bool CheckForDownSequence(int i_RowToCheck, int i_ColToCheck)
        {
            char? symbolToCheck = r_BoardMatrix[i_RowToCheck - 1, i_ColToCheck - 1];
            bool isSequence = true;
            if (i_RowToCheck - 1 > 0 || symbolToCheck == null)
            {
                isSequence = false;
            }
            else
            {
                for (int i = 1; i < r_BoardSize; i++)
                {
                    if (r_BoardMatrix[i, i_ColToCheck - 1] != symbolToCheck)
                    {
                        isSequence = false;
                        break;
                    }
                }
            }

            return isSequence;
        }

        public bool CheckForRightDiagonalSequence(int i_RowToCheck, int i_ColToCheck)
        {
            i_ColToCheck--;
            i_RowToCheck--;
            char? symbolToCheck = r_BoardMatrix[i_RowToCheck, i_ColToCheck];
            bool isSequence = true;
            if (i_RowToCheck > 0 || i_ColToCheck > 0 || symbolToCheck == null)
            {
                isSequence = false;
            }
            else
            {
                for (int i = 1; i < r_BoardSize; i++)
                {
                    if (r_BoardMatrix[i_RowToCheck + i, i_ColToCheck + i] != symbolToCheck)
                    {
                        isSequence = false;
                        break;
                    }
                }
            }

            return isSequence;
        }

        public bool CheckForLeftDiagonalSequence(int i_RowToCheck, int i_ColToCheck)
        {
            i_RowToCheck--;
            i_ColToCheck--;
            char? symbolToCheck = r_BoardMatrix[i_RowToCheck, i_ColToCheck];
            bool isSequence = true;
            if (i_RowToCheck > 0 || i_ColToCheck < r_BoardSize - 1 || symbolToCheck == null)
            {
                isSequence = false;
            }
            else
            {
                for (int i = 1; i < r_BoardSize; i++)
                {
                    if (r_BoardMatrix[i_RowToCheck + i, i_ColToCheck - i] != symbolToCheck)
                    {
                        isSequence = false;
                        break;
                    }
                }
            }

            return isSequence;
        }
    }
}
