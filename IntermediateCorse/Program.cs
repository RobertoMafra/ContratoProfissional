using IntermediateCorse.Entities;
using IntermediateCorse.Entities.Enums;
using System;
using System.Globalization;

namespace IntermediateCorse
{
    class Program
    {
        static void Main(string[] args)
        {
            //Definir os dados iniciais
            string deptname = " ";
            string nome = " ";
            double salarioBase = 0.0;
            double valorPorHora = 0.0;
            int quantidadeContratos = 0;
            int posicao = 0;
            int duracaoContrato = 0;
            DateTime data;

            //Entrar com os dados do funcionario
            Console.Write("Entre com o nome do departamento: ");
            deptname = Console.ReadLine();
            Console.WriteLine("Entre com os dados do trabalhador: ");
            Console.Write("Nome: ");
            nome = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Salário fixo: ");
            salarioBase = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            //Criar o trabalhador
            Departament dept = new Departament(deptname);
            Worker worker = new Worker(nome, level, salarioBase, dept);

            //Quantidade de contratos
            Console.Write("Quantos contratos serao adicionados: ");
            quantidadeContratos = int.Parse(Console.ReadLine());

            //Receber os dados dos contratos
            for (posicao = 0; posicao < quantidadeContratos; posicao = posicao + 1)
            {
                //Receber os dados do contrato
                Console.WriteLine($"Entre com os dados do #{posicao + 1} contrato:");
                Console.Write("Data (DD/MM/YYYY): ");
                data = DateTime.Parse(Console.ReadLine());
                Console.Write("Valor por hora: ");
                valorPorHora = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duração(horas): ");
                duracaoContrato = int.Parse(Console.ReadLine());

                //Criar um contrato
                HourContract contract = new HourContract(data, valorPorHora, duracaoContrato);

                //Adicionar o contrato no trabalhador
                worker.AddContract(contract);
            }

            Console.WriteLine();
            Console.Write("Entre com o mês e ano para calcular o ganho (MM/YYYY): ");
            string mesEAno = Console.ReadLine();
            int mes = int.Parse(mesEAno.Substring(0, 2));
            int ano = int.Parse(mesEAno.Substring(3));

            Console.WriteLine("Nome: " + worker.Name);
            Console.WriteLine("Depertamento: " + worker.Departament.Name);
            Console.WriteLine("Ganho em " + mesEAno + ": " + worker.Income(ano, mes).ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
