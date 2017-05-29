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
    /// Interaction logic for Store.xaml
    /// </summary>
    public partial class Store : Window
    {
        MsgHandler msgHandler;
        
        public Store()
        {
            this.msgHandler = new MsgHandler();
            InitializeComponent();
            List<User> items = new List<User>();
            List<Software> items2 = new List<Software>();
            items.Add(new User() { Name = "John Doe", Age = 42, Mail = "john@doe-family.com" });
            items.Add(new User() { Name = "Jane Doe", Age = 39, Mail = "jane@doe-family.com" });
            items.Add(new User() { Name = "Sammy Doe", Age = 7, Mail = "sammy.doe@gmail.com" });
            items2.Add(new Software() { Name = "test", Price = 10, Sold = 2, Made_By = "Jtech" });
            lvUsers.ItemsSource = items2;
        }

        public class User
        {
            public string Name { get; set; }

            public int Age { get; set; }

            public string Mail { get; set; }
        }

        

        private void lvUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            msgHandler.CreateMessage("test", lvUsers.Items.CurrentItem.ToString());
        }
    }
}
