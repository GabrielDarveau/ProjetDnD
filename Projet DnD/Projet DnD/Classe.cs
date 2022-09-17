using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_DnD
{
    public abstract class Classe
    {
        /// <summary>
        /// Affiche le jet d'attaque du personnage
        /// </summary>
        public abstract void Attaque();
        /// <summary>
        /// Retourne le dé du personnage
        /// </summary>
        /// <returns></returns>
        public abstract int GetDe();
        /// <summary>
        /// Retourne le nom de la classe
        /// </summary>
        /// <returns></returns>
        public abstract string GetNom();
    }
}
