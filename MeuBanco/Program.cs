using System;

namespace MeuBanco
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente c1 = new ContaCorrente();
            c1.Nome = "Vinicius Chan";
            c1.Numero = 454545;

            Console.WriteLine("Oi {0}, sua conta é {1}", c1.Nome, c1.Numero);
        }
    }
}
