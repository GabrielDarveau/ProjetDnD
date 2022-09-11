using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_DnD
{
    internal class Wizard : Classe
    {
        const int DE = 6;
        const string NOM = "Wizard";
        public override int Attaque()
        {
            return Partie.LancerDe(DE);
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
