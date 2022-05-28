using Airlines.Models;
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

namespace Airlines
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        private IEnumerable<Airline> airlines;

        public StartWindow()
        {
            InitializeComponent();
            airlines = new ApplicationDbContext().Airlines;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var index = lbAirlines.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("Виберіть авіалінії!");
                return;
            }
            MainWindow mw = new MainWindow(airlines.ElementAt(index));
            mw.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in airlines)
            {
                lbAirlines.Items.Add(item);
            }
            if (lbAirlines.Items.Count != 0)
                lbAirlines.SelectedIndex = 0;
        }
    }
}
