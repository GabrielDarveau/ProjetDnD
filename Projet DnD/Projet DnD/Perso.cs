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
        public string Nom{ get; private set; }
        public int Niveau{ get; private set; }
        public int Pv { get; set; }
        public int Xp { get; private set; }
        public int[] habilites = new int[6];
        /* Tableau d'habilités
         * [0]: Score Strenght
         * [1]: Score Dexterity
         * [2]: Score Constitution
         * [3]: Score Intelligence
         * [4]: Score Wisdom
         * [5]: Score Charisma
         */
        Classe classePerso;
        Race racePerso;

        //Constructeur
        public Perso(string leNom, Classe maClasse, Race maRace)
        {
            Nom = leNom;
            Niveau = 1;
            Xp = 0;
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
        public void GagnerNiveau()
        {
            int modif = habilites[2] / 2 - 5;
            int de = classePerso.GetDe();
            int result = Partie.LancerDe(de) + modif;
            Pv = Pv + result;
        }
    }
}
