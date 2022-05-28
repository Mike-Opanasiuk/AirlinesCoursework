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
    /// Interaction logic for FlightsBetweenTownsWindow.xaml
    /// </summary>
    public partial class FlightsBetweenTownsWindow : Window
    {
        public FlightsBetweenTownsWindow()
        {
            InitializeComponent();
        }
        public string StartTown { get; set; }
        public string DestinationTown { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbStartTown.Text) || string.IsNullOrEmpty(tbDestination.Text) || dpStartDate.SelectedDate == null || dpEndDate.SelectedDate == null)
            {
                MessageBox.Show("Заповніть усі поля!");
                return;
            }
            StartTown = tbStartTown.Text;
            DestinationTown = tbDestination.Text;

            StartDate = (DateTime)dpStartDate.SelectedDate;
            EndDate = (DateTime)dpEndDate.SelectedDate;

            DialogResult = true;

            Close();
        }
    }
}
