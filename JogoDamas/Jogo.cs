using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDamas
{
    public class Jogo
    {
        private bool taJogando;
        private int jogada;
        private bool ultimoMovimento;
        private int outraJogada;

        public Jogo()
        {
            this.taJogando = true;
            this.jogada = 2;
        }

        public void comecarJogo()
        {
            string entrada;
            int valor;
            Tabuleiro tab = new Tabuleiro();
            List<Movimento> movimentos = new List<Movimento>();

            while(this.taJogando)
            {
                tab.exibirTabuleiro();

                if(this.jogada == 1)
                {
                    this.outraJogada = 2;
                }
                else
                {
                    this.outraJogada = 1;
                }

            }
        }
    }
}