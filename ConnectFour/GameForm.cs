using ConnectFour.Logic;
using System.Numerics;

namespace ConnectFour
{
    public partial class GameForm
    {
        private const int CellSize = 72;
        private const int BoardLeft = 20;
        private const int BoardTop = 10;
        private const int DiscRadius = 26;

        private readonly GameEngine _engine;

        private bool _animating;
        private int _animCol;
        private int _animTargetRow;
        private float _animY;

        private int _hoverCol = -1;

        public GameForm(string player1Name, string player2Name)
        {
            InitializeComponent();

            // Включаем двойную буферизацию на уровне формы
            this.DoubleBuffered = true;

            var p1 = new Player(1, player1Name, PlayerColor.Red);
            var p2 = new Player(2, player2Name, PlayerColor.Yellow);
            _engine = new GameEngine(p1, p2);

            _engine.Start();
            UpdateStatus();
            UpdateScores();
        }

        // ── Отрисовка ────────────────────────────────────────────────────

        private void panelBoard_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            DrawHoverHighlight(g);
            DrawBoardBackground(g);
            DrawAllDiscs(g);

            if (_animating)
                DrawFallingDisc(g);
        }

        private void DrawHoverHighlight(Graphics g)
        {
            if (_hoverCol < 0 || _animating || _engine.Status != GameStatus.InProgress)
                return;

            int x = BoardLeft + _hoverCol * CellSize;
            using var b = new SolidBrush(Color.FromArgb(25, 255, 255, 255));
            g.FillRectangle(b, x, 0, CellSize, panelBoard.Height);

            int cx = x + CellSize / 2;
            Color arrowColor = _engine.CurrentPlayer.Color == PlayerColor.Red
                ? Color.FromArgb(248, 81, 73)
                : Color.FromArgb(255, 212, 59);
            using var ab = new SolidBrush(arrowColor);
            g.FillPolygon(ab, new Point[]
            {
                new(cx,      BoardTop - 6),
                new(cx - 10, BoardTop - 20),
                new(cx + 10, BoardTop - 20)
            });
        }

        private void DrawBoardBackground(Graphics g)
        {
            int bw = GameBoard.Columns * CellSize;
            int bh = GameBoard.Rows * CellSize;
            var boardRect = new Rectangle(BoardLeft - 8, BoardTop - 8, bw + 16, bh + 16);

            using var shadow = new SolidBrush(Color.FromArgb(60, 0, 0, 0));
            g.FillRectangle(shadow, boardRect.X + 4, boardRect.Y + 6, boardRect.Width, boardRect.Height);

            using var bg = new SolidBrush(Color.FromArgb(21, 52, 120));
            g.FillRectangle(bg, boardRect);

            for (int row = 0; row < GameBoard.Rows; row++)
                for (int col = 0; col < GameBoard.Columns; col++)
                {
                    int cx = BoardLeft + col * CellSize + CellSize / 2;
                    int cy = BoardTop + row * CellSize + CellSize / 2;
                    DrawEmptyCell(g, cx, cy);
                }
        }

        private static void DrawEmptyCell(Graphics g, int cx, int cy)
        {
            var r = new Rectangle(cx - DiscRadius, cy - DiscRadius, DiscRadius * 2, DiscRadius * 2);
            using var b = new SolidBrush(Color.FromArgb(10, 25, 65));
            g.FillEllipse(b, r);
            using var p = new Pen(Color.FromArgb(25, 55, 120), 1.5f);
            g.DrawEllipse(p, r);
        }

        private void DrawAllDiscs(Graphics g)
        {
            var winCells = _engine.LastWinResult?.WinningCells;

            for (int row = 0; row < GameBoard.Rows; row++)
                for (int col = 0; col < GameBoard.Columns; col++)
                {
                    int cell = _engine.Board.GetCell(row, col);
                    if (cell == 0) continue;
                    if (_animating && row == _animTargetRow && col == _animCol) continue;

                    int cx = BoardLeft + col * CellSize + CellSize / 2;
                    int cy = BoardTop + row * CellSize + CellSize / 2;
                    bool isWin = winCells != null && winCells.Any(wc => wc.Row == row && wc.Col == col);
                    DrawDisc(g, cx, cy, cell, isWin);
                }
        }

        private void DrawFallingDisc(Graphics g)
        {
            int cx = BoardLeft + _animCol * CellSize + CellSize / 2;
            int cy = (int)_animY;
            int id = _engine.Board.GetCell(_animTargetRow, _animCol);
            DrawDisc(g, cx, cy, id, false);
        }

        private static void DrawDisc(Graphics g, int cx, int cy, int playerId, bool isWin)
        {
            int r = DiscRadius;
            var rect = new Rectangle(cx - r, cy - r, r * 2, r * 2);

            using var sh = new SolidBrush(Color.FromArgb(70, 0, 0, 0));
            g.FillEllipse(sh, rect.X + 2, rect.Y + 4, rect.Width, rect.Height);

            Color top = playerId == 1 ? Color.FromArgb(248, 81, 73) : Color.FromArgb(255, 212, 59);
            Color bot = playerId == 1 ? Color.FromArgb(180, 40, 35) : Color.FromArgb(190, 150, 20);
            using var grad = new System.Drawing.Drawing2D.LinearGradientBrush(
                rect, top, bot,
                System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal);
            g.FillEllipse(grad, rect);

            if (isWin)
            {
                using var glow = new Pen(Color.FromArgb(63, 185, 80), 3.5f);
                g.DrawEllipse(glow, rect.X - 2, rect.Y - 2, rect.Width + 4, rect.Height + 4);
            }

            var shine = new Rectangle(cx - r + 5, cy - r + 5, r - 4, r - 4);
            using var sb = new System.Drawing.Drawing2D.LinearGradientBrush(
                shine,
                Color.FromArgb(110, 255, 255, 255),
                Color.FromArgb(0, 255, 255, 255),
                System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal);
            g.FillEllipse(sb, shine);
        }

