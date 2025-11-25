using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Product
    {
        [JsonPropertyName("codigoProduto")]
        public int IdProduct { get; set; }

        [JsonPropertyName("descricaoProduto")]
        public string? DescriptionProduct { get; set; }

        [JsonPropertyName("estoque")]

        public int StockQuantity { get; set; }


    }

    //Metodo para desserializar a lista de produtos
    public class ProductList
    {
        [JsonPropertyName("estoque")]
        public List<Product> Products { get; set; }
    }
}
