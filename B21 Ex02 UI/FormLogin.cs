using Ex02_Logic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Ex02_UI
{
    public class FormLogin : Form
    {
        TextBox m_TextboxUsername = new TextBox();
        TextBox m_TextboxPassword = new TextBox();

        Label m_LabelUserName = new Label();
        Label m_LabelPassword = new Label();

        Button m_ButtonOK = new Button();
        Button m_ButtonCancel = new Button();

        public FormLogin()
        {
            this.Size = new Size(150, 150);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Login";
        }

        /// <summary>
        /// This method will be called once, just before the first time the form is displayed
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            InitControls();
        }

        /// <summary>
        /// Layouting the controls (textboxes, lables, buttons) on the form
        /// </summary>
        private void InitControls()
        {
            m_LabelUserName.Text = "User Name:";
            m_LabelUserName.Location = new Point(10, 20);

            m_LabelPassword.Text = "Password:";
            m_LabelPassword.Location = new Point(10, 50);

            int textBoxTop = m_LabelUserName.Top + m_LabelUserName.Height / 2;
            textBoxTop -= m_TextboxUsername.Height / 2;

            m_TextboxUsername.Location = new Point(m_LabelUserName.Right + 8,
                textBoxTop);

            int textBoxPasswordTop = m_LabelPassword.Top + m_LabelPassword.Height / 2;
            textBoxPasswordTop -= m_TextboxPassword.Height / 2;

            m_TextboxPassword.Location = new Point(m_LabelPassword.Right + 8,
                textBoxPasswordTop);

            this.Width = m_TextboxPassword.Right + 16;

            m_ButtonCancel.Text = "Cancel";
            m_ButtonCancel.Location = new Point(this.ClientSize.Width - m_ButtonCancel.Width - 8,
                this.ClientSize.Height - m_ButtonCancel.Height - 8);

            m_ButtonOK.Text = "OK";
            m_ButtonOK.Location = new Point(m_ButtonCancel.Left - m_ButtonOK.Width - 8,
                this.ClientSize.Height - m_ButtonOK.Height - 8);


            this.Controls.AddRange(new Control[] { m_LabelPassword, m_LabelUserName, m_TextboxPassword, m_TextboxUsername, m_ButtonOK, m_ButtonCancel });

            this.m_ButtonCancel.Click += new EventHandler(m_ButtonCancel_Click);
            this.m_ButtonOK.Click += new EventHandler(m_ButtonOK_Click);
        }

        /// <summary>
        /// Uppon cancel - close the dialog with DialogResult.Cancel
        /// </summary>
        void m_ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Uppon cancel - close the dialog with DialogResult.OK
        /// </summary>
        void m_ButtonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public string UserName
        {
            get { return m_TextboxUsername.Text; }
            set { m_TextboxUsername.Text = value; }
        }

        public string Password
        {
            get { return m_TextboxPassword.Text; }
            set { m_TextboxPassword.Text = value; }
        }
    }
}
