using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_DnD
{
    internal abstract class Classe
    {
        public abstract int Attaque();

        public abstract int GetDe();

        public abstract string GetNom();
    }
}
