﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Ex02_Logic;

namespace __B21_Ex02_UI
{
    public partial class GameForm : Form
    {
        private readonly int r_FormSize;
        private BoardButton[,] m_ButtonsMatrix;
        private const int k_StartX = 20;
        private const int k_StartY = 5;
        public GameForm(Board i_GameBoard,string i_PlayerName1,string i_PlayerName2)
        {
            InitializeComponent();
            Player1Label.Text = i_PlayerName1;
            Player2Label.Text = i_PlayerName2;
            r_FormSize = i_GameBoard.BoardSize;
            Height = Width = r_FormSize * 75;
            buildButtonsMatrix(i_GameBoard);
            initPlayerLabels();
        }

        private void buildButtonsMatrix(Board i_GameBoard)
        {
            m_ButtonsMatrix = new BoardButton[r_FormSize, r_FormSize];
            int currentXPlace , currentYPlace = k_StartY;
            for (int i = 0; i < i_GameBoard.BoardSize; i++)
            {
                currentXPlace = k_StartX;
                for (int j = 0; j < i_GameBoard.BoardSize; j++)
                {
                    m_ButtonsMatrix[i, j] = new BoardButton(i, j);
                    m_ButtonsMatrix[i, j].Location = new Point(currentXPlace, currentYPlace);
                    m_ButtonsMatrix[i, j].Size = new System.Drawing.Size(50, 40);
                    Controls.Add(m_ButtonsMatrix[i, j]);
                    m_ButtonsMatrix[i, j].Click += new System.EventHandler(OnButtonClick);

                    currentXPlace += 60;
                }

                currentYPlace += 60;
            }
        }

        private void initPlayerLabels()
        {
            int currentXPlace = m_ButtonsMatrix[0, r_FormSize/2 - 1 ].Location.X + 25;
            int currentYPlace = (Height) - 55;
            Player1Label.Location = new Point(currentXPlace, currentYPlace);
            currentXPlace = Player1Label.Location.X + Player1Label.Width;
            Player1ScoreBoard.Location = new Point(currentXPlace, currentYPlace);
            currentXPlace = Player1ScoreBoard.Location.X + Player1ScoreBoard.Width + 5;
            Player2Label.Location = new Point(currentXPlace, currentYPlace);
            currentXPlace = Player2Label.Location.X + Player2Label.Width;
            Player2ScoreBoard.Location = new Point(currentXPlace, currentYPlace);
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
