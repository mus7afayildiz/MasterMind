///ETML
///Auteur : Mustafa Yildiz
///Date   : 27.10.2023
///Description : Vous demandez à l’ordinateur de créer n’importe quel nombre de couleurs aléatoires sur 7 couleurs. Vous essayez de deviner leur ordre.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    internal class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            //Couleurs pouvant être choisies.          
            int lengthDeCouleursParOrdinateur = 0;
            introduction();
            char[] couleurs = { 'G', 'Y', 'W', 'R', 'B', 'M', 'C' };
            char[] couleursParOrdinateur = new char[lengthDeCouleursParOrdinateur];
            bool gegnerJeu = false;
            string couleursParUtilisateur = " ";
            int compteurBienPlace = 0;
            int compteurMalPlace = 0;
            int compteurTour = 1;
            
            char[] couleursParUtilisateurManipule = new char[lengthDeCouleursParOrdinateur];
            char[] couleursParOrdinateurManipule = new char[lengthDeCouleursParOrdinateur];
            genereCouleurs();
            
            //utilisée pour contrôller
            //couleursParOrdinateur = "BBGB".ToArray();          
            //Console.WriteLine(couleursParOrdinateur);           
            
            //Le jeu continue jusqu'à ce que vous gagniez ou perdiez.
            while (!gegnerJeu && compteurTour <= 10)
            {
                demandeCouleurs();                
                compareMemeIndex();
                compareDifferentIndex();
                montreResultat();

                if (compteurTour < 10 && compteurBienPlace == lengthDeCouleursParOrdinateur)
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

            //LES FONCTIONS

            //introduction de jeu.
            void introduction()
            {
                Console.WriteLine("Bienvenue dans le jeu MasterMind \n ");
                Console.WriteLine("Il s'agit d'un jeu de devinettes de couleurs.");
                Console.WriteLine("Si vous devinez respectivement la longueur que vous choisissez de ces 7 couleurs, vous gagnez la partie. Vous avez 10 suppositions.\n");
                Console.WriteLine("Comme couleurs, utilisez les lettres « G » pour Gris, « Y » pour Jaune, « W » pour Blanc, « R » pour Rouge, « B » pour Bleu, « M » pour Magenta et « C » pour Cyan.");
                Console.WriteLine("Les Couleurs Possibles : GYWRBMC \n");
                Console.WriteLine("Combien de chiffres voulez-vous dans un jeu de devinettes ? Veuillez entrer un nombre. 1-9");
                lengthDeCouleursParOrdinateur = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(lengthDeCouleursParOrdinateur);
            }

            //L'ordinateur génère 4 nombres aléatoires compris entre 0 et 7.
            //Il utilise les nombres générés comme index. Ajoute les couleurs de cet index au nouveau array.
            void genereCouleurs()
            {              
                int index = random.Next(couleurs.Length);
                for (int i = 0; i < lengthDeCouleursParOrdinateur; i++)
                {
                    index = random.Next(couleurs.Length);
                    couleursParOrdinateur[i] = couleurs[index];
                }
            }

            //L'utilisateur est invité à choisir 4 couleurs. Les couleurs saisies sont transférées vers une variable et transformer uppercase et char.
            void demandeCouleurs()
            {
                Console.WriteLine("Entrez " + lengthDeCouleursParOrdinateur + " couleurs pour deviner.");
                couleursParUtilisateur = Console.ReadLine().ToUpper();
                couleursParUtilisateurManipule = couleursParUtilisateur.ToCharArray();
                couleursParOrdinateurManipule = (char[])couleursParOrdinateur.Clone();              
                verifieDonne();
            }

            //La validité de la sélection de couleurs saisie et du nombre de caractères est vérifiée.
            void verifieDonne()
            {
                if (couleursParUtilisateur.Length != lengthDeCouleursParOrdinateur)
                {
                    Console.WriteLine("Vous devez choisir " + lengthDeCouleursParOrdinateur + " lettres pour couleurs. \n");
                    demandeCouleurs();
                }
                else if (couleursParUtilisateur.Length == lengthDeCouleursParOrdinateur)
                {
                    for (int i = 0; i < couleurs.Length; i++)
                    {
                        for (int j = 0; j < couleursParUtilisateur.Length; j++)
                        {
                            if (!couleurs.Contains(couleursParUtilisateur[j]))
                            {
                                Console.WriteLine("Vous devez choisir " + lengthDeCouleursParOrdinateur + " couleurs souhaitées. \n");
                                demandeCouleurs();
                                break;
                            }
                        }
                    }
                }
            }            
            
            //Les couleurs de l'ordinateur et de l'utilisateur sont comparées par même index.
            void compareMemeIndex()
            {
                for (int i = 0; i < lengthDeCouleursParOrdinateur; i++)
                {                
                    if (couleursParOrdinateur[i] == couleursParUtilisateurManipule[i])
                    {
                        couleursParOrdinateurManipule[i] = '0';
                        couleursParUtilisateurManipule[i] = '1';                           
                        compteurBienPlace++;                      
                    }                 
                }
            }

            //Les couleurs de l'ordinateur et de l'utilisateur sont comparées par different index.
            void compareDifferentIndex()
            {
                for (int i = 0; i < lengthDeCouleursParOrdinateur; i++)
                {
                    for (int j = 0; j < lengthDeCouleursParOrdinateur; j++)
                    {
                        if ((i != j) && (couleursParOrdinateurManipule[i] == couleursParUtilisateurManipule[j]))
                        {
                            couleursParOrdinateurManipule[i] = 'X';
                            couleursParUtilisateurManipule[j] = 'Z';                          
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
                Console.Write("Les Couleurs Possibles: ");
                Console.WriteLine(couleurs);
                Console.WriteLine("Essai " + compteurTour + " " + couleursParUtilisateur);
                Console.WriteLine("=> Ok: " + compteurBienPlace);
                Console.WriteLine("=> Mauvaise Position : " + compteurMalPlace + "\n");
            }
        }
    }
}
