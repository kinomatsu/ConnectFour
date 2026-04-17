namespace ConnectFour
{
    partial class GameOverForm : System.Windows.Forms.Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblResult = new System.Windows.Forms.Label();
            this.panelScore = new System.Windows.Forms.Panel();
            this.lblScore = new System.Windows.Forms.Label();
            this.btnPlayAgain = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.panelScore.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = false;
            this.lblResult.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblResult.ForeColor = System.Drawing.Color.FromArgb(63, 185, 80);
            this.lblResult.Location = new System.Drawing.Point(0, 20);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(420, 50);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "Победитель!";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelScore
            // 
            this.panelScore.BackColor = System.Drawing.Color.FromArgb(33, 38, 47);
            this.panelScore.Controls.Add(this.lblScore);
            this.panelScore.Location = new System.Drawing.Point(20, 82);
            this.panelScore.Name = "panelScore";
            this.panelScore.Size = new System.Drawing.Size(380, 60);
            this.panelScore.TabIndex = 1;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = false;
            this.lblScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScore.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblScore.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(380, 60);
            this.lblScore.TabIndex = 0;
            this.lblScore.Text = "Игрок 1  0 : 0  Игрок 2";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPlayAgain
            // 
            this.btnPlayAgain.BackColor = System.Drawing.Color.FromArgb(88, 166, 255);
            this.btnPlayAgain.FlatAppearance.BorderSize = 0;
            this.btnPlayAgain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayAgain.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPlayAgain.ForeColor = System.Drawing.Color.FromArgb(13, 17, 23);
            this.btnPlayAgain.Location = new System.Drawing.Point(50, 168);
            this.btnPlayAgain.Name = "btnPlayAgain";
            this.btnPlayAgain.Size = new System.Drawing.Size(150, 40);
            this.btnPlayAgain.TabIndex = 2;
            this.btnPlayAgain.Text = "▶  Ещё раз";
            this.btnPlayAgain.UseVisualStyleBackColor = false;
            this.btnPlayAgain.Click += new System.EventHandler(this.btnPlayAgain_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.FromArgb(33, 38, 47);
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMenu.ForeColor = System.Drawing.Color.FromArgb(139, 148, 158);
            this.btnMenu.Location = new System.Drawing.Point(220, 168);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(150, 40);
            this.btnMenu.TabIndex = 3;
            this.btnMenu.Text = "← В меню";
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // GameOverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(22, 27, 34);
            this.ClientSize = new System.Drawing.Size(420, 230);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.panelScore);
            this.Controls.Add(this.btnPlayAgain);
            this.Controls.Add(this.btnMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameOverForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Игра окончена";
            this.panelScore.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Panel panelScore;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Button btnPlayAgain;
        private System.Windows.Forms.Button btnMenu;
    }
}
