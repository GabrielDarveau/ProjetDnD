using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_DnD
{
    internal class Fighter:Classe
    {
        const int DE = 10;
        Random alea = new Random();
        public override int Attaque()
        {
            return alea.Next(1, 11);
        }
        public override int GetDe()
        {
            return DE;
        }
    }
}
