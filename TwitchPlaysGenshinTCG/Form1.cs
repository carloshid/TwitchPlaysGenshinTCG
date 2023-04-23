namespace TwitchPlaysGenshinTCG
{
    public partial class Form1 : Form
    {
        private Thread twitchThread;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            twitchThread = new Thread(new ThreadStart(Program.StartTwitchClient));
            twitchThread.Start();

            //this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                // Close the application
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TwitchChatClient.stop = true;
        }
    }
}