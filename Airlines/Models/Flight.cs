using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlines.Models
{
    // клас Політ
    public class Flight
    {
        // унікальний ідентифікатор
        public int Id { get; set; }

        // номер польоту
        public string Number { get; set; }

        // літак, який виконуватиме політ
        public virtual Plane Plane { get; set; }

        // місто відправки
        public string StartTown { get; set; }

        // місто призначення
        public string DestinationTown { get; set; }

        // час польоту
        public DateTime Date { get; set; }

        public int? DelayId { get; set; }

        // затримка польоту
        public virtual Delay Delay { get; set; }

        // чи затримано політ
        public bool IsDelayed => Delay != null;

        public virtual ICollection<Ticket> Tickets { get; set; }

        // час закриття реєстрації на політ (від дати польоту віднімаємо 3 години)
        [NotMapped]
        public DateTime CloseTime => Date.Subtract(new TimeSpan(3, 0, 0));

        // конструктор за замовчуванням
        public Flight()
        {
            Tickets = new List<Ticket>();
        }

        // конструктор з параметрами
        public Flight(string number, Plane plane, string startTown, string destinationTown, DateTime date, Delay delay = null)
            : this()
        {
            Number = number;
            Plane = plane;
            StartTown = startTown;
            DestinationTown = destinationTown;
            Date = date;
            Delay = delay;
        }

        // переписуємо метод ToString
        public override string ToString()
        {
            return $"Політ №. {Number}\nЗ {StartTown} до {DestinationTown}\nДата: {Date}";
        }

    }
}
