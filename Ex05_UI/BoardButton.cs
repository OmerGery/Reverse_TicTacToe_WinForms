using System.Windows.Forms;
using Ex05_Logic;

namespace Ex05_UI
{
    public class BoardButton : Button
    {
        private readonly Board.Square r_PlaceOnBoard;

        public BoardButton(int i_Row, int i_Col)
        {
            r_PlaceOnBoard = new Board.Square { m_Row = i_Row + 1, m_Col = i_Col + 1 };
        }

        public Board.Square PlaceOnBoard
        {
            get
            {
                return r_PlaceOnBoard;
            }
        }
    }
}
