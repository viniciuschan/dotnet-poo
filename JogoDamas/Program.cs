using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDamas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bora jogar Damas ihull o/");
            Jogo damas = new Jogo();
            damas.comecarJogo();
        }
    }
}
