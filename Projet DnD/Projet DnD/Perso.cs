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
        Classe classePerso;
        Race racePerso;

        //Constructeur
        public Perso(string leNom, Classe maClasse, Race maRace)
        {
            nom = leNom;
            niveau = 1;
            xp = 0;
            classePerso = maClasse;
            racePerso = maRace;
        }
        //Méthodes
        public Classe GetClasse()
        {
            return classePerso;
        }
        public Race GetRace()
        {
            return racePerso;
        }
    }
}
