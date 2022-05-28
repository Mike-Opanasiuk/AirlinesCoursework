using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlines.Models
{
    public class StandartTicket : Ticket
    {
        // конструктор за замовчуванням (необхідний для xml серіалізації)
        public StandartTicket()
        {
        }

        // конструктор з параметрами
        public StandartTicket(Flight flight, decimal price) 
            // викликаємо конструктор із базового класу
            : base(flight, price)
        {
        }
    }
}
