using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ex02_Logic;

namespace __B21_Ex02_UI
{
    public partial class GameForm : Form
    {
        private BoardButton[,] buttonsMatrix;
        public GameForm(Board gameBoard)
        {
            buttonsMatrix = new BoardButton[gameBoard.BoardSize, gameBoard.BoardSize];
            InitializeComponent();
            char?[,] boardMatrix = gameBoard.BoardMatrix;
            for(int i = 0; i < gameBoard.BoardSize; i++)
            {
                for(int j = 0; j < gameBoard.BoardSize; j++)
                {
                    buttonsMatrix[i,j] = new BoardButton(i, j);
                    buttonsMatrix[i,j].Location = new Point(i*10, j*10);
                    //this.m_GameStartButton.Name = "m_GameStartButton";
                    buttonsMatrix[i, j].Size = new System.Drawing.Size(352, 68);
                    buttonsMatrix[i, j].TabIndex = i+j;
                    //buttonsMatrix[i, j].Text = "Start!";
                    buttonsMatrix[i, j].UseVisualStyleBackColor = true;
                    //buttonsMatrix[i, j].Click += new System.EventHandler(this.startButton_Click);
                  //  buttonsMatrix[i,j].Show();
                }
            }
        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void m_ScoreBoardPlayer1_Click(object sender, EventArgs e)
        {

        }

        private void m_Player2Label_Click(object sender, EventArgs e)
        {

        }
    }
}
