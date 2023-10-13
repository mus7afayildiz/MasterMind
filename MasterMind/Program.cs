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
            //
            Console.WriteLine("Bienvenue dans le jeu MasterMind");
            Console.WriteLine("Il s'agit d'un jeu de devinettes de couleurs.");
            Console.WriteLine("Si vous devinez respectivement 4 de ces 7 couleurs, vous gagnez la partie. Vous avez 10 suppositions.");
            Console.WriteLine("Comme couleurs, utilisez les lettres « G » pour Gris, « Y » pour Jaune, « W » pour Blanc, « R » pour Rouge, « B » pour Bleu, « M » pour Magenta et « C » pour Cyan.");
            Console.WriteLine("GYWRBMC");
            //Console.ReadLine();

            //Couleurs pouvant être choisies
            char[] couleurs = { 'G', 'Y', 'W', 'R', 'B', 'M', 'C'};
            char[] couleursParOrdinateur = new char[4];
            bool gegnerJeu = false;
            string couleursParUtilisateur = "";
            int compteurBienPlace=0;
            int compteurMalPlace = 0;
            int compteurTour = 1;
            //int compteurOpposé = 4;

            //L'ordinateur génère 4 nombres aléatoires compris entre 0 et 7.
            //Il utilise les nombres générés comme index. Ajoute les couleurs de cet index au nouveau array.
            Random random = new Random();   
            int index = random.Next(couleurs.Length);
          
            char[] charCouleuresdUtilisateur = new char[4];         

            for (int i = 0; i < 4; i++)
            {
                index = random.Next(couleurs.Length);           
                couleursParOrdinateur[i] = couleurs[index];               
            }

            couleursParOrdinateur = "CCBC".ToArray();
            Console.WriteLine(couleursParOrdinateur);
            //Console.ReadLine();

            while (!gegnerJeu && compteurTour < 10)
            {           
                //L'utilisateur est invité à choisir 4 couleurs. Les couleurs saisies sont transférées vers une variable et transformer uppercase.
                Console.WriteLine("Entrez 4 couleurs pour deviner.");
                couleursParUtilisateur = Console.ReadLine().ToUpper();

                if (couleursParUtilisateur.Length != 4)
                {
                    Console.WriteLine("Vous devez choisir 4 lettres pour couleurs");
                    continue;
                }



                /*                    //Les couleurs de l'ordinateur et de l'utilisateur sont comparées.
                                    for (int i = 0; i < 4; i++) {
                                        for (int j = 0; j < 4; j++) {
                                            Console.WriteLine("i : " + couleursParOrdinateur[i]);
                                            Console.WriteLine("j : " + couleursParUtilisateur[j]);
                                            Console.ReadLine();
                                            if (couleursParOrdinateur[i] == couleursParUtilisateur[j])
                                            {
                                                if (i == j)
                                                {
                                                Console.WriteLine("once : " + compteurBienPlace);
                                                compteurBienPlace++;
                                                Console.WriteLine("sonra: " + compteurBienPlace);
                                                break;
                                                }
                                                else if(i!=j)
                                                {                              
                                                    compteurMalPlace++;
                                                    break;                             
                                                }                                                
                                            }                                   
                                        }
                                    }

                */
                //Les couleurs de l'ordinateur et de l'utilisateur sont comparées.
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {                   
                        if ( (i == j) && (couleursParOrdinateur[i] == couleursParUtilisateur[j]))
                        {                      
                            Console.WriteLine("once : " + compteurBienPlace);
                            compteurBienPlace++;
                            Console.WriteLine("sonra: " + compteurBienPlace);
                            break;                        
                        }
                    }
                }

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if ((i != j) && (couleursParOrdinateur[i] == couleursParUtilisateur[j]))
                        {
                            Console.WriteLine("once : " + compteurMalPlace);
                            compteurMalPlace++;
                            Console.WriteLine("sonra: " + compteurMalPlace);
                            break;
                        }
                    }
                }








                Console.WriteLine(couleursParOrdinateur);
                Console.WriteLine("Essai " + compteurTour + " " + couleursParUtilisateur);
                Console.WriteLine("=> Ok: " + compteurBienPlace);
                Console.WriteLine("=> Mauvaise Position : " + compteurMalPlace);
                Console.ReadLine();
                

                if (compteurTour < 10 && compteurBienPlace == 4)
                {
                    Console.WriteLine("Felicitation vous gagnez :)");
                    Console.ReadLine();
                    gegnerJeu=true;
                    break;
                }
                else if(compteurTour==10)
                {
                    Console.WriteLine("Désole vous avez perdu :(");
                    Console.ReadLine();
                    break;
                }
                compteurBienPlace = 0;
                compteurMalPlace = 0;
                compteurTour++;
                Console.WriteLine(11 - compteurTour + " fois vous pouvez essaier");
                Console.ReadLine();
            }
            
        }
    }
}
