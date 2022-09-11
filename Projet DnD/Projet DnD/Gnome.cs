using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_DnD
{
    internal class Gnome : Race
    {
        //Attributs
        int[] bonus = new int[6] { 0, 0, 0, 2, 0, 0 };
        const string NOM = "Gnome";
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
