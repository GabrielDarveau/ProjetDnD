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
        List<Perso> persos;

        //Constructeurs
        public Partie()
        {
            persos = new List<Perso>();
        }

        //Méthodes
        public void CreerPerso()
        {
            // Infos nécéssaires demandés à l'utilisateur: nom, classe, Race
            string nom;
            Classe maClasse;
            int numChoix;
            Race maRace;
            bool verif;
            //Demander Nom
            Console.Write("Entrez le nom de votre Personnage: ");
            nom = Console.ReadLine();

            // Demander Classe
            do
            {
                Console.WriteLine("1) Fighter   2)  Warlock      3) Bard    4)  Paladin\n" +
                                  "5) Barbarian 6)  Ranger       7) Rogue   8)  Cleric\n" +
                                  "9) Druid     10) Sorcerer    11) Wizard  12) Monk");
                Console.WriteLine("Entrez le numéro corespondant à la classe de votre choix: ");
                verif = int.TryParse(Console.ReadLine(), out numChoix);

            } while (!verif && numChoix <1 && numChoix > 12);
            switch (numChoix)
            {
                case 1:
                    maClasse = new Fighter();
                    break;

                case 2:maClasse = new Warlock();
                    break;

                case 3:
                    maClasse = new Bard();
                    break;

                case 4:
                    maClasse = new Paladin();
                    break;

                case 5:
                    maClasse = new Barbarian();
                    break;

                case 6:
                    maClasse = new Ranger();
                    break;

                case 7:
                    maClasse = new Rogue();
                    break;

                case 8:
                    maClasse = new Cleric();
                    break;

                case 9:
                    maClasse = new Druid();
                    break;

                case 10:
                    maClasse = new Sorcerer();
                    break;

                case 11:
                    maClasse = new Wizard();
                    break;

                case 12:
                    maClasse = new Monk();
                    break;
                default:
                    maClasse = new Fighter();
                    break;
            }

            // Demander Race
            do
            {
                Console.WriteLine("1) Tiefling    2) Human    3) Half-Orc   4)  Dragonborn\n" +
                                  "5) Dwarf       6) Elf      7) Gnome      8)  Half-Elf\n" +
                                  "9) Halfling");
                Console.WriteLine("Entrez le numéro corespondant à la Race de votre choix: ");
                verif = int.TryParse(Console.ReadLine(), out numChoix);

            } while (!verif && numChoix < 1 && numChoix > 9);
            switch (numChoix)
            {
                case 1:
                    maRace = new Tiefling();
                    break;

                case 2:
                    maRace = new Human();
                    break;

                case 3:
                    maRace = new HalfOrc();
                    break;

                case 4:
                    maRace = new Dragonborn();
                    break;

                case 5:
                    maRace = new Dwarf();
                    break;

                case 6:
                    maRace = new Elf();
                    break;
                case 7:
                    maRace = new Gnome();
                    break;

                case 8:
                    maRace = new HalfElf();
                    break;

                case 9:
                    maRace = new Halfling();
                    break;
                    default:
                    maRace = new Human();
                    break;
            }

            //Créer Perso et l'ajouter a la liste
            Perso monPerso = new Perso(nom, maClasse, maRace);
            persos.Add(monPerso);

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

        internal void InitialiserPerso(int posPerso)
        {
            //Donnés a initialiser: Habilités, PV

        }

        internal int LancerDe(int faces)
        {
            Random rnd = new Random();
            return rnd.Next(1, faces+1);
        }
    }
}
