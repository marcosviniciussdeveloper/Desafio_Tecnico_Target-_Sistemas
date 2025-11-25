using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using ConsoleApp1.Models;

namespace ConsoleApp1.Services
{
    //Serviço de inventário para gerenciar produtos e movimentos de estoque
    public class InventoryService
    {
        private List<Product> _products;

        public InventoryService(string json)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<ProductList>(json, options);
            _products = data?.Products ?? new List<Product>();
        }

        public List<Product> GetProducts() => _products;


        public void CreateProduct(int id, string description, int initialStock)
        {
            if (_products.Any(p => p.IdProduct == id))
                throw new Exception("Já existe um produto com este ID.");

            _products.Add(new Product
            {
                IdProduct = id,
                DescriptionProduct = description,
                StockQuantity = initialStock
            });
        }

        public StockMovement AddMovement(int productId, int quantity, string description)
        {
            var product = _products.FirstOrDefault(p => p.IdProduct == productId);

            if (product == null)
                throw new KeyNotFoundException("Produto não encontrado.");

            if (product.StockQuantity + quantity < 0)
                throw new InvalidOperationException("Estoque insuficiente.");

            product.StockQuantity += quantity;

            
            return new StockMovement
            {
                Id = Guid.NewGuid(),
                ProductId = productId,
                Description = description,
                QuantityChanged = quantity,
                FinalStockQuantity = product.StockQuantity,
                TimeStamp = DateTime.Now
            };
        }
    }
}