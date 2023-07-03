using System;
using System.Collections.Generic;

namespace GerenciadorFinancas
{
    class Program
    {
        static List<Despesa> despesas = new List<Despesa>();

        static void Main(string[] args)
        {
            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("----- Gerenciador de Finanças Pessoais -----");
                Console.WriteLine("1 - Registrar despesa");
                Console.WriteLine("2 - Criar orçamento");
                Console.WriteLine("3 - Gerar relatório de despesas");
                Console.WriteLine("4 - Obter insights sobre seus gastos");
                Console.WriteLine("5 - Sair");
                Console.WriteLine("--------------------------------------------");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        RegistrarDespesa();
                        break;
                    case "2":
                        CriarOrcamento();
                        break;
                    case "3":
                        GerarRelatorio();
                        break;
                    case "4":
                        ObterInsights();
                        break;
                    case "5":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void RegistrarDespesa()
        {
            Console.WriteLine("--- Registrar Despesa ---");
            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();
            Console.Write("Valor: ");
            decimal valor = decimal.Parse(Console.ReadLine());
            Console.Write("Data (dd/mm/aaaa): ");
            DateTime data = DateTime.Parse(Console.ReadLine());

            Despesa despesa = new Despesa(descricao, valor, data);
            despesas.Add(despesa);

            Console.WriteLine("Despesa registrada com sucesso!");
        }

        static void CriarOrcamento()
        {
            Console.WriteLine("--- Criar Orçamento ---");
            Console.Write("Mês (mm/aaaa): ");
            string mes = Console.ReadLine();
            Console.Write("Valor: ");
            decimal valor = decimal.Parse(Console.ReadLine());

            Orcamento orcamento = new Orcamento(mes, valor);

            Console.WriteLine("Orçamento criado com sucesso!");
        }

        static void GerarRelatorio()
        {
            Console.WriteLine("--- Relatório de Despesas ---");

            foreach (Despesa despesa in despesas)
            {
                Console.WriteLine($"{despesa.Descricao} - {despesa.Valor:C} - {despesa.Data.ToShortDateString()}");
            }
        }

        static void ObterInsights()
        {
            Console.WriteLine("--- Insights sobre seus Gastos ---");

            decimal totalGasto = 0;

            foreach (Despesa despesa in despesas)
            {
                totalGasto += despesa.Valor;
            }

            Console.WriteLine($"Total gasto: {totalGasto:C}");
        }
    }

    class Despesa
    {
        public string Descricao { get; }
        public decimal Valor { get; }
        public DateTime Data { get; }

        public Despesa(string descricao, decimal valor, DateTime data)
        {
            Descricao = descricao;
            Valor = valor;
            Data = data;
        }
    }

    class Orcamento
    {
        public string Mes { get; }
        public decimal Valor { get; }

        public Orcamento(string mes, decimal valor)
        {
            Mes = mes;
            Valor = valor;
        }
    }
}
