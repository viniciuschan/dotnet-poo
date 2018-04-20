using System;


namespace MeuBanco
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente c1 = new ContaCorrente();

            Console.Write("Digite o seu nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o seu CPF: ");
            string cpf = Console.ReadLine();

            var cli = new Cliente(cpf: cpf, nome: nome);

            // c1.Agencia = "4545";
            // c1.Numero = 50;
            // c1.Titular = cli;

            // cli.Endereco = "xxxxxxxx, 50";
            // cli.Email = "viniciuschan@hotmail.com";

            int op = 0;
            do
            {
                Console.WriteLine(" ---------- MENU DE OPÇÕES ----------");
                Console.WriteLine("1 - Depósito\n2 - Saque\n3 - Extrato\n4 - Sair\n\n");
                Console.Write("Escolha uma opção: ");

                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Console.Write("Digite o valor para depósito: ");
                        double valor = double.Parse(Console.ReadLine());
                        if(c1.Depositar(valor))
                            Console.WriteLine("Depósito realizado com sucesso.\n\nSALDO ATUAL = R$ {0}\n", c1.Saldo);
                        break;

                    case 2:
                        Console.Write("Digite o valor para saque: ");
                        valor = double.Parse(Console.ReadLine());
                        if(c1.Sacar(valor))
                            Console.WriteLine("Saque realizado com sucesso.\n\nSALDO ATUAL= R$ {0}\n", c1.Saldo);
                        else
                            Console.WriteLine("Saldo insuficiente.\n\nSALDO ATUAL = R$ {0}", c1.Saldo);
                        break;

                    case 3:
                        Console.WriteLine("***** EXTRATO *****:\n" + c1.EmitirExtrato());
                        break;

                    case 4:
                        Console.WriteLine("Adeus tchau tchauu, {0}!!!\n\n",cli.Nome);
                        break;

                    default:
                        Console.WriteLine("Opção inexistente.\n\n");
                        break;
                }
            } while (op != 4);
        }
    }
}
