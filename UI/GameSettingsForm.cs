using System;
using System.Windows.Forms;

namespace Ex05_UI
{
    public partial class GameSettingsForm : Form
    {
        private const string k_ComputerName = "Computer";
        private bool m_StartSelected;

        public bool StartSelected
        {
            get
            {
                return m_StartSelected;
            }
        }

        public GameSettingsForm()
        {
            m_StartSelected = false;
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (m_Player1TextBox.Text == string.Empty || m_Player2TextBox.Text == string.Empty)
            {
                OutputManager.PrintNoNameError();
            }
            else
            {
                m_StartSelected = true;
                Close();
            }
        }

        private void player2checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if(m_Player2TextBox.Enabled)
            {
                m_Player2TextBox.Text = k_ComputerName;
            }
            else
            {
                m_Player2TextBox.Text = string.Empty;
            }

            m_Player2TextBox.Enabled = !m_Player2TextBox.Enabled;
        }

        private void rowsUpDown_ValueChanged(object sender, EventArgs e)
        {
            m_ColsUpDown.Value = m_RowsUpDown.Value;
        }

        private void colsUpDown_ValueChanged(object sender, EventArgs e)
        {
            m_RowsUpDown.Value = m_ColsUpDown.Value;
        }

        private void GameSettingsForm_Load(object sender, EventArgs e)
        {
        }
    }
}
