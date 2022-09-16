using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_DnD
{
    internal class Sorcerer : Classe
    {
        //Attributs
        const int DE = 6;
        const string NOM = "Sorcerer";
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
