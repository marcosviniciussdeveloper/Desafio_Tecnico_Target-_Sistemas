using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Sale
    {
        [JsonPropertyName("Vendedor")]
        public string Seller { get; set; }


        [JsonPropertyName("Valor")]
        public decimal Amount { get; set; }
    }



    //Metodo para desserializar a lista de vendas
    public class SaleList
    {
        [JsonPropertyName("Vendas")]
        public List<Sale> Sales { get; set; }
    }
}
