using System;

namespace DIO.Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            string[] nomes = {"Alejandro", "João", "Maria", "Irene", "Daniel"};
            Conta[] contas = new Conta[5];

            for (int i = 0; i < 5; i++)
            {
                var tipo = (TipoConta)random.Next(2);
                var saldo = (Decimal)random.NextDouble() * 1000;
                var credito = (Decimal)random.NextDouble() * 500;
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
                    var tipo = (TipoOperacao)random.Next(2);
                    var valor = Decimal.Round((Decimal)random.NextDouble() * 2000, 2);

                    if (tipo == TipoOperacao.Deposito)
                        conta.Depositar(valor);
                    else
                        conta.Sacar(valor);
                }
            }
        }
    }
}
