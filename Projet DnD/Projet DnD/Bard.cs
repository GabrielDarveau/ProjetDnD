﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_DnD
{
    internal class Bard : Classe
    {
        const int DE = 8;
        const string NOM = "Bard";
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
