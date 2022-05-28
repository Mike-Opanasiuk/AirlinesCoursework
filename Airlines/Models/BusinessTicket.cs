using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlines.Models
{
    // клас Бізнес квиток, що наслідується від базового Ticket
    public class BusinessTicket : Ticket
    {
        // конструктор за замовчуванням
        public BusinessTicket()
        {
        }

        // конструктор з параметрами
        public BusinessTicket(Flight flight, decimal price, bool hasOwnBedroom) 
            // викликаємо конструктор з базового класу
            : base(flight, price)
        {
            HasOwnBedroom = hasOwnBedroom;
        }

        // чи включена у квиток власна спальня
        public bool HasOwnBedroom { get; set; }

    }
}
