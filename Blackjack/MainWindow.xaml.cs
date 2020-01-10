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

namespace Blackjack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<People> peoples;
        public MainWindow()
        {
            InitializeComponent();
            peoples = new List<People>();
            peoples.Add(new People { FirstName = "Jordan", LastName = "Franklin" });
            peoples.Add(new People { FirstName = "Matt", LastName = "Myers" });
            peoples.Add(new People { FirstName = "Nick", LastName = "Nova" });
            myComboBox.ItemsSource=peoples;
        }


    }
    public class People
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
