using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    
    public class StockMovement
    {
        public Guid Id { get; set; }

        public int ProductId { get; set; }

        public string Description { get; set; }


        public int QuantityChanged { get; set; }

        public int FinalStockQuantity { get; set; }

        public DateTime TimeStamp { get; set; }

    }
}
