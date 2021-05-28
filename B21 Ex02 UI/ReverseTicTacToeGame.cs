using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace FirstWinApp
{
    public class ReverseTicTacToeGame : Form
    {
        Button m_ButtonStart;
        bool m_IsLoggedIn = false;
        private TextBox m_TextboxPlayerOne = new TextBox();
        private TextBox m_TextboxPlayerTwo = new TextBox();
        private FormLogin m_FormLogin = new FormLogin();
        public ReverseTicTacToeGame()
        {
            m_TextboxPlayerOne.Text = "PlayerName:";
            m_TextboxPlayerTwo.Location = new Point(10, 20);

            m_TextboxPlayerOne.Text = "PlayerName:";
            m_TextboxPlayerTwo.Location = new Point(10, 50);
            m_TextboxPlayerOne.Show();

            this.Text = "Reverse Tic Tac Toe Game";
            this.BackColor = Color.Gray;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Size = new Size(500, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            m_ButtonStart = new Button();
            m_ButtonStart.Text = "Start";
            this.Controls.Add(m_ButtonStart);
            

            m_ButtonStart.Click += new EventHandler(button_Click);
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
