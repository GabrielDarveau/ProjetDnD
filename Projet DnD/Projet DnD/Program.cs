using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_DnD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Executer();
        }

        /// <summary>
        /// éxecute toutes les fonctions du programme dans le bon ordre
        /// </summary>
        static void Executer()
        {
            bool erreur = false;
            Partie nvPartie = new Partie();
            //Charger les personnages à partir des fichiers csv valides 
            do
            {
                try
                {
                    erreur = false;
                    nvPartie.ChargerPersos();
                }
                catch (System.IO.IOException)
                {
                    Console.WriteLine("Fermez le fichier du personnage avant de continuer");
                    Console.ReadKey();
                    erreur = true;
                }
                catch(Exception e) 
                {
                    Console.WriteLine("Erreur: "+e);
                    Console.ReadKey();
                }

            } while (erreur);

            do
            {
                AfficherMenu();
                SelectAction(nvPartie);
            } while (true);
        }

        /// <summary>
        /// affiche le menu principal
        /// </summary>
        static void AfficherMenu()
        {
            Console.WriteLine();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~Menu Principal~~~~~~~~~~~~~~~~~~~~~~~") ;
            Console.WriteLine("A)Créer un nouveau personnage \t B)Afficher un personnage");
            Console.WriteLine("C)Attaquer \t\t\t D)Enregistrer un personnage");
            Console.WriteLine("E)Gagner le l'expérience \t F)Quitter");
        }

        /// <summary>
        /// Permet de sélectionner une action dans le menu et vérifier le choix puis lancer les fonctions correspondantes
        /// </summary>
        /// <param name="nvPartie"></param>
        static void SelectAction(Partie nvPartie)
        {
            bool verif;
            char choix;
            do
            {
                Console.Write("Choisissez une action: ");
                verif = char.TryParse(Console.ReadLine().ToUpper(), out choix);
            } while (!verif || choix < 'A' || choix >'F');

            if (nvPartie.persos.Count >0 || choix == 'A' || choix == 'F')
            {
                switch (choix)
                {
                    default:
                        break;
                    case 'A':
                        nvPartie.CreerPerso();
                        break;
                    case 'B':
                        nvPartie.AfficherPerso(SelectPerso(nvPartie));
                        break;
                    case 'C':
                        int posperso = SelectPerso(nvPartie);
                        Console.Write(nvPartie.persos[posperso].Nom);
                        nvPartie.persos[posperso].GetClasse().Attaque();
                        break;
                    case 'D':
                        nvPartie.EnregistrerPerso(SelectPerso(nvPartie));
                        break;
                    case 'E':
                        nvPartie.persos[SelectPerso(nvPartie)].GagnerXp();
                        break;
                    case 'F':
                        Environment.Exit(0);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Vous n'avez aucun personnage disponible");
            }
        }

        /// <summary>
        /// Permet de sélectionner un personnage à utiliser pour une action et vérifie le choix
        /// </summary>
        /// <param name="nvPartie"></param>
        /// <returns></returns>
        static int SelectPerso(Partie nvPartie)
        {
            bool verif;
            int posPerso;
            do
            {
                int numPerso = 1;
                foreach (var perso in nvPartie.persos)
                {
                    Console.Write(" Perso "+numPerso+": "+ perso.Nom);
                    numPerso++;
                }
                Console.WriteLine();
                Console.WriteLine("Quel personnage voulez vous utiliser (entrez le numéro du personnage): ");
                verif = int.TryParse(Console.ReadLine(), out posPerso);
                posPerso--;
            } while (!verif || posPerso >= nvPartie.persos.Count() || posPerso < 0);
            return posPerso;
        }
    }
}
