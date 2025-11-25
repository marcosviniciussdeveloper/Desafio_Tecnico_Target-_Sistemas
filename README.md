# Sistema de Gestão Integrado - Desafio C#

Este projeto é uma aplicação de console desenvolvida em C# (.NET) como resolução de um desafio técnico. O sistema simula um ambiente de gestão empresarial focado em três pilares: Vendas, Estoque e Financeiro.

O objetivo principal foi demonstrar **Boas Práticas de Programação**, incluindo separação de responsabilidades, *Clean Code*, princípios SOLID e manipulação de dados JSON.

## 🚀 Funcionalidades

O sistema possui um menu interativo que permite:

### 1. Módulo de Vendas (Comissões)
*   **Processamento em Lote:** Lê um JSON simulado contendo histórico de vendas e gera um relatório consolidado de comissões por vendedor.
*   **Simulação Manual:** Permite digitar um valor de venda avulso para calcular a comissão em tempo real.
*   **Regra de Negócio:**
    *   Vendas < R$ 100,00: Sem comissão.
    *   Vendas entre R$ 100,00 e R$ 500,00: 1% de comissão.
    *   Vendas >= R$ 500,00: 5% de comissão.

### 2. Módulo de Estoque
*   **Visualização:** Lista produtos carregados de uma fonte de dados JSON.
*   **Movimentação:** Permite dar entrada ou saída de mercadorias, validando a existência do produto.
*   **Cadastro de Produtos:** Funcionalidade extra que permite inserir novos produtos ao catálogo em tempo de execução.
*   **Tratamento de Dados:** Utiliza mapeamento de propriedades (`JsonPropertyName`) para ler dados em Português e utilizá-los em classes em Inglês.

### 3. Módulo Financeiro
*   **Cálculo de Juros:** Calcula o valor atualizado de um boleto vencido.
*   **Regra:** Taxa de juros simples de 2.5% ao dia de atraso.

---

## 🛠️ Arquitetura e Tecnologias

O projeto foi estruturado para garantir a escalabilidade e a manutenção fácil:

*   **Linguagem:** C# (.NET 6/7/8)
*   **Formato de Dados:** JSON (via `System.Text.Json`)
*   **Estrutura de Pastas:**

```text
📁 ConsoleApp1
│
├── 📁 Models       # Representação dos dados (Classes Anêmicas/DTOs)
│   ├── Product.cs
│   ├── Sale.cs
│   └── ...
│
├── 📁 Services     # Regras de Negócio (Lógica Pura)
│   ├── CommissionService.cs
│   ├── InventoryService.cs
│   └── FinancialService.cs
│
├── 📁 Data         # Fonte de Dados (Simulação de DB/JSON estático)
│   └── JsonSource.cs (ou DataSource.cs)
│
└── Program.cs      # Camada de Apresentação (UI - Console)
