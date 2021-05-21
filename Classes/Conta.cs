using System;

namespace DIO.Bank
{
    public class Conta
    {
        private static int NroOperacao = 1;
        private TipoConta TipoConta { get; set; }
        private Decimal Saldo { get; set; }
        private Decimal Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, Decimal saldo, Decimal credito, string nome)
        {
            TipoConta = tipoConta;
            Saldo = saldo;
            Credito = credito;
            Nome = nome;
        }

        public bool Sacar(Decimal valorSaque)
        {
            valorSaque = Math.Abs(valorSaque);

            Console.WriteLine($"Operação Nro: {NroOperacao}");
            Console.WriteLine($"Titular conta: {Nome}");
            Console.WriteLine($"Saldo inicial: R$ {Saldo}");
            Console.WriteLine($"Crédito:       R$ {Credito}");
            Console.WriteLine($"Valor saque:   R$ {valorSaque}");
            Console.WriteLine();

            if (Saldo + Credito < valorSaque)
            {
                Console.WriteLine("Saldo insuficiente!");
                Console.WriteLine();

                return false;
            }

            Saldo -= valorSaque;
            NroOperacao += 1;

            Console.WriteLine($"Operação bem sucedida!");
            Console.WriteLine($"Saldo atual: R$ {Saldo}");
            Console.WriteLine();

            return true;
        }

        public void Depositar(Decimal valorDeposito)
        {
            Console.WriteLine($"Operação Nro: {NroOperacao}");
            Console.WriteLine($"Titular conta:  {Nome}");
            Console.WriteLine($"Saldo inicial:  R$ {Saldo}");
            Console.WriteLine($"Valor depósito: R$ {valorDeposito}");
            Console.WriteLine();

            Saldo += Math.Abs(valorDeposito);
            NroOperacao += 1;

            Console.WriteLine($"Operação bem sucedida!");
            Console.WriteLine($"Saldo atual: R$ {Saldo}");
            Console.WriteLine();
        }
    }
}