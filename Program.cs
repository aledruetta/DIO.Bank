using DIO.Bank.Entities;
using DIO.Bank.Repository;
using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        private static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ContaRepository.ListarContas();
                        break;
                    case "2":
                        ContaRepository.CriarConta();
                        break;
                    case "3":
                        ContaRepository.Transferir();
                        break;
                    case "4":
                        ContaRepository.Sacar();
                        break;
                    case "5":
                        ContaRepository.Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine();
            Console.WriteLine("Obrigado por usar nossos serviços!");
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("Informe a opção desejada:" + Environment.NewLine);

            Console.WriteLine(
                "1- Listar contas" + Environment.NewLine +
                "2- Inserir nova conta" + Environment.NewLine +
                "3- Transferir" + Environment.NewLine +
                "4- Sacar" + Environment.NewLine +
                "5- Depositar" + Environment.NewLine +
                "C- Limpar tela" + Environment.NewLine +
                "X- Sair" + Environment.NewLine
            );

            string opcaoUsuario = Console.ReadLine().ToUpper();

            return opcaoUsuario;
        }

        static void Test()
        {
            Random random = new Random();

            string[] nomes = { "Alejandro", "João", "Maria", "Irene", "Daniel" };
            Conta[] contas = new Conta[5];

            for (int i = 0; i < 5; i++)
            {
                var tipo = (TipoConta)random.Next(2);
                var saldo = (decimal)random.NextDouble() * 1000;
                var credito = (decimal)random.NextDouble() * 500;
                contas[i] = new Conta(
                    tipo,
                    Decimal.Round(saldo, 2),
                    Decimal.Round(credito, 2),
                    nomes[i]
                );
            }

            foreach (var conta in contas)
            {
                for (int i = 0; i < random.Next(1, 4); i++)
                {
                    var tipo = (TipoOperacao)random.Next(3);
                    var valor = Decimal.Round((decimal)random.NextDouble() * 2000, 2);

                    switch (tipo)
                    {
                        case TipoOperacao.Extracao:
                            conta.Sacar(valor);
                            break;
                        case TipoOperacao.Deposito:
                            conta.Depositar(valor);
                            break;
                        case TipoOperacao.Transferencia:
                            Conta contaDestino = contas[random.Next(5)];
                            conta.Transferir(valor, contaDestino);
                            break;
                    }
                }
            }
        }
    }
}
