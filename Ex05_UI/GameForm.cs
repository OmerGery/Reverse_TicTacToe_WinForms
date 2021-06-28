using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Ex05_Logic;

namespace Ex05_UI
{
    public partial class GameForm : Form
    {
        private const int k_StartX = 20;
        private const int k_StartY = 5;
        private readonly int r_UsersChoiceOfGameMode;
        private readonly int r_FormSize;
        private readonly GameManager r_Game;
        private BoardButton[,] m_ButtonsMatrix;
        private bool m_IsPlayerOneTurn;

        public GameForm(string i_PlayerName1, string i_PlayerName2, GameManager i_Game, int i_GameMode)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            r_UsersChoiceOfGameMode = i_GameMode;
            InitializeComponent();
            r_Game = i_Game;
            m_IsPlayerOneTurn = true;
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
            for (int i = 0; i < r_Game.GameBoard.BoardSize; i++)
            {
                int currentXPlace = k_StartX;
                for (int j = 0; j < r_Game.GameBoard.BoardSize; j++)
                {
                    m_ButtonsMatrix[i, j] = new BoardButton(i, j);
                    m_ButtonsMatrix[i, j].TabStop = false;
                    m_ButtonsMatrix[i, j].Text = string.Empty;
                    m_ButtonsMatrix[i, j].Font = new Font(m_ButtonsMatrix[i,j].Font, FontStyle.Bold);
                    m_ButtonsMatrix[i, j].FlatStyle = FlatStyle.Popup;
                    m_ButtonsMatrix[i, j].Location = new Point(currentXPlace, currentYPlace);
                    m_ButtonsMatrix[i, j].Size = new Size(50, 40);
                    Controls.Add(m_ButtonsMatrix[i, j]);
                    m_ButtonsMatrix[i, j].Click += boardButton_Click;
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
            if(m_IsPlayerOneTurn)
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

        private void boardButton_Click(object sender, EventArgs e)
        {
            if (sender is BoardButton senderButton)
            {
                OutputManager.PlayClick();
                Board.Square userSelectedSquare = senderButton.PlaceOnBoard;
                drawSymbol(senderButton);
                updateTurn(userSelectedSquare, senderButton);
                updateWinningStatus();
            }
        }

        private void updateWinningStatus()
        {
            bool gameFinished = checkWinningStatus();
            if (gameFinished)
            {
                roundWinner();
            }
            else
            {
                if (r_UsersChoiceOfGameMode == (int)GameManager.eGameModes.ComputerGameMode)
                {
                    doComputerTurn();
                }

                if (checkWinningStatus())
                {
                    roundWinner();
                }
            }
        }

        private void updateTurn(Board.Square i_UserSelectedSquare, BoardButton i_SenderButton)
        {
            r_Game.PlayHumanTurn(i_UserSelectedSquare);
            m_IsPlayerOneTurn = !m_IsPlayerOneTurn;
            makeCurrentPlayerFontBold();
            i_SenderButton.Enabled = false;
        }

        private void drawSymbol(BoardButton i_SenderButton)
        {
            if (m_IsPlayerOneTurn)
            {
                i_SenderButton.Text = GameManager.k_SymbolOne.ToString();
            }
            else
            {
                i_SenderButton.Text = GameManager.k_SymbolTwo.ToString();
            }
        }

        private void roundWinner()
        {
            string currentPlayerName = Player2Label.Text;
            if (m_IsPlayerOneTurn)
            {
                currentPlayerName = Player1Label.Text;
            }

            currentPlayerName = currentPlayerName.Remove(currentPlayerName.Length - 1, 1);
            bool toPlayAnotherRound = OutputManager.AskUserForAnotherRound(r_Game.IsTieGame, currentPlayerName);
            endOfRound(toPlayAnotherRound);
        }

        private void doComputerTurn()
        { 
            Board.Square computerSelection = r_Game.PlayComputerTurn();
            m_ButtonsMatrix[computerSelection.m_Row - 1, computerSelection.m_Col - 1].Enabled = false;
            m_ButtonsMatrix[computerSelection.m_Row - 1, computerSelection.m_Col - 1].Text = GameManager.k_SymbolTwo.ToString();
            m_IsPlayerOneTurn = !m_IsPlayerOneTurn;
            makeCurrentPlayerFontBold();
        }

        private bool checkWinningStatus()
        {
            bool gameFinished = r_Game.CheckWinOrTie() || r_Game.IsTieGame;
            if (gameFinished)
            {
                r_Game.UpdateEndRoundResult();
            }

            return gameFinished;
        }

        private void endOfRound(bool i_PlayAnotherRound)
        { 
            if (i_PlayAnotherRound)
            {
                r_Game.InitGame(r_FormSize, r_UsersChoiceOfGameMode);
                m_IsPlayerOneTurn = true;
                newRound();
            }
            else
            {
                Close();
            }
        }

        private void newRound()
        {
            clearBoard();
            updateScoreBoard();
            makeCurrentPlayerFontBold();
        }

        private void clearBoard()
        {
            foreach(BoardButton button in m_ButtonsMatrix)
            {
                button.Text = string.Empty;
                button.Enabled = true;
            }
        }

        private void updateScoreBoard()
        {
            Player1ScoreBoard.Text = r_Game.PlayerOne.WinsCounter.ToString();
            Player2ScoreBoard.Text = r_Game.PlayerTwo.WinsCounter.ToString();
        }
    }
}
