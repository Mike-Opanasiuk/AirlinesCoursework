using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlines.Models
{
    // клас Авіалінія
    public class Airline
    {
        // ідентифікатор
        public int Id { get; set; }

        // назва
        public string Name { get; set; }

        // список аеропортів, що входять до авіаліній
        public virtual ICollection<Airport> Airports { get; set; }

        // конструктор за замовчуванням
        public Airline()
        {
            Airports = new List<Airport>();
        }

        // метод для отримання усіх польотів
        public List<Flight> GetAllFlights()
        {
            var flights = new List<Flight>();
            foreach (var a in Airports)
            {
                foreach (var fl in a.Flights)
                {
                    flights.Add(fl);
                }
            }
            return flights;
        }

        // метод для отримання польотів між містами по даті
        public List<Flight> GetFlightsBetweenTownsByDate(string startTown, string destinationTown, DateTime startDate, DateTime endDate)
        {
            var flights = new List<Flight>();
            foreach (var a in Airports)
            {
                foreach (var f in a.Flights)
                {
                    if (f.StartTown == startTown &&
                       f.DestinationTown == destinationTown &&
                       f.Date >= startDate &&
                       f.Date <= endDate)
                    {
                        flights.Add(f);
                    }
                }
            }
            return flights;
        }

        // отримання квитків по номеру польота
        public List<Ticket> GetTicketsByFlightNumber(string number)
        {
            List<Ticket> tickets = new List<Ticket>();
            foreach (var a in Airports)
            {
                foreach (var t in a.Tickets)
                {
                    if (t.Flight.Number == number)
                        tickets.Add(t);
                }
            }
            return tickets;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