        // ── Анимация ─────────────────────────────────────────────────────

        private void StartAnimation(int col, int targetRow)
        {
            _animating = true;
            _animCol = col;
            _animTargetRow = targetRow;
            _animY = BoardTop - CellSize;
            timerAnim.Start();
        }

        private void timerAnim_Tick(object sender, EventArgs e)
        {
            float targetY = BoardTop + _animTargetRow * CellSize + CellSize / 2f;
            float speed = Math.Max(10f, (targetY - _animY) * 0.38f);
            _animY += speed;

            if (_animY >= targetY)
            {
                _animY = targetY;
                _animating = false;
                timerAnim.Stop();
                panelBoard.Invalidate();
                panelBoard.Update();
                OnAnimationFinished();
                return;
            }
            panelBoard.Invalidate();
        }

        private void OnAnimationFinished()
        {
            UpdateStatus();
            UpdateScores();

            if (_engine.Status == GameStatus.Won)
            {
                string winner = _engine.GetPlayerById(_engine.LastWinResult!.WinnerId).Name;
                ShowGameOver($"🎉  {winner} победил!");
            }
            else if (_engine.Status == GameStatus.Draw)
            {
                ShowGameOver("🤝  Ничья!");
            }
        }

        // ── Мышь ─────────────────────────────────────────────────────────

        private void panelBoard_MouseMove(object sender, MouseEventArgs e)
        {
            if (_animating || _engine.Status != GameStatus.InProgress) return;
            int col = (e.X - BoardLeft) / CellSize;
            if (col < 0 || col >= GameBoard.Columns) col = -1;
            if (col != _hoverCol) { _hoverCol = col; panelBoard.Invalidate(); }
        }

        private void panelBoard_MouseLeave(object sender, EventArgs e)
        {
            _hoverCol = -1;
            panelBoard.Invalidate();
        }

        private void panelBoard_MouseClick(object sender, MouseEventArgs e)
        {
            if (_animating || _engine.Status != GameStatus.InProgress) return;

            int col = (e.X - BoardLeft) / CellSize;
            if (col < 0 || col >= GameBoard.Columns) return;

            var result = _engine.MakeMove(col);

            if (!result.Success)
            {
                MessageBox.Show(result.ErrorMessage, "Недопустимый ход",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            StartAnimation(col, result.LandedRow);
        }

        // ── Кнопки ───────────────────────────────────────────────────────

        private void btnRestart_Click(object sender, EventArgs e)
        {
            _animating = false;
            timerAnim.Stop();
            _hoverCol = -1;
            _engine.Start();
            UpdateStatus();
            UpdateScores();
            panelBoard.Invalidate();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (_engine.Status == GameStatus.InProgress && _engine.MoveCount > 0)
            {
                var res = MessageBox.Show(
                    "Вернуться в главное меню?\nТекущая игра будет потеряна.",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (res != DialogResult.Yes) return;
            }
            Close();
        }

        // ── Обновление UI ────────────────────────────────────────────────

        private void UpdateStatus()
        {
            lblStatus.Text = _engine.Status switch
            {
                GameStatus.InProgress => $"Ход: {_engine.CurrentPlayer.Name}",
                GameStatus.Won => $"Победитель: {_engine.GetPlayerById(_engine.LastWinResult!.WinnerId).Name}",
                GameStatus.Draw => "Ничья!",
                _ => string.Empty
            };

            lblStatus.ForeColor = _engine.Status switch
            {
                GameStatus.Won => Color.FromArgb(63, 185, 80),
                GameStatus.Draw => Color.FromArgb(210, 153, 34),
                _ => Color.FromArgb(230, 237, 243)
            };

            bool p1Active = _engine.Status == GameStatus.InProgress && _engine.CurrentPlayer == _engine.Player1;
            bool p2Active = _engine.Status == GameStatus.InProgress && _engine.CurrentPlayer == _engine.Player2;

            panelP1.BackColor = p1Active
                ? Color.FromArgb(50, 248, 81, 73)
                : Color.FromArgb(22, 27, 34);
            panelP2.BackColor = p2Active
                ? Color.FromArgb(50, 255, 212, 59)
                : Color.FromArgb(22, 27, 34);
        }

        private void UpdateScores()
        {
            lblP1Name.Text = _engine.Player1.Name;
            lblP1Wins.Text = $"Побед: {_engine.Player1.Wins}";
            lblP2Name.Text = _engine.Player2.Name;
            lblP2Wins.Text = $"Побед: {_engine.Player2.Wins}";
        }

        private void ShowGameOver(string message)
        {
            using var dlg = new GameOverForm(
                message,
                _engine.Player1.Name, _engine.Player1.Wins,
                _engine.Player2.Name, _engine.Player2.Wins);

            var result = dlg.ShowDialog(this);
            if (result == DialogResult.Yes)
                btnRestart_Click(null!, EventArgs.Empty);
            else
                Close();
        }
    }
}
