using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_DnD
{
    internal class Tiefling:Race
    {
        //Attributs
        int[] bonus = new int[6] { 0, 0, 0, 1, 0, 2 };
        const string NOM = "Tiefling";
        public override int[] GetBonus()
        {
            return bonus;
        }
        public override string GetNom()
        {
            return NOM;
        }
    }
}
