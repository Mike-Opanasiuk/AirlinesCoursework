using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airlines.Models
{
    // клас Затримка польоту
    public class Delay
    {
        // унікальний ідентифікатор
        public int Id { get; set; }

        // конструктор за замовчуванням
        public Delay()
        {
        }

        // конструктор з параметрами
        public Delay(string delayReason, TimeSpan delayTime)
        {
            DelayReason = delayReason;
            DelayTime = delayTime;
        }

        public virtual Flight Flight { get; set; }

        // причина затримки
        public string DelayReason { get; set; }

        // час, на який затримано політ
        public TimeSpan DelayTime { get; set; }
    }
}
