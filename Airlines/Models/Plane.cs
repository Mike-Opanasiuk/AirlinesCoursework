using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlines.Models
{
    // клас Літак
    public class Plane
    {
        // унікальний ідентифікатор
        public int Id { get; set; }

        // конструктор за замовчуванням
        public Plane()
        {
            Flights = new List<Flight>();
        }
        // конструктор з параметрами
        public Plane(string model, int placesCount, List<Flight> flights = null)
        {
            Model = model;
            PlacesCount = placesCount;
            if (flights != null)
                Flights = flights;
            else Flights = new List<Flight>();
        }

        // модель літака
        public string Model { get; set; }

        // кількість посадочних місць
        public int PlacesCount { get; set; }

        // список польотів
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
