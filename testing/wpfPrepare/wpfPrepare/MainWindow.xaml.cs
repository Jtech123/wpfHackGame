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
using System.Windows.Markup;

namespace wpfPrepare
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtCode.AppendText("using System;\nusing System.Collections.Generic;\nusing System.Linq;\nusing System.Text;\nusing System.Threading.Tasks;\nnamespace myNamespace\n{\n\tclass myProgram\n\t{\n\t\tstatic void Main()\n\t\t{\n\t\t\tint num1;\n\t\t\tint num2;\n\t\t\tint num3;\n\t\t\tstring input;\n\t\t\tConsole.WriteLine(\"Welcome to this calculator.\");\n\t\t\tConsole.WriteLine(\"Please enter your first number:\");\n\t\t\tinput = Console.ReadLine();\n\t\t\tInt32.TryParse(input, out num1);\n\t\t\tConsole.WriteLine(\"Please enter your second number\");\n\t\t\tinput = Console.ReadLine();\n\t\t\tInt32.TryParse(input, out num2);\n\t\t\tnum3 = num1 + num2;\n\t\t\tConsole.WriteLine(\"{0} + {1} = {2}\", num1, num2, num3);\n\t\t\tConsole.ReadKey();\n\t\t}\n\t}\n}");
        }

        private void InsertStyle(string[] words)
        {

        }
    }
}
