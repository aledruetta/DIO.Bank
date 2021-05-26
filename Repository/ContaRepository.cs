using DIO.Bank.Entities;
using System;
using System.Collections.Generic;

namespace DIO.Bank.Repository
{
    public class ContaRepository
    {
        public static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            decimal valorDeposito = decimal.Parse(Console.ReadLine());

            Conta.ListarContas()[indiceConta].Depositar(valorDeposito);
        }

        public static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor do saque: ");
            decimal valorSaque = decimal.Parse(Console.ReadLine());

            Conta.ListarContas()[indiceConta].Sacar(valorSaque);
        }

        public static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            decimal valorTransferencia = decimal.Parse(Console.ReadLine());

            List<Conta> listaContas = Conta.ListarContas();

            listaContas[indiceContaOrigem].Transferir(
                valorTransferencia,
                listaContas[indiceContaDestino]
            );
        }

        public static void ListarContas()
        {
            List<Conta> listaContas = Conta.ListarContas();

            Console.WriteLine("Listar contas");
            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            foreach (var conta in listaContas)
                Console.WriteLine(conta);
        }

        public static void CriarConta()
        {
            string prompt;
            Console.WriteLine("Criar conta");

            prompt = "Digite 1 para Conta Física ou 2 para Conta Jurídica: ";
            Console.Write(prompt);
            int tipoConta = int.Parse(Console.ReadLine()) - 1;
            while (tipoConta < 0 || tipoConta > 1)
            {
                Console.Write(prompt);
                tipoConta = int.Parse(Console.ReadLine()) - 1;
            }

            prompt = "Digite o Nome do Cliente: ";
            Console.Write(prompt);
            string nome = Console.ReadLine().ToUpper();
            while (nome.Length <= 0)
            {
                Console.Write(prompt);
                nome = Console.ReadLine().ToUpper();
            }

            prompt = "Digite o Saldo Inicial: ";
            Console.Write(prompt);
            decimal saldo = decimal.Parse(Console.ReadLine());
            while (saldo < 0)
            {
                Console.Write(prompt);
                saldo = decimal.Parse(Console.ReadLine());
            }

            prompt = "Digite o Crédito: ";
            Console.Write(prompt);
            decimal credito = decimal.Parse(Console.ReadLine());
            while (credito < 0)
            {
                Console.Write(prompt);
                credito = decimal.Parse(Console.ReadLine());
            }

            Conta novaConta = new Conta((TipoConta)tipoConta, saldo, credito, nome);
        }

    }
}