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

                movimentos = tab.verificarMovimento(this.jogada);

                if (this.ultimoMovimento && tab.verificarMovimento(this.outraJogada).Count > 0)
                {
                    movimentos = tab.verificarMovimento(this.outraJogada);
                    this.jogada = this.outraJogada;
                    this.ultimoMovimento = true;
                }
                else if (movimentos.Count == 0)
                {
                    movimentos = tab.verificarMovimentoValido(this.jogada);
                    this.ultimoMovimento = false;
                }
                else
                    this.ultimoMovimento = true;

                if (movimentos.Count == 0)
                {
                    this.taJogando = false;
                    continue;
                }

                Console.WriteLine(tab.exibirMovimento(movimentos));
                entrada = Console.ReadLine();
                while (true)
                {
                    if (!int.TryParse(entrada, out valor))
                    {
                        Console.WriteLine("Escolha um movimento válido");
                        entrada = Console.ReadLine();
                    }
                    if (valor <= movimentos.Count && valor > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Escolha um movimento válido");
                        entrada = Console.ReadLine();
                    }
                }
                Movimento m = movimentos[valor-1];
                tab.movimento(m);
                
                Peca p;
                if ((m.fim_y == 0 && this.jogada == 2) || m.fim_y == 7 && this.jogada == 1)
                {
                    p =
                        (from peca in tab.P
                         where peca.pos_x == m.fim_x
                         && peca.pos_y == m.fim_y
                         select peca).SingleOrDefault();
                    p.pecaDama = true;
                }
                if (Math.Abs(m.fim_x - m.ini_x) > 1)
                {
                    tab.removerPeca((m.fim_x + m.ini_x)/2, (m.fim_y + m.ini_y)/2);
                }
                if (this.jogada == 1)
                {
                    this.jogada = 2;
                }
                else
                {
                    this.jogada = 1;
                }
            }
            Console.WriteLine("Time " + this.jogada + " ganhou!");
            Console.Read();
        }
    }
}
