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
using System.Windows.Shapes;

namespace wpftesting
{
    /// <summary>
    /// Interaction logic for MsgBox.xaml
    /// </summary>
    public partial class MsgBox : Window
    {
        private string title;
        private string message;
        public bool resultOk;
        public bool resultCancel;

        public MsgBox( string title, string message)
        {
            InitializeComponent();
            this.title = title;
            this.message = message;
            this.resultOk = false;
            this.resultCancel = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblTitle.Content = this.title;
            txtboxMessage.Text = this.message;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.resultOk = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.resultCancel = true;
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }
    }
}
