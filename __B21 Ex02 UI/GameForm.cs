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
        private const int startX = 5;
        private const int startY = 5;
        public GameForm(Board gameBoard)
        {
            buttonsMatrix = new BoardButton[gameBoard.BoardSize, gameBoard.BoardSize];
            InitializeComponent();
            int currentXPlace = 0, currentYPlace = startY;
            char?[,] boardMatrix = gameBoard.BoardMatrix;
            for(int i = 0; i < gameBoard.BoardSize; i++)
            {
                currentXPlace = startX;
                for (int j = 0; j < gameBoard.BoardSize; j++)
                {
                    buttonsMatrix[i,j] = new BoardButton(i, j);
                    buttonsMatrix[i,j].Location = new Point(currentXPlace,currentYPlace);
                    buttonsMatrix[i, j].Size = new System.Drawing.Size(50, 50);
                    Controls.Add(buttonsMatrix[i, j]);
                    buttonsMatrix[i, j].Click += new System.EventHandler(OnButtonClick);
                    
                    currentXPlace += 60;
                }

                currentYPlace += 60;
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
