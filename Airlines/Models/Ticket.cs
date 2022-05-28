using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Airlines.Models
{
    // базовий абстрактний клас Квиток
    abstract public class Ticket
    {
        // унікальний ідентифікатор
        public int Id { get; set; }

        // політ, до якого належить квиток
        public virtual Flight Flight { get; set; }

        public int? CustomerId { get; set; }
        // користувач, що придбав квиток
        public virtual Customer Customer { get; set; }

        // ціна квитка
        public decimal Price { get; set; }

        // конструктор за замовчуванням
        public Ticket()
        {
        }

        // конструктор з параметрами
        public Ticket(Flight flight, decimal price)
        {
            Flight = flight;
            Price = price;
        }
    }
}
