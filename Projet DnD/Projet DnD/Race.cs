using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_DnD
{
    public abstract class Race
    {
        /// <summary>
        /// Retourne un tableau des bonus pour chaque habilité
        /// </summary>
        /// <returns></returns>
        public abstract int[] GetBonus();
        /// <summary>
        /// Retourne le nom de la race
        /// </summary>
        /// <returns></returns>
        public abstract string GetNom();
    }
}
