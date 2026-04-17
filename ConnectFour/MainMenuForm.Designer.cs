namespace ConnectFour
{
    partial class MainMenuForm : System.Windows.Forms.Form
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelCard = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.txtPlayer2 = new System.Windows.Forms.TextBox();
            this.lblPlayer2 = new System.Windows.Forms.Label();
            this.txtPlayer1 = new System.Windows.Forms.TextBox();
            this.lblPlayer1 = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblFour = new System.Windows.Forms.Label();
            this.lblConnect = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelCard.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(13, 17, 23);
            this.panelMain.Controls.Add(this.panelCard);
            this.panelMain.Controls.Add(this.panelTop);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(480, 640);
            this.panelMain.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Transparent;
            this.panelTop.Controls.Add(this.lblFour);
            this.panelTop.Controls.Add(this.lblConnect);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(480, 160);
            this.panelTop.TabIndex = 0;
            // 
            // lblConnect
            // 
            this.lblConnect.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblConnect.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
            this.lblConnect.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblConnect.Location = new System.Drawing.Point(0, 0);
            this.lblConnect.Name = "lblConnect";
            this.lblConnect.Size = new System.Drawing.Size(480, 80);
            this.lblConnect.TabIndex = 0;
            this.lblConnect.Text = "CONNECT";
            this.lblConnect.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblFour
            // 
            this.lblFour.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblFour.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
            this.lblFour.ForeColor = System.Drawing.Color.FromArgb(88, 166, 255);
            this.lblFour.Location = new System.Drawing.Point(0, 100);
            this.lblFour.Name = "lblFour";
            this.lblFour.Size = new System.Drawing.Size(480, 60);
            this.lblFour.TabIndex = 1;
            this.lblFour.Text = "FOUR";
            this.lblFour.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelCard
            // 
            this.panelCard.BackColor = System.Drawing.Color.FromArgb(22, 27, 34);
            this.panelCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCard.Controls.Add(this.btnExit);
            this.panelCard.Controls.Add(this.btnPlay);
            this.panelCard.Controls.Add(this.lblError);
            this.panelCard.Controls.Add(this.txtPlayer2);
            this.panelCard.Controls.Add(this.lblPlayer2);
            this.panelCard.Controls.Add(this.txtPlayer1);
            this.panelCard.Controls.Add(this.lblPlayer1);
            this.panelCard.Location = new System.Drawing.Point(50, 170);
            this.panelCard.Name = "panelCard";
            this.panelCard.Padding = new System.Windows.Forms.Padding(28);
            this.panelCard.Size = new System.Drawing.Size(380, 400);
            this.panelCard.TabIndex = 1;
            // 
            // lblPlayer1
            // 
            this.lblPlayer1.AutoSize = true;
            this.lblPlayer1.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayer1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPlayer1.ForeColor = System.Drawing.Color.FromArgb(139, 148, 158);
            this.lblPlayer1.Location = new System.Drawing.Point(28, 28);
            this.lblPlayer1.Name = "lblPlayer1";
            this.lblPlayer1.Size = new System.Drawing.Size(120, 15);
            this.lblPlayer1.TabIndex = 0;
            this.lblPlayer1.Text = "Имя Игрока 1  🔴";
            // 
            // txtPlayer1
            // 
            this.txtPlayer1.BackColor = System.Drawing.Color.FromArgb(33, 38, 47);
            this.txtPlayer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlayer1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPlayer1.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.txtPlayer1.Location = new System.Drawing.Point(28, 50);
            this.txtPlayer1.MaxLength = 20;
            this.txtPlayer1.Name = "txtPlayer1";
            this.txtPlayer1.Size = new System.Drawing.Size(320, 27);
            this.txtPlayer1.TabIndex = 1;
            this.txtPlayer1.Text = "Игрок 1";
            // 
            // lblPlayer2
            // 
            this.lblPlayer2.AutoSize = true;
            this.lblPlayer2.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayer2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPlayer2.ForeColor = System.Drawing.Color.FromArgb(139, 148, 158);
            this.lblPlayer2.Location = new System.Drawing.Point(28, 100);
            this.lblPlayer2.Name = "lblPlayer2";
            this.lblPlayer2.Size = new System.Drawing.Size(120, 15);
            this.lblPlayer2.TabIndex = 2;
            this.lblPlayer2.Text = "Имя Игрока 2  🟡";
            // 
            // txtPlayer2
            // 
            this.txtPlayer2.BackColor = System.Drawing.Color.FromArgb(33, 38, 47);
            this.txtPlayer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlayer2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPlayer2.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.txtPlayer2.Location = new System.Drawing.Point(28, 122);
            this.txtPlayer2.MaxLength = 20;
            this.txtPlayer2.Name = "txtPlayer2";
            this.txtPlayer2.Size = new System.Drawing.Size(320, 27);
            this.txtPlayer2.TabIndex = 3;
            this.txtPlayer2.Text = "Игрок 2";
            // 
            // lblError
            // 
            this.lblError.AutoSize = false;
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(248, 81, 73);
            this.lblError.Location = new System.Drawing.Point(28, 162);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(320, 28);
            this.lblError.TabIndex = 4;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.FromArgb(88, 166, 255);
            this.btnPlay.FlatAppearance.BorderSize = 0;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnPlay.ForeColor = System.Drawing.Color.FromArgb(13, 17, 23);
            this.btnPlay.Location = new System.Drawing.Point(28, 200);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(320, 46);
            this.btnPlay.TabIndex = 5;
            this.btnPlay.Text = "▶   Начать игру";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(33, 38, 47);
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(139, 148, 158);
            this.btnExit.Location = new System.Drawing.Point(28, 258);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(320, 38);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblTitle
            // 
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(0, 0);
            // 
            // lblSubtitle
            // 
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(0, 0);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(13, 17, 23);
            this.ClientSize = new System.Drawing.Size(480, 640);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect Four";
            this.panelMain.ResumeLayout(false);
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblConnect;
        private System.Windows.Forms.Label lblFour;
        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.TextBox txtPlayer1;
        private System.Windows.Forms.Label lblPlayer2;
        private System.Windows.Forms.TextBox txtPlayer2;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
    }
}
