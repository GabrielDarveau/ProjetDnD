﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_DnD
{
    internal class Partie
    {
        //Attributs
        public List<Perso> persos = new List<Perso>();
        static Random rnd = new Random();

        //Constructeurs
        public Partie()
        {
            persos = new List<Perso>();
        }

        //Méthodes
        public void CreerPerso()
        {
            // Infos nécéssaires demandées à l'utilisateur: nom, classe, Race
            string nom;
            Classe maClasse;
            int numChoix;
            Race maRace;
            bool verif;
            //Demander Nom
            Console.Write("Entrez le nom de votre Personnage: ");
            nom = Console.ReadLine();

            //Demander Classe
            do
            {
                Console.WriteLine("1) Fighter   2)  Warlock      3) Bard    4)  Paladin\n" +
                                  "5) Barbarian 6)  Ranger       7) Rogue   8)  Cleric\n" +
                                  "9) Druid     10) Sorcerer    11) Wizard  12) Monk");
                Console.WriteLine("Entrez le numéro corespondant à la classe de votre choix: ");
                verif = int.TryParse(Console.ReadLine(), out numChoix);

            } while (!verif || numChoix <1 || numChoix > 12);

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

            //Demander Race
            do
            {
                Console.WriteLine("1) Tiefling    2) Human    3) Half-Orc   4)  Dragonborn\n" +
                                  "5) Dwarf       6) Elf      7) Gnome      8)  Half-Elf\n" +
                                  "9) Halfling");
                Console.WriteLine("Entrez le numéro corespondant à la Race de votre choix: ");
                verif = int.TryParse(Console.ReadLine(), out numChoix);

            } while (!verif || numChoix < 1 || numChoix > 9);
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

            //Créer Perso et l'ajouter à la liste
            Perso monPerso = new Perso(nom, maClasse, maRace);
            persos.Add(monPerso);

        }
        public void ChargerPerso()
        {

        }
        internal void EnregistrerPerso()
        {

        }
        internal void AfficherPerso(int posPerso)
        {
            int pos = posPerso + 1;
            Console.Clear();
            Console.WriteLine("~~~~~Personnage numéro "+pos+"~~~~~");
            Console.WriteLine("Nom: \t\t" + persos[posPerso].Nom);
            Console.WriteLine("Classe: \t" + persos[posPerso].GetClasse().GetNom());
            Console.WriteLine("Race: \t\t" + persos[posPerso].GetRace().GetNom());
            Console.WriteLine("Niveau: \t" + persos[posPerso].Niveau);
        }

        internal void InitialiserPerso(int posPerso)
        {
            int bonus;
            //Données à initialiser: Habilités, PV
            for (int i = 0; i < 6; i++)
            {
                switch (i)
                {
                    default:
                        break;
                    case 0:
                        Console.Write("Votre score de force est: ");
                        break;
                    case 1:
                        Console.Write("Votre score de dextérité est: ");
                        break;
                    case 2:
                        Console.Write("Votre score de constitution est: ");
                        break;
                    case 3:
                        Console.Write("Votre score de intelligence est: ");
                        break;
                    case 4:
                        Console.Write("Votre score de sagesse est: ");
                        break;
                    case 5:
                        Console.Write("Votre score de charisme est: ");
                        break;
                }

                //Rouler 4 dés 6 et prendre la somme des 3 meilleurs
                int result;
                int[] lances = new int[4];
                for (int j = 0; j < lances.Length; j++)
                {
                    lances[j] = LancerDe(6);
                }
                result = lances[0] + lances[1] + lances[2] + lances[3] - lances.Min();
                bonus = persos[posPerso].GetRace().GetBonus()[i];
                Console.WriteLine(result+" avec un bonus de : "+bonus);
                persos[posPerso].habilites[i] = result + bonus;

                //Rouler le dé selon la classe et ajouter le modificateur de constitution
                int pv;
                pv = LancerDe(persos[posPerso].GetClasse().GetDe()) + (persos[posPerso].habilites[2] / 2-5);
                persos[posPerso].SetPv(pv);
            }
        }

        public static int LancerDe(int faces)
        {
            return rnd.Next(1, faces+1);
        }
    }
}
