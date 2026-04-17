namespace ConnectFour
{
    public partial class GameOverForm
    {
        public GameOverForm(string resultText,
            string p1Name, int p1Wins,
            string p2Name, int p2Wins)
        {
            InitializeComponent();

            lblResult.Text = resultText;
            lblScore.Text = $"{p1Name}   {p1Wins}  :  {p2Wins}   {p2Name}";
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}
