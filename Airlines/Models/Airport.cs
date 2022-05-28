using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlines.Models
{
    // клас Аеропорт
    public class Airport
    {
        public int Id { get; set; }

        // назва аеропорту
        public string Name { get; set; }

        // список літаків
        public virtual ICollection<Plane> Planes { get; set; }
        // список польотів
        public virtual ICollection<Flight> Flights { get; set; }
        // список квитків
        public virtual ICollection<Ticket> Tickets { get; set; }

        // конструктор за замовчуванням
        public Airport()
        {
            Planes = new List<Plane>();
            Flights = new List<Flight>();
            Tickets = new List<Ticket>();
        }
    }
}
