using Airlines.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Airlines
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Flight> flights;
        private readonly Airline airline;
        public MainWindow(Airline airline)
        {
            InitializeComponent();
            flights = airline.GetAllFlights();
            this.airline = airline;
        }

        private void btnViewAllFlights_Click(object sender, RoutedEventArgs e)
        {
            loadFlights(flights);
        }

        private void btnViewDelayedFlights_Click(object sender, RoutedEventArgs e)
        {
            loadFlights(flights.Where(f => f.IsDelayed).ToList());
        }

        private void btnViewFlightsBetweenTowns_Click(object sender, RoutedEventArgs e)
        {
            FlightsBetweenTownsWindow window = new FlightsBetweenTownsWindow();
            if (window.ShowDialog() != true)
                return;
            var foundFlights = flights.Where(f =>
            f.StartTown == window.StartTown &&
            f.DestinationTown == window.DestinationTown &&
            f.Date >= window.StartDate &&
            f.Date <= window.EndDate);
            if (foundFlights.Count() == 0)
            {
                MessageBox.Show("На жаль, немає наявних польотів");
                return;
            }
            loadFlights(foundFlights.ToList());
        }

        private void btnGetDelayTime_Click(object sender, RoutedEventArgs e)
        {
            if (lbFlights.SelectedItem == null)
            {
                MessageBox.Show("Виберіть політ!");
                return;
            }
            var selectedFlight = lbFlights.SelectedItem as Flight;
            if (!selectedFlight.IsDelayed)
            {
                MessageBox.Show("Вибраний політ не затримано");
                return;
            }
            MessageBox.Show("Політ #" + selectedFlight.Number + " був затриманий з " + selectedFlight.Date + " до " + selectedFlight.Date.Add(selectedFlight.Delay.DelayTime));

        }

        private void btnFindFlightsByCloseDate_Click(object sender, RoutedEventArgs e)
        {
            string dateStr = Interaction.InputBox("Пошук польотів по даті закриття", "Введіть дату: ", DateTime.Now.ToString());
            if (!DateTime.TryParse(dateStr, out DateTime date))
            {
                MessageBox.Show("Некоректний формат дати!");
                return;
            }

            var foundFlights = flights.Where(f => f.CloseTime >= date);
            if (foundFlights.Count() == 0)
            {
                MessageBox.Show("Польотів не було знайдено");
                return;
            }

            loadFlights(foundFlights.ToList());
        }

        private void btnGetTicketPrice_Click(object sender, RoutedEventArgs e)
        {
            if (lbFlights.SelectedIndex == -1)
            {
                MessageBox.Show("Виберіть політ!");
                return;
            }

            var flight = lbFlights.SelectedItem as Flight;
            var foundTickets = airline.GetTicketsByFlightNumber(flight.Number);
            if (foundTickets.Count() == 0)
            {
                MessageBox.Show($"На жаль, немає квитків на {flight.Number} політ");
                return;
            }
            string data = $"Наявно {foundTickets.Count()} квитків для {flight.Number} польоту\r\n";

            data += $"{"Клас",-15}{"Ціна",-7}\r\n";

            foreach (var t in foundTickets)
            {
                data += $"{(t is StandartTicket ? "Стандарт" : "Бізнес"), -15}{t.Price,-7}$\r\n";
            }
            MessageBox.Show(data);
        }

        private void lbFlights_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbFlights.SelectedIndex == -1)
                return;
            var flight = lbFlights.SelectedItem as Flight;
            loadFlight(flight);
        }

        private void loadFlight(Flight flight)
        {
            tbSelectedFlightNumber.Text = flight.Number;
            tbSelectedFlightStartTown.Text = flight.StartTown;
            tbSelectedFlightDestinationTown.Text = flight.DestinationTown;
            tbSelectedFlightDate.Text = flight.Date.ToShortDateString();
            tbSelectedFlightIsDelayedStr.Text = flight.IsDelayed ? "ЗАТРИМАНО" : "НА ЛІНІЇ";
            tbSelectedFlightPlane.Text = flight.Plane.Model;
        }

        private void loadFlights(List<Flight> flights)
        {
            lbFlights.Items.Clear();
            foreach (var item in flights)
            {
                lbFlights.Items.Add(item);
                loadFlight(item);
            }
            if (flights.Count != 0)
                lbFlights.SelectedIndex = 0;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadFlights(flights);
        }
    }
}
