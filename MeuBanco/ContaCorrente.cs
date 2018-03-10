using System;

namespace MeuBanco
{
    class ContaCorrente
    {
        private string _nome;
        private string _agencia;
        private int _numero_conta;

        public string Nome
        {
            set
            {
                if(value != string.Empty)
                    _nome = value;
            }
            get
            {
                return _nome;
            }
        }

        public string Agencia { set; get; }

        public int Numero
        {
            set
            {
                _numero_conta = value > 0 ? value : _numero_conta;
            }
            get
            {
                return _numero_conta;
            }
        }

        public double Saldo { private set; get; }

        public void Depositar(double valor)
        {
            if(valor > 0)
                Saldo += valor;
        }

        public bool Sacar(double valor)
        {
            if(valor>0 && Saldo>=valor)
            {
                Saldo -= valor;
                return true;
            }
            return false;
        }
    }
}