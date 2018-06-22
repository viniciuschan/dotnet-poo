using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JogoDamas
{
    public class Peca
    {
        internal int time { get; set; }
        internal int pos_x { get; set; }
        internal int pos_y { get; set; }
        internal bool pecaDama { get; set; }

        public Peca(int t, int x, int y)
        {
            time = t;
            pos_x = x;
            pos_y = y;
        }
    }
}