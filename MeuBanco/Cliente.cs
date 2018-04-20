using System;


namespace MeuBanco
{
    class Cliente
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string CPF { get; private set; }
        public double Renda { get; set; }

        public Cliente(string nome, string cpf)
        {
            Nome = nome;
            CPF = cpf;
        }
    }
}
