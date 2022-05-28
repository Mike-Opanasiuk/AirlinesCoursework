using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlines.Models
{
    // клас Клієнт
    public class Customer
    {
        public int Id { get; set; }

        // конструктор за замовчуванням (необхідний для xml серіалізації)
        public Customer()
        {
            Tickets = new List<Ticket>();
        }

        // список квитків, які клієнт містить
        public virtual ICollection<Ticket> Tickets { get; set; }

    }
}
