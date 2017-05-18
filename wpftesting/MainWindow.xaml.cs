using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpftesting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string username;
        private string password;

        private MsgHandler msgHandler;
        private DatabaseHandler dbh;

        public MainWindow()
        {
            InitializeComponent();
            this.msgHandler = new MsgHandler();
        }



        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            this.username = txtUsername.Text;
            this.password = txtPassword.Password;

            try
            {
                if (dbh.IsConnect())
                {
                    //suppose col0 and col1 are defined as VARCHAR in the DB
                    string query = "SELECT username, password FROM tbl_users WHERE username=@username";
                    MySqlCommand cmd = new MySqlCommand(query, dbh.Connection);
                    cmd.Parameters.AddWithValue("@username", this.username);
                    cmd.Prepare();

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        MessageBox.Show("The username and/or password is invalid.");
                        txtUsername.Text = "";
                        txtPassword.Password = "";
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            if (validate(reader.GetString(1)))
                            {
                                //statusWindow stats = new statusWindow();
                                //MainMenu mm = new MainMenu();
                                //mm.Show();
                                //stats.Show();
                                //this.Hide();
                                /*MsgBox msg = new MsgBox("Logged In", "You are now logged in!");
                                msg.ShowDialog();*/
                                Desktop dk = new Desktop(txtUsername.Text);
                                dk.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("The username and/or password is invalid.");
                                txtUsername.Text = "";
                                txtPassword.Password = "";
                            }
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                this.msgHandler.CreateMessage("Connection Error", ex.ToString());

                if (msgHandler.IsAgreed())
                {
                    dbh.ResetConn();
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dbh = new DatabaseHandler();
                dbh.IsConnect();

                //this.msgHandler.CreateMessage("Connected", "We are notifying that you have been connected to the database!");
            }
            catch
            {
                dbh.ResetConn();
            }
        }

        private bool validate(string pass)
        {
            bool checkPass = CryptSharp.BlowfishCrypter.CheckPassword(this.password, pass);
            return checkPass;
        }
    }
}
