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
            int oldY = 0, oldX = 0;
            int currentXPlace = 0, currentYPlace = 0;
            char?[,] boardMatrix = gameBoard.BoardMatrix;
            for(int i = 0; i < gameBoard.BoardSize; i++)
            {
                for(int j = 0; j < gameBoard.BoardSize; j++)
                {
                    buttonsMatrix[i,j] = new BoardButton(i, j);
                    currentXPlace = 10 + oldX;
                    currentYPlace = 10 + oldY;
                    buttonsMatrix[i,j].Location = new Point(40 + oldX, 40+oldY);
                    buttonsMatrix[i, j].Size = new System.Drawing.Size(50, 50);
                    Controls.Add(buttonsMatrix[i, j]);
                    buttonsMatrix[i, j].Click += new System.EventHandler(OnButtonClick);
                    
                    oldX += currentXPlace;
                }

                oldY += currentYPlace;
            }
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
        }
        private void OnButtonClick(object sender, EventArgs e)
        {
            (sender as Button).Text = "X";
        }



    }
}
