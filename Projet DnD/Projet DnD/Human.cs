using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_DnD
{
    internal class Human : Race
    {
        //Attributs
        int[] bonus = new int[6] { 1, 1, 1, 1, 1, 1 };
        //Méthodes
        public override int[] GetBonus()
        {
            return bonus;
        }
    }
}
