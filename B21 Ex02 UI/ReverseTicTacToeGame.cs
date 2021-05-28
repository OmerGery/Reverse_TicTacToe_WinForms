using Ex02_Logic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace Ex02_UI
{
    public class ReverseTicTacToeGame : Form
    {
        private GameManager m_Game;

        Button m_ButtonStart;
        Button m_ButtonBoardSize;
        bool m_IsLoggedIn = false;
        private Label m_LabelPlayerOne = new Label();
        private Label m_LabelPlayerTwo = new Label();
        private Label m_LabelBoardSize = new Label();
        private TextBox m_TextboxPlayerOne = new TextBox();
        private TextBox m_TextboxPlayerTwo = new TextBox();
        private FormLogin m_FormLogin = new FormLogin();

        public ReverseTicTacToeGame()
        {
            m_Game = new GameManager();

            this.Text = "Reverse Tic Tac Toe - Settings";
            this.BackColor = Color.Gray;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Size = new Size(300, 300);
            this.StartPosition = FormStartPosition.CenterScreen;

            m_LabelPlayerOne.Text = "First Player Name:";
            m_LabelPlayerOne.Location = new Point(20, 20);
            this.Controls.Add(m_LabelPlayerOne);

            m_TextboxPlayerOne.Text = "Player Name";
            m_TextboxPlayerOne.Location = new Point(150, 20);
            this.Controls.Add(m_TextboxPlayerOne);

            m_LabelPlayerTwo.Text = "Second Player Name:";
            m_LabelPlayerTwo.Location = new Point(20, 50);
            m_LabelPlayerTwo.Width = 130;
            this.Controls.Add(m_LabelPlayerTwo);

            m_TextboxPlayerTwo.Text = "Player Name";
            m_TextboxPlayerTwo.Location = new Point(150, 50);
            this.Controls.Add(m_TextboxPlayerTwo);

            m_LabelBoardSize.Text = "Board Size:";
            m_LabelBoardSize.Location = new Point(20, 100);
            this.Controls.Add(m_LabelBoardSize);

            int min = GameManager.k_MinBoardSize;
            int max = GameManager.k_MaxBoardSize;

            m_ButtonBoardSize = new Button();
            m_ButtonBoardSize.Location = new Point(20, 120);
            m_ButtonBoardSize.Size = new Size(50, 50);
            m_ButtonBoardSize.Text = min.ToString();
            this.Controls.Add(m_ButtonBoardSize);
            m_ButtonBoardSize.Click += new EventHandler(button_Click2); 


            m_ButtonStart = new Button();
            m_ButtonStart.Text = "Start";
            m_ButtonStart.BackColor = Color.Green;
            m_ButtonStart.Location = new Point(200, 140);
            this.Controls.Add(m_ButtonStart);
            m_ButtonStart.Click += new EventHandler(buttonStart_Click);

            //m_ButtonStart.Click += new EventHandler(button_Click);
        }

        private void buttonStart_Click(object i_Sender, EventArgs i_E)
        {

            m_Game.InitGame(int.Parse(m_ButtonBoardSize.Text), 1);
        }

        private void button_Click2(object sender, EventArgs e)
        {
            this.m_ButtonBoardSize.Text = "kelev";
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (ensureLoggedIn())
            {
                this.Text = (sender as Button).Text;
                this.Location = new Point(this.Location.X + 10, this.Location.Y);

                Button randomButton = new Button();
                int location = new Random().Next(300);
                randomButton.Text = location.ToString();
                randomButton.Location = new Point(location, location);
                randomButton.Click += new EventHandler(button_Click);
                this.Controls.Add(randomButton);
            }
        }

        private bool ensureLoggedIn()
        {
            if (!m_IsLoggedIn)
            {
     
                if (m_FormLogin.ShowDialog() == DialogResult.OK)
                {
                    if (m_FormLogin.UserName == "Dot" && m_FormLogin.Password == "Net")
                    {
                        if (MessageBox.Show(
                            "Approved!!",
                            "Login",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Information) != DialogResult.Cancel)
                        {
                            m_IsLoggedIn = true;
                        }
                    }
                    else
                    {
                        if (MessageBox.Show(
                            "Not Logged In!!",
                            "Login",
                            MessageBoxButtons.RetryCancel,
                            MessageBoxIcon.Error) == DialogResult.Retry)
                        {
                            ensureLoggedIn();
                        }
                    }
                }
            }

            return m_IsLoggedIn;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            ensureLoggedIn();
        }
    }
}
