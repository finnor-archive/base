namespace MinesweeperDesktop
{
    partial class MinesweeperForm
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
            this.NewGameBtn = new System.Windows.Forms.Button();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // NewGameBtn
            // 
            this.NewGameBtn.Location = new System.Drawing.Point(256, 22);
            this.NewGameBtn.Name = "NewGameBtn";
            this.NewGameBtn.Size = new System.Drawing.Size(75, 23);
            this.NewGameBtn.TabIndex = 0;
            this.NewGameBtn.Text = "New Game";
            this.NewGameBtn.UseVisualStyleBackColor = true;
            this.NewGameBtn.Click += new System.EventHandler(this.NewGameBtn_Click);
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Location = new System.Drawing.Point(9, 61);
            this.ButtonPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(600, 320);
            this.ButtonPanel.TabIndex = 1;
            // 
            // MinesweeperForm
            // 
            this.ClientSize = new System.Drawing.Size(620, 400);
            this.Controls.Add(this.ButtonPanel);
            this.Controls.Add(this.NewGameBtn);
            this.Name = "MinesweeperForm";
            this.Load += new System.EventHandler(this.Minesweeper_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NewGameBtn;
        private System.Windows.Forms.Panel ButtonPanel;


    }
}

