using System.Windows.Forms;
using Ex05_Logic;

namespace Ex05_UI
{
    public class BoardButton : Button
    {
        private Board.Square m_PlaceOnBoard;

        public BoardButton(int i_Row, int i_Col)
        {
            m_PlaceOnBoard = new Board.Square();
            m_PlaceOnBoard.m_Row = i_Row + 1;
            m_PlaceOnBoard.m_Col = i_Col + 1;
        }

        public Board.Square PlaceOnBoard
        {
            get
            {
                return m_PlaceOnBoard;
            }
        }
    }
}
