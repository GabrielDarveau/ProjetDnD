using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_DnD
{
    internal class HalfOrc : Race
    {
        //Attributs
        int[] bonus = new int[6] { 2, 0, 1, 0, 0, 0 };
        const string NOM = "Half-Orc";
        //Méthodes
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
