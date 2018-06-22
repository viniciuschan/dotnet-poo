using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDamas
{
    public class Movimento
    {
        public int numero { get; set; }
        public int ini_x { get; set; }
        public int ini_y { get; set; }
        public int fim_x { get; set; }
        public int fim_y { get; set; }

        public Movimento(int a, int b, int c, int d, int numero)
        {
            ini_x = a;
            ini_y = b;
            fim_x = c;
            fim_y = d;
            numero = 0;
        }
    }
}