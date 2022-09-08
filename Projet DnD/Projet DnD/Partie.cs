using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_DnD
{
    internal class Partie
    {
        //Attributs
        List<Partie> parties;

        //Constructeurs
        public Partie()
        {

        }

        //Méthodes
        public void CreerPerso()
        {
            
        }
        public void ChargerPerso()
        {

        }
        internal void EnregistrerPerso()
        {

        }
        internal void AfficherPerso()
        {

        }

        internal void InitialiserPerso()
        {

        }

        internal int LancerDe(int faces)
        {
            Random rnd = new Random();
            return rnd.Next(1, faces);
        }
    }
}
