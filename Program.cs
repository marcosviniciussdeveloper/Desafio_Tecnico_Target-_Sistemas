using System;
using ConsoleApp1.Data;
using ConsoleApp1.Services;


//Classe Responsável pela interface do usuário e interação com os serviços(Parte principal do programa)

var salesService = new SalesService();
var inventoryService = new InventoryService(JsonSource.GetInventoryJson());
var financialService = new FinancialService();

bool running = true;

while (running)
{
    Console.Clear();
    Console.WriteLine("=== Gestão Com Cálculos ===");
    Console.WriteLine("1. Calcular Comissões");
    Console.WriteLine("2. Movimentar Estoque");
    Console.WriteLine("3. Calcular Juros");
    Console.WriteLine("0. Sair");
    Console.Write("Opção: ");

    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            Console.Clear();
            Console.WriteLine("1. Relatório Geral (JSON)");
            Console.WriteLine("2. Simulação Manual");
            Console.Write("Escolha: ");
            var salesOption = Console.ReadLine();

            if (salesOption == "1")
            {
                var report = salesService.CalculateCommissions(JsonSource.GetSalesJson());
                foreach (var item in report)
                    Console.WriteLine($"Vendedor: {item.Key} - Comissão: {item.Value:C2}");
            }
            else if (salesOption == "2")
            {
                Console.Write("Valor da Venda: ");
                decimal.TryParse(Console.ReadLine(), out decimal saleVal);
                var comm = salesService.CalculateSingleCommission(saleVal);
                Console.WriteLine($"Comissão Calculada: {comm:C2}");
            }
            break;

        case "2":
            Console.Clear();
            Console.WriteLine("--- Produtos Disponíveis ---");

            var products = inventoryService.GetProducts();

            foreach (var p in products)
            {
                var descDisplay = p.DescriptionProduct ?? "Sem Descrição";
                Console.WriteLine($"ID: {p.IdProduct} | {descDisplay.PadRight(30)} | Estoque: {p.StockQuantity}");
            }

            Console.WriteLine("----------------------------");
            Console.Write("\nDigite o ID do Produto desejado: ");
            int.TryParse(Console.ReadLine(), out int pid);

            Console.Write("Quantidade (Positivo=Entrada, Negativo=Saída): ");
            int.TryParse(Console.ReadLine(), out int qty);

            Console.Write("Motivo/Descrição: ");
            var desc = Console.ReadLine();

            try
            {
                var mov = inventoryService.AddMovement(pid, qty, desc);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nSucesso! {mov.Description}");
                Console.WriteLine($"Novo Saldo: {mov.FinalStockQuantity}");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nErro: {ex.Message}");
                Console.ResetColor();
            }
            break;

        case "3":
            Console.Clear();
            Console.Write("Valor (R$): ");
            decimal.TryParse(Console.ReadLine(), out decimal amount);
            Console.Write("Vencimento (dd/MM/yyyy): ");
            DateTime.TryParse(Console.ReadLine(), out DateTime date);

            var result = financialService.CalculateInterest(amount, date);
            Console.WriteLine($"Dias Atraso: {result.DaysOverdue}");
            Console.WriteLine($"Juros: {result.InterestAmount:C2}");
            Console.WriteLine($"Total: {result.TotalAmount:C2}");
            break;

        case "0":
            running = false;
            break;
    }

    if (running)
    {
        Console.WriteLine("\n==================================");
        Console.WriteLine("O que deseja fazer agora?");
        Console.WriteLine("[1] Adicionar um novo Produto ao Sistema");
        Console.WriteLine("[2] Voltar ao Menu Principal");
        Console.WriteLine("[0] Sair");
        Console.Write("Escolha: ");

        var nextStep = Console.ReadLine();

        if (nextStep == "1")
        {
            Console.Clear();
            Console.WriteLine("--- Cadastro de Novo Produto ---");
            Console.Write("Novo ID: ");
            int.TryParse(Console.ReadLine(), out int newId);

            Console.Write("Descrição: ");
            string newDesc = Console.ReadLine();

            Console.Write("Estoque Inicial: ");
            int.TryParse(Console.ReadLine(), out int newStock);

            try
            {
                inventoryService.CreateProduct(newId, newDesc, newStock);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Produto cadastrado com sucesso! Pressione algo para voltar ao menu.");
                Console.ResetColor();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Erro ao cadastrar: {ex.Message}");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
        else if (nextStep == "0")
        {
            running = false;
        }
        // Se for "2" ou qualquer outra coisa, o loop reinicia e volta ao menu principal
    }
}