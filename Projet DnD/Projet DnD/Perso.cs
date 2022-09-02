using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_DnD
{
    internal class Perso
    {
        //Attributs
        string nom;
        int niveau;
        int pv;
        int xp;
        int[] habilites = new int[6];
        Classe classePerso = new Classe();
        Race racePerso = new Race();

        //Constructeur
        public Perso()
        {

        }
        //Méthodes
        public Classe GetClasse()
        {
            return classePerso;
        }
    }
}
