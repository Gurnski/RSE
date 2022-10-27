namespace RSE
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test: " + Functions.XorString("Test") + " Test2: " + Functions.XorString(Functions.XorString("Test")));
        }
    }
}