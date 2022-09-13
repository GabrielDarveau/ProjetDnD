using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            maRace = TrouverRace(numChoix, null);

            //Créer Perso et l'ajouter à la liste
            Perso monPerso = new Perso(nom, maClasse, maRace);
            persos.Add(monPerso);

        }
        public bool ChargerPersos()
        {
            DirectoryInfo d = new DirectoryInfo(Directory.GetCurrentDirectory());

            foreach (var fichier in d.GetFiles("*.csv"))
            {
                FileStream file = new FileStream(fichier.FullName, FileMode.Open);
                StreamReader sr = new StreamReader(file);
                using (sr)
                {
                    //Vérifications: première ligne est identique, Race valide, classe valide, attributs réalistes
                    string ligne1;
                    string ligne2;
                    ligne1 = sr.ReadLine();
                    ligne2 = sr.ReadLine();
                    string[] champs = ligne2.Split(',');
                    Race race;
                    Classe classe;
                    int xp;
                    int[] habilites = new int[6];
                    bool verif = false;
                    if (ligne1.Equals("Nom, Race, Classe, PV, EXP, Strenght, Dexterity, Constitution, Intelligence, Wisdom, Charisma"))
                    {
                        //Validation Race
                        if (champs[1].Trim() == "Dragonborn" || champs[1].Trim() == "Dwarf" || champs[1].Trim() == "Elf" || champs[1].Trim() == "Gnome" || champs[1].Trim() == "Half-Elf" || champs[1].Trim() == "Halfling" || champs[1].Trim() == "Half-Orc" || champs[1].Trim() == "Human" || champs[1].Trim() == "Tiefling")
                        {
                            race = TrouverRace(0, champs[1]);
                            //Validation Classe
                            if (champs[2].Trim() == "Barbarian" || champs[2].Trim() == "Bard" || champs[2].Trim() == "Cleric" || champs[2].Trim() == "Druid" || champs[2].Trim() == "Fighter" || champs[2].Trim() == "Monk" || champs[2].Trim() == "Paladin" || champs[2].Trim() == "Ranger" || champs[2].Trim() == "Rogue" || champs[2].Trim() == "Sorcerer" || champs[2].Trim() == "Warlock" || champs[2].Trim() == "Wizard")
                            {
                                classe = TrouverClasse(0, champs[2]);
                                //validation XP
                                if (int.TryParse(champs[3], out xp) && xp <355000 && xp>=0)
                                {
                                    //Validation habilités
                                    for(int i = 5; i<6; i++)
                                    {
                                        if (int.TryParse(champs[i], out habilites[i - 5]) && habilites[i - 5] < (GetNiveau(xp) * 2) + 2 && habilites[i - 5] <= 20 && habilites[i - 5] >= 0)
                                        {
                                            verif = true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                    //validation PV
                                    if (verif)
                                    {

                                    }
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        internal void EnregistrerPerso(int posPerso)
        {
            FileStream monFichier = new FileStream("Perso"+posPerso+".csv",FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(monFichier);
            using (sw)
            {
                sw.WriteLine("Nom, Race, Classe, PV, EXP, Strenght, Dexterity, Constitution, Intelligence, Wisdom, Charisma");
                sw.Write(persos[posPerso].Nom +", ");
                sw.Write(persos[posPerso].GetRace().GetNom() + ", ");
                sw.Write(persos[posPerso].GetClasse().GetNom() + ", ");
                sw.Write(persos[posPerso].Pv+", ");
                sw.Write(persos[posPerso].Xp+", ");
                sw.Write(persos[posPerso].habilites[0] + ", ");
                sw.Write(persos[posPerso].habilites[1] + ", ");
                sw.Write(persos[posPerso].habilites[2] + ", ");
                sw.Write(persos[posPerso].habilites[3] + ", ");
                sw.Write(persos[posPerso].habilites[4] + ", ");
                sw.WriteLine(persos[posPerso].habilites[5]);
            }
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
                do
                {
                    for (int j = 0; j < lances.Length; j++)
                    {
                        lances[j] = LancerDe(6);
                    }
                    result = lances[0] + lances[1] + lances[2] + lances[3] - lances.Min();
                } while (result < 8);
                bonus = persos[posPerso].GetRace().GetBonus()[i];
                Console.WriteLine(result+" avec un bonus de : "+bonus);
                persos[posPerso].habilites[i] = result + bonus;

                //Rouler le dé selon la classe et ajouter le modificateur de constitution
                int pv;
                pv = LancerDe(persos[posPerso].GetClasse().GetDe()) + (persos[posPerso].habilites[2] / 2-5);
                persos[posPerso].Pv = pv;
            }
        }

        public static int LancerDe(int faces)
        {
            return rnd.Next(1, faces+1);
        }

        private Race TrouverRace(int raceInt, string raceString)
        {
            Race race;
            if (string.IsNullOrEmpty(raceString))
            {
                Dictionary<int, string> dictioRace = new Dictionary<int, string>();
                dictioRace.Add(1, "Tiefling");
                dictioRace.Add(2, "Human");
                dictioRace.Add(3, "Half-Orc");
                dictioRace.Add(4, "Dragonborn");
                dictioRace.Add(5, "Dwarf");
                dictioRace.Add(6, "Elf");
                dictioRace.Add(7, "Gnome");
                dictioRace.Add(8, "Half-Elf");
                dictioRace.Add(9, "Halfling");
                dictioRace.TryGetValue(raceInt, out raceString);
            }

            switch (raceString)
            {
                case "Tiefling":
                    race = new Tiefling();
                    break;
                case "Human":
                    race = new Human();
                    break;
                case "Half-Orc":
                    race = new HalfOrc();
                    break;
                case "Dragonborn":
                    race = new Dragonborn();
                    break;
                case "Dwarf":
                    race = new Dwarf();
                    break;
                case "Elf":
                    race = new Elf();
                    break;
                case "Gnome":
                    race = new Gnome();
                    break;
                case "Half-Elf":
                    race = new HalfElf();
                    break;
                case "Halfling":
                    race = new Halfling();
                    break;
                default:
                    race = new Human();
                    break;

            }
            return race;
        }

        private Classe TrouverClasse(int classeInt, string classeString)
        {
            Classe classe;
            if (string.IsNullOrEmpty(classeString))
            {
                Dictionary<int, string> dictioClasse = new Dictionary<int, string>();
                dictioClasse.Add(1, "Fighter");
                dictioClasse.Add(2, "Warlock");
                dictioClasse.Add(3, "Bard");
                dictioClasse.Add(4, "Paladin");
                dictioClasse.Add(5, "Barbarian");
                dictioClasse.Add(6, "Ranger");
                dictioClasse.Add(7, "Rogue");
                dictioClasse.Add(8, "Cleric");
                dictioClasse.Add(9, "Druid");
                dictioClasse.Add(10, "Sorcerer");
                dictioClasse.Add(11, "Wizard");
                dictioClasse.Add(12, "Monk");
                dictioClasse.TryGetValue(classeInt, out classeString);
            }

            switch (classeString)
            {
                case "Fighter":
                    classe = new Fighter();
                    break;
                case "Warlock":
                    classe = new Warlock();
                    break;
                case "Bard":
                    classe = new Bard();
                    break;
                case "Paladin":
                    classe = new Paladin();
                    break;
                case "Barbarian":
                    classe = new Barbarian();
                    break;
                case "Ranger":
                    classe = new Ranger();
                    break;
                case "Rogue":
                    classe = new Rogue();
                    break;
                case "Cleric":
                    classe = new Cleric();
                    break;
                case "Druid":
                    classe = new Druid();
                    break;
                case "Sorcerer":
                    classe = new Sorcerer();
                    break;
                case "Wizard":
                    classe = new Wizard();
                    break;
                case "Monk":
                    classe = new Monk();
                    break;
                default:
                    classe = new Fighter();
                    break;

            }
            return classe;
        }
    }
}
