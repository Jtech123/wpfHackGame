using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace wpftesting
{
    /// <summary>
    /// Interaction logic for Desktop.xaml
    /// </summary>
    public partial class Desktop : Window
    {
        private DispatcherTimer timer;
        private DatabaseHandler dbh;
        private string username;

        public Desktop(string username)
        {
            this.username = username;
            InitializeComponent();
            dbh = new DatabaseHandler();
            DateTime now = DateTime.Now;
            lblTime.Content = now.ToString();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
            CheckIfAdmin();
        }

        private void CheckIfAdmin()
        {
            DataTable dt = dbh.Select("SELECT * FROM tbl_users WHERE username='" + username + "' AND rights >= 10", "isAdmin");
            if (dt.Rows.Count == 1)
            {
                btnAdmin.Visibility = Visibility.Visible;
            }
            else
            {
                btnAdmin = null;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            /*====clock=========*/
            DateTime now = DateTime.Now;
            lblTime.Content = now.ToString();
        }

        private void DesktopForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                Environment.Exit(0);
            }
            catch { }
        }

        private void btnShutDown_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBrowser_Click(object sender, RoutedEventArgs e)
        {
            Browser br = new Browser();
            br.Show();
        }
    }
}
