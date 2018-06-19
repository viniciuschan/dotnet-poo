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
        public int xi { get; set; }
        public int yi { get; set; }
        public int xn { get; set; }
        public int yn { get; set; }

        public Movimento(int a, int b, int c, int d, int numero)
        {
            xi = a;
            yi = b;
            xn = c;
            yn = d;
            numero = 0;
        }
    }
}