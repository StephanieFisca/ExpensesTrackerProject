using ExpensesTracker.Repositories;
using ExpensesTracker.RepositoryPattern.Interfaces;
using System;
using System.Data.SqlClient;
using System.Drawing; // Add this namespace for Color
using System.Windows.Forms; // Add this namespace for Form
using Timer = System.Windows.Forms.Timer;

namespace ExpensesTracker
{
    public partial class Splash : Form
    {
        private const int TimerInterval = 100; // Timer interval in milliseconds
        private const int ProgressBarStep = 1; // Progress bar step value
        public ProgressBar MyProgressBar { get; }

        private readonly IUserRepository _userRepository;

        public Splash(IUserRepository userRepository)
        {
            InitializeComponent();
            _userRepository = userRepository;
            MyProgressBar = MyProgress;
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            Timer timer = new Timer();
            timer.Interval = TimerInterval;
            timer.Tick += Timer1_Tick;
            timer.Start();
        }

        public void Timer1_Tick(object sender, EventArgs e)
        {
            if (MyProgress.Value < MyProgress.Maximum)
            {
                MyProgress.Value += ProgressBarStep;
                PercentageLbl.Text = MyProgress.Value + "%";
            }

            if (MyProgress.Value >= 100)
            {
                ((Timer)sender).Stop();
                ShowLoginForm();
            }
        }


        private void ShowLoginForm()
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=ST-ASUS;Initial Catalog=ExpensesDb;Integrated Security=True");
            Login login = new Login(_userRepository);
            login.Show();
            this.Hide();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            InitializeTimer();
        }
    }
}
