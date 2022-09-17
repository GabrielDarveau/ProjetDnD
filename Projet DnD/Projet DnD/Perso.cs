using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_DnD
{
    public class Perso
    {
        //Attributs
        public string Nom { get; private set; }
        public int Niveau { get; set; }
        public int Pv { get; set; }
        public int Xp { get; set; }
        public int[] habilites = new int[6];
        /* Tableau d'habilités
         * [0]: Score Strength
         * [1]: Score Dexterity
         * [2]: Score Constitution
         * [3]: Score Intelligence
         * [4]: Score Wisdom
         * [5]: Score Charisma
         */
        Classe classePerso;
        Race racePerso;

        //Constructeurs
        public Perso(string leNom, Classe maClasse, Race maRace)
        {
            Nom = leNom;
            Niveau = 1;
            Xp = 0;
            classePerso = maClasse;
            racePerso = maRace;
        }

        public Perso(string leNom, Classe maClasse, Race maRace, int xp, int niv, int pv, int[] lesHabilites)
        {
            Nom = leNom;
            Niveau = niv;
            Xp = xp;
            classePerso = maClasse;
            racePerso = maRace;
            Pv = pv;
            habilites = lesHabilites;         
        }

        //Méthodes
        /// <summary>
        /// Retourne la classe du personnage
        /// </summary>
        /// <returns></returns>
        public Classe GetClasse()
        {
            return classePerso;
        }
        /// <summary>
        /// Retourne la race du personnage
        /// </summary>
        /// <returns></returns>
        public Race GetRace()
        {
            return racePerso;
        }
        /// <summary>
        /// Augmente le niveau, les points de vie et les habilités
        /// </summary>
        public void GagnerNiveau()
        {
            Niveau++;
            int modif = habilites[2] / 2 - 5;
            int de = classePerso.GetDe();
            int result = Partie.LancerDe(de) + modif;
            Pv = Pv + result;

            bool verif;
            int numChoix, augmentation;
            Console.Clear();
            do
            {
                Console.WriteLine("Félicitation vous avez monté de niveau!");
                Console.WriteLine("L'augmentation du niveau de votre joueur permet un choix entre deux options:\n" +
                    "1) Augmenter le score de deux habilités de 1\n" +
                    "2) Augmenter le score d'une habilité de 2");
                verif = int.TryParse(Console.ReadLine(), out augmentation);
            } while (!verif || augmentation < 1 || augmentation > 2);
            if (augmentation ==1)
            {
                for (int i = 0; i < 2; i++)
                {
                    do
                    {
                        Console.WriteLine("Quelle est l'habilité que vous voulez augmenter de 1" +
                            "\n1) Strength" +
                            "\n2) Dexterity" +
                            "\n3) Constitution" +
                            "\n4) Intelligence" +
                            "\n5) Wisdom" +
                            "\n6) Charisma");
                        verif = int.TryParse(Console.ReadLine(), out numChoix);
                        if (habilites[numChoix - 1] >= 20)
                        {
                            Console.WriteLine("L'habilité que vous avez choisi est déjà à son maximum");
                        }
                    } while (!verif || numChoix < 1 || numChoix > 6 || habilites[numChoix - 1] >= 20);

                    if (numChoix == 3 && habilites[2]%2 != 0)
                    {
                        Pv = Pv + (Niveau * 1);
                    }
                    habilites[numChoix - 1]++;

                }
            }
            else
            {
                do
                {
                    Console.WriteLine("Quelle est l'habilité que vous voulez augmenter de 2" +
                        "\n1) Strength" +
                        "\n2) Dexterity" +
                        "\n3) Constitution" +
                        "\n4) Intelligence" +
                        "\n5) Wisdom" +
                        "\n6) Charisma");
                    verif = int.TryParse(Console.ReadLine(), out numChoix);
                    if (habilites[numChoix - 1] >= 19)
                    {
                        Console.WriteLine("L'habilité que vous avez choisi est déjà à son maximum");
                    }
                } while (!verif || numChoix < 1 || numChoix > 6 || habilites[numChoix - 1] >= 19);
                if (numChoix == 3)
                {
                    Pv = Pv + (Niveau * 1);
                }
                habilites[numChoix - 1] = habilites[numChoix - 1] + 2;
            }
        }
        /// <summary>
        /// Retourne un niveau selon l'expérience (xp) passée en paramètre
        /// </summary>
        /// <param name="xp"></param>
        /// <returns></returns>
        public static int GetNiveau(int xp)
        {
            int niv = 0;
            switch (xp)
            {
                case int d when (d >= 0 && d < 300):
                    {
                        niv = 1;
                        break;
                    }
                case int d when (d >= 300 && d < 900):
                    {
                        niv = 2;
                        break;
                    }
                case int d when (d >= 900 && d < 2700):
                    {
                        niv = 3;
                        break;
                    }
                case int d when (d >= 2700 && d < 6500):
                    {
                        niv = 4;
                        break;
                    }
                case int d when (d >= 6500 && d < 14000):
                    {
                        niv = 5;
                        break;
                    }
                case int d when (d >= 14000 && d < 23000):
                    {
                        niv = 6;
                        break;
                    }
                case int d when (d >= 23000 && d < 34000):
                    {
                        niv = 7;
                        break;
                    }
                case int d when (d >= 34000 && d < 48000):
                    {
                        niv = 8;
                        break;
                    }
                case int d when (d >= 48000 && d < 64000):
                    {
                        niv = 9;
                        break;
                    }
                case int d when (d >= 64000 && d < 85000):
                    {
                        niv = 10;
                        break;
                    }
                case int d when (d >= 85000 && d < 100000):
                    {
                        niv = 11;
                        break;
                    }
                case int d when (d >= 100000 && d < 120000):
                    {
                        niv = 12;
                        break;
                    }
                case int d when (d >= 120000 && d < 140000):
                    {
                        niv = 13;
                        break;
                    }
                case int d when (d >= 140000 && d < 165000):
                    {
                        niv = 14;
                        break;
                    }
                case int d when (d >= 165000 && d < 195000):
                    {
                        niv = 15;
                        break;
                    }
                case int d when (d >= 195000 && d < 225000):
                    {
                        niv = 16;
                        break;
                    }
                case int d when (d >= 225000 && d < 265000):
                    {
                        niv = 17;
                        break;
                    }
                case int d when (d >= 265000 && d < 305000):
                    {
                        niv = 18;
                        break;
                    }
                case int d when (d >= 305000 && d < 355000):
                    {
                        niv = 19;
                        break;
                    }
                case int d when d >= 355000:
                    {
                        niv = 20;
                        break;
                    }
            }
            return niv;
        }
        /// <summary>
        /// Demande l'augmentation de l'expérience du personnage et augmente son expérience (xp)
        /// </summary>
        public void GagnerXp()
        {
            int niv1, niv2, xp;
            bool verif;

            do
            {
                Console.Write("Combien d'expérience voulez-vous gagner: ");
                verif = int.TryParse(Console.ReadLine(), out xp);
            } while (!verif || xp < 0);
            niv1 = GetNiveau(Xp);
            niv2 = GetNiveau(Xp + xp);
            niv1 = niv2 - niv1;
            Xp = Xp + xp;
            for (int i = 0; i < niv1; i++)
            {
                GagnerNiveau();
            }
        }

    }
}