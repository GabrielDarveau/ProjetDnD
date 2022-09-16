using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_DnD
{
    internal class Ranger : Classe
    {
        //Attributs
        const int DE = 10;
        const string NOM = "Ranger";
        public override void Attaque()
        {
            Console.WriteLine(" attaque de "+Partie.LancerDe(DE));
        }
        public override int GetDe()
        {
            return DE;
        }
        public override string GetNom()
        {
            return NOM;
        }
    }
}
