using ConnectFour.Logic;

namespace ConnectFour
{
    public partial class MainMenuForm
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            string name1 = txtPlayer1.Text.Trim();
            string name2 = txtPlayer2.Text.Trim();

            lblError.Text = string.Empty;

            if (string.IsNullOrWhiteSpace(name1))
            {
                lblError.Text = "Введите имя Игрока 1.";
                txtPlayer1.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(name2))
            {
                lblError.Text = "Введите имя Игрока 2.";
                txtPlayer2.Focus();
                return;
            }

            if (name1.Length > 20 || name2.Length > 20)
            {
                lblError.Text = "Имя не должно превышать 20 символов.";
                return;
            }

            if (name1.Equals(name2, StringComparison.OrdinalIgnoreCase))
            {
                lblError.Text = "Имена игроков должны отличаться.";
                txtPlayer2.Focus();
                return;
            }

            var gameForm = new GameForm(name1, name2);
            gameForm.FormClosed += (_, _) => this.Show();
            this.Hide();
            gameForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
