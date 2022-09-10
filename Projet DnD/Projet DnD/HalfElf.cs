using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_DnD
{
    internal class HalfElf : Race
    {
        //Attributs
        int[] bonus = new int[6] { 0, 0, 0, 0, 0, 2 };
        //Méthodes
        public override int[] GetBonus()
        {
            return bonus;
        }
    }
}
