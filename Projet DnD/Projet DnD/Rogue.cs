using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_DnD
{
    internal class Rogue : Classe
    {
        const int DE = 8;
        public override int Attaque()
        {
            return Partie.LancerDe(DE);
        }
        public override int GetDe()
        {
            return DE;
        }
    }
}
