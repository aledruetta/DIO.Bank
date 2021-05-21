using System;

namespace DIO.Bank
{
    public class Conta
    {
        private static int NroOperacao = 1;
        private TipoConta TipoConta { get; set; }
        private decimal Saldo { get; set; }
        private decimal Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, decimal saldo, decimal credito, string nome)
        {
            TipoConta = tipoConta;
            Saldo = saldo;
            Credito = credito;
            Nome = nome;
        }

        public bool Sacar(decimal valorSaque)
        {
            valorSaque = Math.Abs(valorSaque);

            Console.WriteLine($"Operação Nro: {NroOperacao}");
            Console.WriteLine($"Titular conta: {Nome}");
            Console.WriteLine($"Saldo inicial: R$ {Saldo}");
            Console.WriteLine($"Crédito:       R$ {Credito}");
            Console.WriteLine($"Valor saque:   R$ {valorSaque}");
            Console.WriteLine();

            NroOperacao += 1;

            if (Saldo + Credito < valorSaque)
            {
                Console.WriteLine("Saldo insuficiente!");
                Console.WriteLine();

                return false;
            }

            Saldo -= valorSaque;

            Console.WriteLine($"Operação bem sucedida!");
            Console.WriteLine($"Saldo atual: R$ {Saldo}");
            Console.WriteLine();

            return true;
        }

        public void Depositar(decimal valorDeposito)
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

        internal void Transferir(decimal valor, Conta contaDestino)
        {
            Console.WriteLine("*** Transferencia ***");
            Console.WriteLine();

            if (Sacar(valor))
                contaDestino.Depositar(valor);

            Console.WriteLine("*** Fim Transferencia ***");
            Console.WriteLine();
        }
    }
}