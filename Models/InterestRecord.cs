using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    //Classe para representar o registro de juros
    public class InterestRecord
    {
        public int DaysOverdue { get; set; }

        public decimal InterestAmount { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
