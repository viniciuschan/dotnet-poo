using System;
using System.Collections.Generic;
using System.Linq;


namespace MeuBanco
{


    class Transacao
    {
        public DateTime Data { get; set; }
        public double Valor { get; set; }
    }


    class ContaCorrente
    {
        private int _numero_conta;
        private List<Transacao> _transacoes = new List<Transacao>();
        public string Agencia { get; set; }
        public string Gerente { get; set; }
        public Cliente Titular { get; set; }

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

        public double Saldo
        {
            get
            {
                return _transacoes.Sum(tr => tr.Valor);
            }
        }

        public bool Depositar(double valor)
        {
            if(valor > 0)
            {
                _transacoes.Add(new Transacao { Valor = valor, Data = DateTime.Now });
                return true;
            }
            return false;
        }

        public bool Sacar(double valor)
        {
            if(valor > 0 && Saldo >= valor)
            {
                _transacoes.Add(new Transacao { Valor = -valor, Data = DateTime.Now });
                return true;
            }
            return false;
        }

        public string EmitirExtrato()
        {
            string extrato = string.Empty;
            foreach (var transacao in _transacoes)
            {
                extrato += "\n" + transacao.Data + "\t" + transacao.Valor;
            }
            return extrato + "\n\nSALDO DESTE PERÍODO = R$ " + Saldo;
        }
    }
}
