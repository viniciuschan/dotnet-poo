using System;

namespace MeuBanco
{
    class ContaCorrente
    {
        private string _nome;
        private int _numero_conta;

        public String Nome
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
    }
}
