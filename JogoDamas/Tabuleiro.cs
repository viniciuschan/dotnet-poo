using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JogoDamas
{
    public class Tabuleiro
    {
        public List<Peca> P { get; set; }
        
        public Tabuleiro()
        {
            P = new List<Peca>();

            //Jogador 1
            for(int i = 0; i < 4; i++)
            {
                P.Add(new Peca(1, 2*i, 0));
                P.Add(new Peca(1, 2*i + 1, 1));
                P.Add(new Peca(1, 2*1, 2));
            }

            //Jogador 2
            for(int i = 0; i < 4; i++)
            {
                P.Add(new Peca(2, 2*i + 1, 7));
                P.Add(new Peca(2, 2*i, 6));
                P.Add(new Peca(2, 2*i + 1, 5));
            }
        }

        public int verificarPosicao(int x, int y)
        {
            //Implementar
        }

        public void exibirTabuleiro()
        {
            string val = "";
            val += "   _________________\n";

            for (int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if(j == 0)
                        val += i + " | ";
                    if(verificarPosicao(j, i) == 1)
                        val += "X ";
                    else if(verificarPosicao(j, i) == 2)
                        val += "O ";
                    else
                        val += "- ";
                    if (j == 7)
                    val += "|\n";
                }
            }
            val += "  |_________________|\n\n    0 1 2 3 4 5 6 7\n";
            Console.WriteLine(val);
        }

        public string exibirMovimento(List<Movimento> movimentos)
        {
            //Implementar
        }

        public List<Movimento> verificarMovimento(int jogador)
        {
              //Implementar
        }

        public List<Movimento> verificarMovimentoValido(int jogador)
        {
            //Implementar
        }

        public void movimento(Movimento m)
        {
            //Implementar
        }

        public void removerPeca(int x, int y)
        {
            //Implementar
        }

    }
}
