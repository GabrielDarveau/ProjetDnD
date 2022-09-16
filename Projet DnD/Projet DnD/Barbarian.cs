using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_DnD
{
    internal class Barbarian : Classe
    {
        //attributs
        const int DE = 12;
        const string NOM = "Barbarian";

        //Fonctions
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
