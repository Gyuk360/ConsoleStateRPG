using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleStateRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
			// Questo istanziamento chiama il costruttore che contiene al suo interno i metodi di inizzializzazione
			Game game = new Game(); 
            game.Run();
        }
    }
}
