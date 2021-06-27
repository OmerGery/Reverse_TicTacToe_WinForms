namespace __B21_Ex02_UI
{
    public partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.m_Player1Label = new System.Windows.Forms.Label();
            this.m_Player2Label = new System.Windows.Forms.Label();
            this.m_Player1ScoreBoard = new System.Windows.Forms.Label();
            this.m_Player2ScoreBoard = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_Player1Label
            // 
            this.m_Player1Label.AutoSize = true;
            this.m_Player1Label.Location = new System.Drawing.Point(139, 368);
            this.m_Player1Label.Name = "m_Player1Label";
            this.m_Player1Label.Size = new System.Drawing.Size(65, 20);
            this.m_Player1Label.TabIndex = 0;
            this.m_Player1Label.Text = "Player1:";
            // 
            // m_Player2Label
            // 
            this.m_Player2Label.AutoSize = true;
            this.m_Player2Label.Location = new System.Drawing.Point(480, 368);
            this.m_Player2Label.Name = "m_Player2Label";
            this.m_Player2Label.Size = new System.Drawing.Size(65, 20);
            this.m_Player2Label.TabIndex = 1;
            this.m_Player2Label.Text = "Player2:";
            // 
            // m_Player1ScoreBoard
            // 
            this.m_Player1ScoreBoard.AutoSize = true;
            this.m_Player1ScoreBoard.Location = new System.Drawing.Point(222, 368);
            this.m_Player1ScoreBoard.Name = "m_Player1ScoreBoard";
            this.m_Player1ScoreBoard.Size = new System.Drawing.Size(18, 20);
            this.m_Player1ScoreBoard.TabIndex = 2;
            this.m_Player1ScoreBoard.Text = "0";
            // 
            // m_Player2ScoreBoard
            // 
            this.m_Player2ScoreBoard.AutoSize = true;
            this.m_Player2ScoreBoard.Location = new System.Drawing.Point(568, 368);
            this.m_Player2ScoreBoard.Name = "m_Player2ScoreBoard";
            this.m_Player2ScoreBoard.Size = new System.Drawing.Size(18, 20);
            this.m_Player2ScoreBoard.TabIndex = 3;
            this.m_Player2ScoreBoard.Text = "0";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 498);
            this.Controls.Add(this.m_Player2ScoreBoard);
            this.Controls.Add(this.m_Player1ScoreBoard);
            this.Controls.Add(this.m_Player2Label);
            this.Controls.Add(this.m_Player1Label);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameForm";
            this.Text = "ReverseTicTacToe";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label m_Player1Label;
        private System.Windows.Forms.Label m_Player2Label;
        private System.Windows.Forms.Label m_Player1ScoreBoard;
        private System.Windows.Forms.Label m_Player2ScoreBoard;

        #endregion

        public System.Windows.Forms.Label Player1Label
        {
            get
            {
                return m_Player1Label;
            }
        }

        public System.Windows.Forms.Label Player2Label
        {
            get
            {
                return m_Player2Label;
            }
        }

        public System.Windows.Forms.Label Player1ScoreBoard
        {
            get
            {
                return m_Player1ScoreBoard;
            }
        }

        public System.Windows.Forms.Label Player2ScoreBoard
        {
            get
            {
                return m_Player2ScoreBoard;
            }
        }
    }
}