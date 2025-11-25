using System.Collections.Generic;
using System.Text.Json;
using ConsoleApp1.Models;

namespace ConsoleApp1.Services
{
    public class SalesService
    {
        // Calcula as comissões totais por vendedor a partir de um JSON de vendas
        public Dictionary<string, decimal> CalculateCommissions(string json)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<SaleList>(json, options);
            var result = new Dictionary<string, decimal>();

            if (data?.Sales == null) return result;

            foreach (var sale in data.Sales)
            {
                decimal commission = CalculateSingleCommission(sale.Amount);

                if (result.ContainsKey(sale.Seller))
                    result[sale.Seller] += commission;
                else
                    result[sale.Seller] = commission;
            }

            return result;
        }

        //Calcula uma comissão unica com base no valor da venda
        public decimal CalculateSingleCommission(decimal amount)
        {
            if (amount < 100) return 0;
            if (amount < 500) return amount * 0.01m;
            return amount * 0.05m;
        }
    }
}