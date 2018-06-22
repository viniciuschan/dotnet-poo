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
                P.Add(new Peca(1, 2*i, 2));
            }

            //Jogador 2
            for(int i = 0; i < 4; i++)
            {
                P.Add(new Peca(2, 2 * i + 1, 7));
                P.Add(new Peca(2, 2 * i, 6));
                P.Add(new Peca(2, 2 * i + 1, 5));
            }
        }

        public int verificarPosicao(int x, int y)
        {
            int t;
            //Retorna time da peça na posição (x, y) se esta for uma posição válida
            if ((0 <= x && x <= 7) && (0 <= y && y <= 7))
            {
                t =
                    (from peca in P
                     where peca.pos_x == x
                     && peca.pos_y == y
                     select peca.time).SingleOrDefault();
            }
            else
            {
                t = 3;
            }
            return t;
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
            string valor = "";
            int i = 1;
            foreach (Movimento movimento in movimentos)
            {
                valor += "(" + i + ")  (" + movimento.ini_x + ", " + movimento.ini_y + ") para (" + movimento.fim_x + ", " + movimento.fim_y + ")\n";
                i++;
            }
            for (int j = 0; j < 10 - movimentos.Count; j++)
            {
                valor += "\n";
            }
            return valor;
        }

        public List<Movimento> verificarMovimento(int jogador) {

            List<Movimento> movimentos = new List<Movimento>();
            IEnumerable<Peca> p;
            if (jogador == 1) {
                
                //Move peças para lado direito
                p =
                    (from peca in P
                     where verificarPosicao(peca.pos_x + 1, peca.pos_y + 1) == 2
                     && verificarPosicao(peca.pos_x + 2, peca.pos_y + 2) == 0
                     && peca.time == 1
                     select peca);
                if (p != null) {
                    foreach (Peca pi in p)
                        movimentos.Add(new Movimento(pi.pos_x, pi.pos_y, pi.pos_x + 2, pi.pos_y + 2, 1));
                }

                //Move peças para lado esquerdo
                p =
                    (from peca in P
                     where verificarPosicao(peca.pos_x - 1, peca.pos_y + 1) == 2
                     && verificarPosicao(peca.pos_x - 2, peca.pos_y + 2) == 0
                     && peca.time == 1
                     select peca);
                if (p != null) {
                    foreach (Peca pi in p)
                        movimentos.Add(new Movimento(pi.pos_x, pi.pos_y, pi.pos_x - 2, pi.pos_y + 2, 1));
                }

                //Move damas para lado direito
                p =
                (from peca in P
                 where verificarPosicao(peca.pos_x + 1, peca.pos_y - 1) == 2
                 && verificarPosicao(peca.pos_x + 2, peca.pos_y - 2) == 0
                 && peca.time == 1
                 && peca.pecaDama
                 select peca);
                if (p != null) {
                    foreach (Peca pi in p)
                        movimentos.Add(new Movimento(pi.pos_x, pi.pos_y, pi.pos_x + 2, pi.pos_y - 2, 1));
                }
                //Move damas para lado esquerdo
                p =
                (from peca in P
                 where verificarPosicao(peca.pos_x - 1, peca.pos_y - 1) == 2
                 && verificarPosicao(peca.pos_x - 2, peca.pos_y - 2) == 0
                 && peca.time == 1
                 && peca.pecaDama
                 select peca);
                if (p != null) {
                    foreach (Peca pi in p)
                        movimentos.Add(new Movimento(pi.pos_x, pi.pos_y, pi.pos_x - 2, pi.pos_y - 2, 1));
                }
            }
            else {
                //Move peças para lado direito
                p =
                   (from peca in P
                    where verificarPosicao(peca.pos_x + 1, peca.pos_y - 1) == 1
                    && verificarPosicao(peca.pos_x + 2, peca.pos_y - 2) == 0
                    && peca.time == 2
                    select peca);
                if (p != null) {
                    foreach (Peca pi in p)
                        movimentos.Add(new Movimento(pi.pos_x, pi.pos_y, pi.pos_x + 2, pi.pos_y - 2, 2));
                }
                //Move peças para lado esquerdo
                p =
                    (from peca in P
                     where verificarPosicao(peca.pos_x - 1, peca.pos_y - 1) == 1
                     && verificarPosicao(peca.pos_x - 2, peca.pos_y - 2) == 0
                     && peca.time == 2
                     select peca);
                if (p != null) {
                    foreach (Peca pi in p)
                        movimentos.Add(new Movimento(pi.pos_x, pi.pos_y, pi.pos_x - 2, pi.pos_y - 2, 2));
                }
                //Move damas para lado direito
                p =
                    (from peca in P
                    where verificarPosicao(peca.pos_x + 1, peca.pos_y + 1) == 1
                    && verificarPosicao(peca.pos_x + 2, peca.pos_y + 2) == 0
                    && peca.time == 2
                    && peca.pecaDama
                    select peca);
                    if (p != null) {
                        foreach (Peca pi in p)
                            movimentos.Add(new Movimento(pi.pos_x, pi.pos_y, pi.pos_x + 2, pi.pos_y + 2, 2));
                }
                //Move damas para lado esquerdo
                p =
                    (from peca in P
                     where verificarPosicao(peca.pos_x - 1, peca.pos_y + 1) == 1
                     && verificarPosicao(peca.pos_x - 2, peca.pos_y + 2) == 0
                     && peca.time == 2
                     && peca.pecaDama
                     select peca);
                if (p != null) {
                    foreach (Peca pi in p)
                        movimentos.Add(new Movimento(pi.pos_x, pi.pos_y, pi.pos_x - 2, pi.pos_y + 2, 2));
                }


            }

            movimentos = movimentos.OrderBy(x=> x.ini_x).ToList();
            return movimentos;
        }

        public List<Movimento> verificarMovimentoValido(int jogador) {

            //Encontra uma lista de movimentos válidos para cada jogador
            List<Movimento> movimentos = new List<Movimento>();

            IEnumerable<Peca> p;
            if (jogador == 1) {
                p =
                    (from peca in P
                     where verificarPosicao(peca.pos_x + 1, peca.pos_y + 1) == 0
                     && peca.time == 1
                     select peca);
                if (p != null)
                {
                    foreach (Peca pi in p)
                        movimentos.Add(new Movimento(pi.pos_x, pi.pos_y, pi.pos_x + 1, pi.pos_y + 1, 1));
                }
                p =
                    (from peca in P
                     where verificarPosicao(peca.pos_x - 1, peca.pos_y + 1) == 0
                     && peca.time == 1
                     select peca);
                if (p != null)
                {
                    foreach (Peca pi in p)
                        movimentos.Add(new Movimento(pi.pos_x, pi.pos_y, pi.pos_x - 1, pi.pos_y + 1, 1));
                }
                p =
                    (from peca in P
                    where verificarPosicao(peca.pos_x + 1, peca.pos_y - 1) == 0
                    && peca.time == 1
                    && peca.pecaDama
                    select peca);
                if (p != null)
                {
                    foreach (Peca pi in p)
                        movimentos.Add(new Movimento(pi.pos_x, pi.pos_y, pi.pos_x + 1, pi.pos_y - 1, 1));
                }
                p =
                    (from peca in P
                     where verificarPosicao(peca.pos_x - 1, peca.pos_y - 1) == 0
                     && peca.time == 1
                     && peca.pecaDama
                     select peca);
                if (p != null)
                {
                    foreach (Peca pi in p)
                        movimentos.Add(new Movimento(pi.pos_x, pi.pos_y, pi.pos_x - 1, pi.pos_y - 1, 1));
                }

            }
            else {
                p =
                   (from peca in P
                    where verificarPosicao(peca.pos_x + 1, peca.pos_y - 1) == 0
                    && peca.time == 2
                    select peca);
                if (p != null)
                {
                    foreach (Peca pi in p)
                        movimentos.Add(new Movimento(pi.pos_x, pi.pos_y, pi.pos_x + 1, pi.pos_y - 1, 2));
                }
                p =
                    (from peca in P
                     where verificarPosicao(peca.pos_x - 1, peca.pos_y - 1) == 0
                     && peca.time  == 2
                     select peca);
                if (p != null)
                {
                    foreach (Peca pi in p)
                        movimentos.Add(new Movimento(pi.pos_x, pi.pos_y, pi.pos_x - 1, pi.pos_y - 1, 2));
                }

                //Dama
                p =
                    (from peca in P
                     where verificarPosicao(peca.pos_x + 1, peca.pos_y + 1) == 0
                     && peca.time == 2
                     && peca.pecaDama
                     select peca);
                if (p != null)
                {
                    foreach (Peca pi in p)
                        movimentos.Add(new Movimento(pi.pos_x, pi.pos_y, pi.pos_x + 1, pi.pos_y + 1, 2));
                }
                p =
                    (from peca in P
                     where verificarPosicao(peca.pos_x - 1, peca.pos_y + 1) == 0
                     && peca.time == 2
                     && peca.pecaDama
                     select peca);
                if (p != null)
                {
                    foreach (Peca pi in p)
                        movimentos.Add(new Movimento(pi.pos_x, pi.pos_y, pi.pos_x - 1, pi.pos_y + 1, 2));
                }
            }
            movimentos = movimentos.OrderBy(x => x.ini_x).ToList();
            return movimentos;
        }

        public void movimento(Movimento m) {
            var p =
                (from peca in P
                 where peca.pos_x == m.ini_x
                 && peca.pos_y == m.ini_y
                 select peca).Single();

            p.pos_x = m.fim_x;
            p.pos_y = m.fim_y;

        }

        public void removerPeca(int x, int y) {
            Peca p = new Peca(0, -1, -1); //Peça inválida

            //Retorna peça na posição (x, y) se esta posição for válida
            if ((0 <= x && x <= 7) && (0 <= y && y <= 7))
            {
                p =
                    (from peca in P
                     where peca.pos_x == x
                     && peca.pos_y == y
                     select peca).SingleOrDefault();
            }
            this.P.Remove(p);
        }

    }
}
