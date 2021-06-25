
using System.CodeDom;

namespace __B21_Ex02_UI
{
    partial class GameSettingsForm
    { 
      
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button m_GameStartButton;
        private System.Windows.Forms.Label m_Player1Label;
        private System.Windows.Forms.TextBox m_Player1TextBox;
        private System.Windows.Forms.TextBox m_Player2TextBox;
        private System.Windows.Forms.Label m_BoardSizeLabel;
        private System.Windows.Forms.NumericUpDown m_RowsUpDown;
        public System.Windows.Forms.NumericUpDown m_ColsUpDown;
        private System.Windows.Forms.Label m_RowsLabel;
        private System.Windows.Forms.Label m_ColsLabel;
        private System.Windows.Forms.CheckBox m_Player2checkBox;
        private System.Windows.Forms.Label m_PlayersLabel;

        public int RowsUpDown
        {
            get
            {
                return (int) m_RowsUpDown.Value;
            }
        }

        public string Player1TextBox
        {
            get
            {
                return m_Player1TextBox.Text;
            }
        }

        public string Player2TextBox
        {
            get
            {
                return m_Player2TextBox.Text;
            }
        }

        public bool Player2checkBox
        {
            get
            {
                return m_Player2checkBox.Checked;
            }
        }

        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_GameStartButton = new System.Windows.Forms.Button();
            this.m_Player1Label = new System.Windows.Forms.Label();
            this.m_Player1TextBox = new System.Windows.Forms.TextBox();
            this.m_Player2TextBox = new System.Windows.Forms.TextBox();
            this.m_BoardSizeLabel = new System.Windows.Forms.Label();
            this.m_RowsUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_ColsUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_RowsLabel = new System.Windows.Forms.Label();
            this.m_ColsLabel = new System.Windows.Forms.Label();
            this.m_Player2checkBox = new System.Windows.Forms.CheckBox();
            this.m_PlayersLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_RowsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_ColsUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // GameSettingsForm
            // 
            this.m_GameStartButton.Location = new System.Drawing.Point(89, 211);
            this.m_GameStartButton.Margin = new System.Windows.Forms.Padding(2);
            this.m_GameStartButton.Name = "GameSettingsForm";
            this.m_GameStartButton.Size = new System.Drawing.Size(235, 44);
            this.m_GameStartButton.TabIndex = 0;
            this.m_GameStartButton.Text = "Start!";
            this.m_GameStartButton.UseVisualStyleBackColor = true;
            this.m_GameStartButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // m_Player1Label
            // 
            this.m_Player1Label.AutoSize = true;
            this.m_Player1Label.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.m_Player1Label.Location = new System.Drawing.Point(35, 38);
            this.m_Player1Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_Player1Label.Name = "m_Player1Label";
            this.m_Player1Label.Size = new System.Drawing.Size(48, 13);
            this.m_Player1Label.TabIndex = 1;
            this.m_Player1Label.Text = "Player 1:";
            // 
            // m_Player1TextBox
            // 
            this.m_Player1TextBox.Location = new System.Drawing.Point(116, 36);
            this.m_Player1TextBox.Margin = new System.Windows.Forms.Padding(2);
            this.m_Player1TextBox.Name = "m_Player1TextBox";
            this.m_Player1TextBox.Size = new System.Drawing.Size(68, 20);
            this.m_Player1TextBox.TabIndex = 3;
            // 
            // m_Player2TextBox
            // 
            this.m_Player2TextBox.Enabled = false;
            this.m_Player2TextBox.Location = new System.Drawing.Point(116, 58);
            this.m_Player2TextBox.Margin = new System.Windows.Forms.Padding(2);
            this.m_Player2TextBox.Name = "m_Player2TextBox";
            this.m_Player2TextBox.Size = new System.Drawing.Size(68, 20);
            this.m_Player2TextBox.TabIndex = 4;
            this.m_Player2TextBox.Text = "Computer";
            // 
            // m_BoardSizeLabel
            // 
            this.m_BoardSizeLabel.AutoSize = true;
            this.m_BoardSizeLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.m_BoardSizeLabel.Location = new System.Drawing.Point(35, 130);
            this.m_BoardSizeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_BoardSizeLabel.Name = "m_BoardSizeLabel";
            this.m_BoardSizeLabel.Size = new System.Drawing.Size(61, 13);
            this.m_BoardSizeLabel.TabIndex = 6;
            this.m_BoardSizeLabel.Text = "Board Size:";
            // 
            // m_RowsUpDown
            // 
            this.m_RowsUpDown.Location = new System.Drawing.Point(79, 158);
            this.m_RowsUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.m_RowsUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_RowsUpDown.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.m_RowsUpDown.Name = "m_RowsUpDown";
            this.m_RowsUpDown.Size = new System.Drawing.Size(80, 20);
            this.m_RowsUpDown.TabIndex = 8;
            this.m_RowsUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.m_RowsUpDown.ValueChanged += new System.EventHandler(this.rowsUpDown_ValueChanged);
            // 
            // m_ColsUpDown
            // 
            this.m_ColsUpDown.Location = new System.Drawing.Point(265, 158);
            this.m_ColsUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.m_ColsUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_ColsUpDown.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.m_ColsUpDown.Name = "m_ColsUpDown";
            this.m_ColsUpDown.Size = new System.Drawing.Size(80, 20);
            this.m_ColsUpDown.TabIndex = 9;
            this.m_ColsUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.m_ColsUpDown.ValueChanged += new System.EventHandler(this.colsUpDown_ValueChanged);
            // 
            // m_RowsLabel
            // 
            this.m_RowsLabel.AutoSize = true;
            this.m_RowsLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.m_RowsLabel.Location = new System.Drawing.Point(35, 162);
            this.m_RowsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_RowsLabel.Name = "m_RowsLabel";
            this.m_RowsLabel.Size = new System.Drawing.Size(37, 13);
            this.m_RowsLabel.TabIndex = 10;
            this.m_RowsLabel.Text = "Rows:";
            // 
            // m_ColsLabel
            // 
            this.m_ColsLabel.AutoSize = true;
            this.m_ColsLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.m_ColsLabel.Location = new System.Drawing.Point(227, 159);
            this.m_ColsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_ColsLabel.Name = "m_ColsLabel";
            this.m_ColsLabel.Size = new System.Drawing.Size(30, 13);
            this.m_ColsLabel.TabIndex = 11;
            this.m_ColsLabel.Text = "Cols:";
            // 
            // m_Player2checkBox
            // 
            this.m_Player2checkBox.AutoSize = true;
            this.m_Player2checkBox.Location = new System.Drawing.Point(20, 62);
            this.m_Player2checkBox.Margin = new System.Windows.Forms.Padding(2);
            this.m_Player2checkBox.Name = "m_Player2checkBox";
            this.m_Player2checkBox.Size = new System.Drawing.Size(67, 17);
            this.m_Player2checkBox.TabIndex = 12;
            this.m_Player2checkBox.Text = "Player 2:";
            this.m_Player2checkBox.UseVisualStyleBackColor = true;
            this.m_Player2checkBox.CheckedChanged += new System.EventHandler(this.player2checkBox_CheckedChanged);
            // 
            // m_PlayersLabel
            // 
            this.m_PlayersLabel.AutoSize = true;
            this.m_PlayersLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.m_PlayersLabel.Location = new System.Drawing.Point(20, 19);
            this.m_PlayersLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_PlayersLabel.Name = "m_PlayersLabel";
            this.m_PlayersLabel.Size = new System.Drawing.Size(44, 13);
            this.m_PlayersLabel.TabIndex = 13;
            this.m_PlayersLabel.Text = "Players:";
            // 
            // GameSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 292);
            this.Controls.Add(this.m_PlayersLabel);
            this.Controls.Add(this.m_Player2checkBox);
            this.Controls.Add(this.m_ColsLabel);
            this.Controls.Add(this.m_RowsLabel);
            this.Controls.Add(this.m_ColsUpDown);
            this.Controls.Add(this.m_RowsUpDown);
            this.Controls.Add(this.m_BoardSizeLabel);
            this.Controls.Add(this.m_Player2TextBox);
            this.Controls.Add(this.m_Player1TextBox);
            this.Controls.Add(this.m_Player1Label);
            this.Controls.Add(this.m_GameStartButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettingsForm";
            this.Text = "Game Settings";
            ((System.ComponentModel.ISupportInitialize)(this.m_RowsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_ColsUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion



            }
}

