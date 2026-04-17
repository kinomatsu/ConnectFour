namespace ConnectFour
{
    partial class GameForm : System.Windows.Forms.Form
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
            components = new System.ComponentModel.Container();
            panelTop = new Panel();
            panelP2 = new Panel();
            lblP2Color = new Label();
            lblP2Name = new Label();
            lblP2Wins = new Label();
            lblStatus = new Label();
            panelP1 = new Panel();
            lblP1Color = new Label();
            lblP1Name = new Label();
            lblP1Wins = new Label();
            panelBoard = new DoubleBufferedPanel();
            panelBottom = new Panel();
            btnRestart = new Button();
            btnMenu = new Button();
            timerAnim = new System.Windows.Forms.Timer(components);
            panelTop.SuspendLayout();
            panelP2.SuspendLayout();
            panelP1.SuspendLayout();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(22, 27, 34);
            panelTop.Controls.Add(panelP2);
            panelTop.Controls.Add(lblStatus);
            panelTop.Controls.Add(panelP1);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(524, 100);
            panelTop.TabIndex = 0;
            // 
            // panelP2
            // 
            panelP2.BackColor = Color.FromArgb(22, 27, 34);
            panelP2.BorderStyle = BorderStyle.FixedSingle;
            panelP2.Controls.Add(lblP2Color);
            panelP2.Controls.Add(lblP2Name);
            panelP2.Controls.Add(lblP2Wins);
            panelP2.Location = new Point(364, 10);
            panelP2.Name = "panelP2";
            panelP2.Size = new Size(150, 78);
            panelP2.TabIndex = 2;
            // 
            // lblP2Color
            // 
            lblP2Color.AutoSize = true;
            lblP2Color.Font = new Font("Segoe UI", 18F);
            lblP2Color.ForeColor = Color.FromArgb(255, 212, 59);
            lblP2Color.Location = new Point(-1, 0);
            lblP2Color.Name = "lblP2Color";
            lblP2Color.Size = new Size(47, 32);
            lblP2Color.TabIndex = 0;
            lblP2Color.Text = "\U0001f7e1";
            // 
            // lblP2Name
            // 
            lblP2Name.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblP2Name.ForeColor = Color.FromArgb(230, 237, 243);
            lblP2Name.Location = new Point(85, 0);
            lblP2Name.Name = "lblP2Name";
            lblP2Name.Size = new Size(64, 22);
            lblP2Name.TabIndex = 1;
            lblP2Name.Text = "Игрок 2";
            // 
            // lblP2Wins
            // 
            lblP2Wins.AutoSize = true;
            lblP2Wins.Font = new Font("Segoe UI", 9F);
            lblP2Wins.ForeColor = Color.FromArgb(139, 148, 158);
            lblP2Wins.Location = new Point(95, 33);
            lblP2Wins.Name = "lblP2Wins";
            lblP2Wins.Size = new Size(54, 15);
            lblP2Wins.TabIndex = 2;
            lblP2Wins.Text = "Побед: 0";
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(230, 237, 243);
            lblStatus.Location = new Point(170, 10);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(184, 78);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Ход: Игрок 1";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelP1
            // 
            panelP1.BackColor = Color.FromArgb(22, 27, 34);
            panelP1.BorderStyle = BorderStyle.FixedSingle;
            panelP1.Controls.Add(lblP1Color);
            panelP1.Controls.Add(lblP1Name);
            panelP1.Controls.Add(lblP1Wins);
            panelP1.Location = new Point(10, 10);
            panelP1.Name = "panelP1";
            panelP1.Size = new Size(150, 78);
            panelP1.TabIndex = 0;
            // 
            // lblP1Color
            // 
            lblP1Color.AutoSize = true;
            lblP1Color.Font = new Font("Segoe UI", 18F);
            lblP1Color.ForeColor = Color.FromArgb(248, 81, 73);
            lblP1Color.Location = new Point(102, 0);
            lblP1Color.Name = "lblP1Color";
            lblP1Color.Size = new Size(47, 32);
            lblP1Color.TabIndex = 0;
            lblP1Color.Text = "🔴";
            // 
            // lblP1Name
            // 
            lblP1Name.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblP1Name.ForeColor = Color.FromArgb(230, 237, 243);
            lblP1Name.Location = new Point(-1, 0);
            lblP1Name.Name = "lblP1Name";
            lblP1Name.Size = new Size(67, 22);
            lblP1Name.TabIndex = 1;
            lblP1Name.Text = "Игрок 1";
            // 
            // lblP1Wins
            // 
            lblP1Wins.AutoSize = true;
            lblP1Wins.Font = new Font("Segoe UI", 9F);
            lblP1Wins.ForeColor = Color.FromArgb(139, 148, 158);
            lblP1Wins.Location = new Point(-1, 33);
            lblP1Wins.Name = "lblP1Wins";
            lblP1Wins.Size = new Size(54, 15);
            lblP1Wins.TabIndex = 2;
            lblP1Wins.Text = "Побед: 0";
            // 
            // panelBoard
            // 
            panelBoard.BackColor = Color.FromArgb(13, 17, 23);
            panelBoard.Location = new Point(0, 100);
            panelBoard.Name = "panelBoard";
            panelBoard.Size = new Size(524, 472);
            panelBoard.TabIndex = 1;
            panelBoard.Paint += panelBoard_Paint;
            panelBoard.MouseClick += panelBoard_MouseClick;
            panelBoard.MouseLeave += panelBoard_MouseLeave;
            panelBoard.MouseMove += panelBoard_MouseMove;
            // 
            // panelBottom
            // 
            panelBottom.BackColor = Color.FromArgb(22, 27, 34);
            panelBottom.Controls.Add(btnRestart);
            panelBottom.Controls.Add(btnMenu);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 572);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(524, 56);
            panelBottom.TabIndex = 2;
            // 
            // btnRestart
            // 
            btnRestart.BackColor = Color.FromArgb(88, 166, 255);
            btnRestart.FlatAppearance.BorderSize = 0;
            btnRestart.FlatStyle = FlatStyle.Flat;
            btnRestart.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRestart.ForeColor = Color.FromArgb(13, 17, 23);
            btnRestart.Location = new Point(12, 10);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(160, 36);
            btnRestart.TabIndex = 0;
            btnRestart.Text = "↺  Новая игра";
            btnRestart.UseVisualStyleBackColor = false;
            btnRestart.Click += btnRestart_Click;
            // 
            // btnMenu
            // 
            btnMenu.BackColor = Color.FromArgb(33, 38, 47);
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.Font = new Font("Segoe UI", 10F);
            btnMenu.ForeColor = Color.FromArgb(139, 148, 158);
            btnMenu.Location = new Point(184, 10);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(130, 36);
            btnMenu.TabIndex = 1;
            btnMenu.Text = "← Меню";
            btnMenu.UseVisualStyleBackColor = false;
            btnMenu.Click += btnMenu_Click;
            // 
            // timerAnim
            // 
            timerAnim.Interval = 16;
            timerAnim.Tick += timerAnim_Tick;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(13, 17, 23);
            ClientSize = new Size(524, 628);
            Controls.Add(panelBoard);
            Controls.Add(panelTop);
            Controls.Add(panelBottom);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "GameForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Connect Four — Игра";
            panelTop.ResumeLayout(false);
            panelP2.ResumeLayout(false);
            panelP2.PerformLayout();
            panelP1.ResumeLayout(false);
            panelP1.PerformLayout();
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelP1;
        private System.Windows.Forms.Label lblP1Color;
        private System.Windows.Forms.Label lblP1Name;
        private System.Windows.Forms.Label lblP1Wins;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel panelP2;
        private System.Windows.Forms.Label lblP2Color;
        private System.Windows.Forms.Label lblP2Name;
        private System.Windows.Forms.Label lblP2Wins;
        private DoubleBufferedPanel panelBoard;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Timer timerAnim;
    }

    /// <summary>
    /// Panel с включённой двойной буферизацией — устраняет мерцание при перерисовке.
    /// </summary>
    internal class DoubleBufferedPanel : System.Windows.Forms.Panel
    {
        public DoubleBufferedPanel()
        {
            SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true);
            UpdateStyles();
        }
    }
}
