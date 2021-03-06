namespace Ex05_Logic
{
        public class Player
        {
            private readonly char r_Symbol;
            private bool m_IsHuman;
            private int m_WinsCounter;

            public Player(char i_Symbol, bool i_IsHuman)
            {
                r_Symbol = i_Symbol;
                m_IsHuman = i_IsHuman;
                m_WinsCounter = 0;
            }

            public bool IsHuman
            {
                get
                {
                    return m_IsHuman;
                }

                set
                {
                    m_IsHuman = value;
                }
            }

            private char Symbol
            {
                get
                {
                    return r_Symbol;
                }
            }

            public int WinsCounter
            {
                get
                {
                    return m_WinsCounter;
                }

                set
                {
                    m_WinsCounter = value;
                }
            }

            public void MakeMove(Board i_GameBoard, Board.Square i_Square)
            {
                i_GameBoard.AddShape(Symbol, i_Square);
            }
        }
    }