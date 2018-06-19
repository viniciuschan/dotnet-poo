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

            // peças X
            for(int i = 0; i < 4; i++)
            {
                P.Add(new Peca(1, 2*i, 0));
                P.Add(new Peca(1, 2*i + 1, 1));
                P.Add(new Peca(1, 2*1, 2));
            }
            // peças O
            for(int i = 0; i < 4; i++)
            {
                P.Add(new Peca(2, 2*i + 1, 7));
                P.Add(new Peca(2, 2*i, 6));
                P.Add(new Peca(2, 2*i + 1, 5));
            }
        }

        public void exibirTabuleiro()
        {
            //Exibe o tabuleiro na tela
            // Implementar
        }
    }
}