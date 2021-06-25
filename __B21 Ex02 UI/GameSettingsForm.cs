using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace __B21_Ex02_UI
{
    public partial class GameSettingsForm : Form
    {
        public GameSettingsForm()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        { 
            this.Close();
        }


        private void player2checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if(m_Player2TextBox.Enabled)
            {
                m_Player2TextBox.Text = "Computer";
            }
            else
            {
                m_Player2TextBox.Text = string.Empty;
            }
            m_Player2TextBox.Enabled = !(m_Player2TextBox.Enabled);
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
