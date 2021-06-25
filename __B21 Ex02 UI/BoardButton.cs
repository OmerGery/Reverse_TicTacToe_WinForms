

using System.Drawing;
using System.Windows.Forms;
using Ex02_Logic;

namespace __B21_Ex02_UI
{
    public class BoardButton : Button
    {
        private Board.Square m_PlaceOnBoard;

        public BoardButton(int i_Row, int i_Col)
        {
            m_PlaceOnBoard = new Board.Square();
            m_PlaceOnBoard.m_Row = i_Row;
            m_PlaceOnBoard.m_Col = i_Col;
        }

        public int xPlace
        {
            get
            {
                return m_PlaceOnBoard.m_Col;

            }
        }
        public int yPlace
        {
            get { return m_PlaceOnBoard.m_Row; }
        }
    }
}
