using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_DnD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Partie nvPartie = new Partie();
            nvPartie.CreerPerso();
            nvPartie.InitialiserPerso(0);

            for (int i = 0; i < 6; i++)
            {
                Console.Write(nvPartie.persos[0].habilites[i]+" ");
            }
            nvPartie.EnregistrerPerso(0);
            nvPartie.ChargerPersos();
            Console.ReadKey();
        }
    }
}
