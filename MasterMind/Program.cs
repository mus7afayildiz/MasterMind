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
            char[] couleurs = { 'G', 'Y', 'W', 'R', 'B', 'M', 'C'};
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
          
            //couleursParOrdinateur = "CCBC".ToArray();
            //Console.WriteLine(couleursParOrdinateur);      
            //Console.ReadLine();

            //Le jeu continue jusqu'à ce que vous gagniez ou perdiez.
            while (!gegnerJeu && compteurTour <= 10)
            {
                demandeCouleurs();               
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
                else if(compteurTour==10)
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
                couleursParUtilisateur = Console.ReadLine().ToUpper() ;
                couleursParUtilisateurManipule = couleursParUtilisateur.ToCharArray();
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
                } else if (couleursParUtilisateur.Length == 4) {
                    for (int i = 0; i < couleurs.Length; i++)
                    {
                        for (int j = 0; j < couleursParUtilisateurManipule.Length; j++)
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

            //Les couleurs de l'ordinateur et de l'utilisateur sont comparées par même index.
            void compareMemeIndex()
            { 
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if ((i == j) && (couleursParOrdinateur[i] == couleursParUtilisateurManipule[j]))
                        {
                            couleursParUtilisateurManipule[j] = 'X';
                            couleursParOrdinateurManipule[i] = 'Y';
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
                            couleursParUtilisateurManipule[j] = 'X';
                            Console.WriteLine(couleursParUtilisateur[j]);
                            compteurMalPlace++;                          
                            break;
                        }
                    }
                }
            }

            //Après évaluation, le résultat est affiché sur la console.
            void montreResultat()
            {
                Console.WriteLine(couleursParOrdinateur);
                Console.WriteLine("Essai " + compteurTour + " " + couleursParUtilisateur);
                Console.WriteLine("=> Ok: " + compteurBienPlace);
                Console.WriteLine("=> Mauvaise Position : " + compteurMalPlace + "\n");              
            }
        }
    }
}
