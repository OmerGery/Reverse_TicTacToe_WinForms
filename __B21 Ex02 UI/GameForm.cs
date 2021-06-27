using System;
using System.Drawing;
using System.Windows.Forms;
using Ex05_Logic;
using Ex05_UI;

namespace Ex05_UI
{
    public partial class GameForm : Form
    {
        private const int k_StartX = 20;
        private const int k_StartY = 5;
        private readonly int r_FormSize;
        private GameManager m_Game;
        private BoardButton[,] m_ButtonsMatrix;
        private bool m_isPlayerOneTurn;
        private int m_UsersChoiceOfGameMode;

        public GameForm(string i_PlayerName1, string i_PlayerName2, GameManager i_Game, int i_GameMode)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            m_UsersChoiceOfGameMode = i_GameMode;
            InitializeComponent();
            m_Game = i_Game;
            m_isPlayerOneTurn = true;
            Player1Label.Text = i_PlayerName1;
            Player2Label.Text = i_PlayerName2;
            r_FormSize = i_Game.GameBoard.BoardSize;
            Height = Width = r_FormSize * 75;
            buildButtonsMatrix();
            initPlayerLabels();
        }

        private void buildButtonsMatrix()
        {
            m_ButtonsMatrix = new BoardButton[r_FormSize, r_FormSize];
            int currentYPlace = k_StartY;
            for (int i = 0; i < m_Game.GameBoard.BoardSize; i++)
            {
                int currentXPlace = k_StartX;
                for (int j = 0; j < m_Game.GameBoard.BoardSize; j++)
                {
                    m_ButtonsMatrix[i, j] = new BoardButton(i, j);
                    m_ButtonsMatrix[i, j].Text = string.Empty;
                    m_ButtonsMatrix[i, j].Location = new Point(currentXPlace, currentYPlace);
                    m_ButtonsMatrix[i, j].Size = new Size(50, 40);
                    Controls.Add(m_ButtonsMatrix[i, j]);
                    m_ButtonsMatrix[i, j].Click += OnButtonClick;
                    m_ButtonsMatrix[i, j].Enabled = true;
                    currentXPlace += 60;
                }

                currentYPlace += 60;
            }
        }

        private void initPlayerLabels()
        {
            int currentXPlace = m_ButtonsMatrix[0, (r_FormSize / 2) - 1].Location.X + 25;
            int currentYPlace = (Height) -55;
            Player1Label.Location = new Point(currentXPlace, currentYPlace);
            currentXPlace = Player1Label.Location.X + Player1Label.Width;
            Player1ScoreBoard.Location = new Point(currentXPlace, currentYPlace);
            currentXPlace = Player1ScoreBoard.Location.X + Player1ScoreBoard.Width + 5;
            Player2Label.Location = new Point(currentXPlace, currentYPlace);
            currentXPlace = Player2Label.Location.X + Player2Label.Width;
            Player2ScoreBoard.Location = new Point(currentXPlace, currentYPlace);
            makeCurrentPlayerFontBold();
        }

        private void makeCurrentPlayerFontBold()
        {
            if(m_isPlayerOneTurn)
            {
                Player1Label.Font = new Font(Player1Label.Font, FontStyle.Bold);
                Player2Label.Font = new Font(Player2Label.Font, FontStyle.Regular);
            }
            else
            {
                Player2Label.Font = new Font(Player2Label.Font, FontStyle.Bold);
                Player1Label.Font = new Font(Player1Label.Font, FontStyle.Regular);
            }
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            Board.Square userSelectedSquare = (sender as BoardButton).PlaceOnBoard;
          
            if (m_isPlayerOneTurn)
            {
                    (sender as Button).Text = GameManager.k_SymbolOne.ToString();
            }
            else
            { 
                (sender as Button).Text = GameManager.k_SymbolTwo.ToString();
            }

            m_Game.PlayHumanTurn(userSelectedSquare);
            makeCurrentPlayerFontBold();
            m_isPlayerOneTurn = !m_isPlayerOneTurn;

            if((sender as Button).Enabled)
            {
                (sender as Button).Enabled = false;
                bool gameFinished = checkWinningStatus();
                if (gameFinished)
                {
                    roundWinner();
                }
                else
                {
                    if (m_UsersChoiceOfGameMode == (int)GameManager.eGameModes.ComputerGameMode)
                    {
                        doComputerTurn();
                    }

                    if(checkWinningStatus())
                    {
                        roundWinner();
                    }
                }
            }
        }

        private void roundWinner()
        {
            string currentPlayerName = Player2Label.Text;
            if (m_isPlayerOneTurn)
            {
                currentPlayerName = Player1Label.Text;
            }

            currentPlayerName = currentPlayerName.Remove(currentPlayerName.Length - 1, 1);
            bool toPlayAnotherRound = OutputManager.AskUserForAnotherRound(m_Game.IsTieGame, currentPlayerName);
            EndOfRound(toPlayAnotherRound);
        }

        private void doComputerTurn()
        { 
            Board.Square computerSelection = m_Game.PlayComputerTurn();
            m_ButtonsMatrix[computerSelection.m_Row - 1, computerSelection.m_Col - 1].Enabled = false;
            m_ButtonsMatrix[computerSelection.m_Row - 1, computerSelection.m_Col - 1].Text = GameManager.k_SymbolTwo.ToString();
            m_isPlayerOneTurn = !m_isPlayerOneTurn;
        }

        private bool checkWinningStatus()
        {
            bool gameFinished = m_Game.CheckWinOrTie() || m_Game.IsTieGame;
            if (gameFinished)
            {
                m_Game.UpdateEndRoundResult();
            }

            return gameFinished;
        }

        public void EndOfRound(bool i_PlayAnotherRound)
        { 
            if (i_PlayAnotherRound)
            {
                GameManager game = new GameManager();
                m_Game.InitGame(r_FormSize, m_UsersChoiceOfGameMode);
                m_isPlayerOneTurn = true;
                NewRound();
            }
            else
            {
                Close();
            }
        }

        private void NewRound()
        {
            ClearBoard();
            UpdateScoreBoard();
            makeCurrentPlayerFontBold();
        }

        private void ClearBoard()
        {
            foreach(Button button in m_ButtonsMatrix)
            {
                button.Text = string.Empty;
                button.Enabled = true;
            }
        }

        private void UpdateScoreBoard()
        {
            Player1ScoreBoard.Text = m_Game.PlayerOne.WinsCounter.ToString();
            Player2ScoreBoard.Text = m_Game.PlayerTwo.WinsCounter.ToString();
        }
    }
}
