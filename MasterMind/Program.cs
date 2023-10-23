using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Couleurs pouvant être choisies.
            char[] couleurs = { 'G', 'Y', 'W', 'R', 'B', 'M', 'C' };
            char[] couleursParOrdinateur = new char[4];
            bool gegnerJeu = false;
            string couleursParUtilisateur = " ";
            int compteurBienPlace = 0;
            int compteurMalPlace = 0;
            int compteurTour = 1;

            char[] couleursParUtilisateurManipule = new char[4];
            char[] couleursParOrdinateurManipule = new char[4];

            introduction();
            genereCouleurs();
            

            //couleursParOrdinateur = "BBGB".ToArray();
            Console.WriteLine("ordina");
            Console.WriteLine(couleursParOrdinateur);
            Console.WriteLine(couleursParOrdinateurManipule);
            Console.WriteLine("Mani");
            //Console.ReadLine();
            
            //Le jeu continue jusqu'à ce que vous gagniez ou perdiez.
            while (!gegnerJeu && compteurTour <= 10)
            {
                demandeCouleurs();
                //Comparer(couleursParOrdinateurManipule, couleursParUtilisateurManipule);
                compareMemeIndex();
                compareDifferentIndex();
                montreResultat();

                if (compteurTour < 10 && compteurBienPlace == 4)
                {
                    Console.WriteLine("Félicitations, Vous avez Gagné. :) ");
                    Console.ReadLine();
                    gegnerJeu = true;
                    break;
                }
                else if (compteurTour == 10)
                {
                    Console.WriteLine("Désole, Vous avez Perdu :( ");
                    Console.ReadLine();
                    break;
                }

                compteurBienPlace = 0;
                compteurMalPlace = 0;
                compteurTour++;
                Console.WriteLine("Encore " + (11 - compteurTour) + " fois vous pouvez essaier. \n");
            }

            //introduction de jeu.
            void introduction()
            {
                Console.WriteLine("Bienvenue dans le jeu MasterMind \n ");
                Console.WriteLine("Il s'agit d'un jeu de devinettes de couleurs.");
                Console.WriteLine("Si vous devinez respectivement 4 de ces 7 couleurs, vous gagnez la partie. Vous avez 10 suppositions.\n");
                Console.WriteLine("Comme couleurs, utilisez les lettres « G » pour Gris, « Y » pour Jaune, « W » pour Blanc, « R » pour Rouge, « B » pour Bleu, « M » pour Magenta et « C » pour Cyan.");
                Console.WriteLine("GYWRBMC \n");
            }

            //L'ordinateur génère 4 nombres aléatoires compris entre 0 et 7.
            //Il utilise les nombres générés comme index. Ajoute les couleurs de cet index au nouveau array.
            void genereCouleurs()
            {
                Random random = new Random();
                int index = random.Next(couleurs.Length);
                for (int i = 0; i < 4; i++)
                {
                    index = random.Next(couleurs.Length);
                    couleursParOrdinateur[i] = couleurs[index];
                }
            }

            //L'utilisateur est invité à choisir 4 couleurs. Les couleurs saisies sont transférées vers une variable et transformer uppercase et char.
            void demandeCouleurs()
            {
                Console.WriteLine("Entrez 4 couleurs pour deviner.");
                couleursParUtilisateur = Console.ReadLine().ToUpper();
                couleursParUtilisateurManipule = couleursParUtilisateur.ToCharArray();
                couleursParOrdinateurManipule = (char[])couleursParOrdinateur.Clone();
                Console.WriteLine(couleursParUtilisateurManipule);
                verifieDonne();
            }

            //La validité de la sélection de couleurs saisie et du nombre de caractères est vérifiée.
            void verifieDonne()
            {
                if (couleursParUtilisateur.Length != 4)
                {
                    Console.WriteLine("Vous devez choisir 4 lettres pour couleurs. \n");
                    demandeCouleurs();
                }
                else if (couleursParUtilisateur.Length == 4)
                {
                    for (int i = 0; i < couleurs.Length; i++)
                    {
                        for (int j = 0; j < couleursParUtilisateur.Length; j++)
                        {
                            if (!couleurs.Contains(couleursParUtilisateur[j]))
                            {
                                Console.WriteLine("Vous devez choisir 4 couleurs souhaitées. \n");
                                demandeCouleurs();
                                break;
                            }
                        }
                    }
                }
            }
            /*
            void Comparer(char[] ord, char[] uti) {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if ((i == j) && (ord[i] == uti[j]))
                        {
                            ord[i] = '0';
                            uti[j] = '1';
                            Console.WriteLine(couleursParOrdinateur);
                            Console.Write("ord :");
                            Console.WriteLine(ord);
                           
                            Console.WriteLine(couleursParUtilisateur);
                            Console.Write("ut :");                          
                            Console.WriteLine(uti);
                            compteurBienPlace++;
                            break;
                        }
                    }
                }
            
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if ((i != j) && (ord[i] == uti[j]))
                        {
                            ord[i] = 'X';
                            uti[j] = 'Z';
                            Console.WriteLine(couleursParOrdinateur);
                            Console.Write("orddif :");                          
                            Console.WriteLine(ord);
                            Console.WriteLine("/n");
                            Console.WriteLine(couleursParUtilisateur);                           
                            Console.Write("utdif :");                        
                            Console.WriteLine(uti);
                            compteurMalPlace++;
                            break;
                        }
                    }
                }


          

            }

  */

            
            //Les couleurs de l'ordinateur et de l'utilisateur sont comparées par même index.
            void compareMemeIndex()
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if ((i == j) && (couleursParOrdinateur[i] == couleursParUtilisateurManipule[j]))
                        {
                            couleursParOrdinateurManipule[i] = '0';
                            couleursParUtilisateurManipule[j] = '1';
                            Console.WriteLine(" ");
                            Console.Write("ord :");
                            Console.WriteLine(couleursParOrdinateur);
                            Console.WriteLine(ordCol);
                            Console.WriteLine(couleursParOrdinateurManipule);
                            Console.Write("ut :");
                            Console.WriteLine(couleursParUtilisateur);
                            Console.WriteLine(couleursParUtilisateurManipule);
                            compteurBienPlace++;
                            break;
                        }
                    }
                }
            }

            //Les couleurs de l'ordinateur et de l'utilisateur sont comparées par different index.
            void compareDifferentIndex()
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if ((i != j) && (couleursParOrdinateurManipule[i] == couleursParUtilisateurManipule[j]))
                        {
                            couleursParOrdinateurManipule[i] = 'X';
                            couleursParUtilisateurManipule[j] = 'Z';
                            Console.WriteLine(couleursParUtilisateurManipule[j]);
                            Console.Write("orddif :");
                            Console.WriteLine(couleursParOrdinateur);
                            Console.WriteLine(couleursParOrdinateur);
                            Console.WriteLine(couleursParOrdinateurManipule);
                            Console.Write("utdif :");
                            Console.WriteLine(couleursParUtilisateur);
                            Console.WriteLine(couleursParUtilisateurManipule);
                            compteurMalPlace++;
                            break;
                        }
                    }
                }
            }
            

            //Après évaluation, le résultat est affiché sur la console.
            void montreResultat()
            {
                Console.WriteLine(" ");
                Console.WriteLine(couleursParOrdinateur);
                Console.Write("Les Couleurs Possibles: ");
                Console.WriteLine(couleurs);
                Console.WriteLine("Essai " + compteurTour + " " + couleursParUtilisateur);
                Console.WriteLine("=> Ok: " + compteurBienPlace);
                Console.WriteLine("=> Mauvaise Position : " + compteurMalPlace + "\n");
            }
        }
    }
}
