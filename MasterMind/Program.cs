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
            Console.WriteLine("Bienvenue dans le jeu MasterMind");
            Console.WriteLine("Il s'agit d'un jeu de devinettes de couleurs.");
            Console.WriteLine("Si vous devinez respectivement 4 de ces 7 couleurs, vous gagnez la partie. Vous avez 10 suppositions.");
            Console.WriteLine("Comme couleurs, utilisez les lettres « G » pour Gris, « Y » pour Jaune, « W » pour Blanc, « R » pour Rouge, « B » pour Bleu, « M » pour Magenta et « C » pour Cyan.");
            Console.ReadLine();

            //Couleurs pouvant être choisies
            char[] couleurs = { 'G', 'Y', 'W', 'R', 'B', 'M', 'C'};
            char[] couleursParOrdinateur = new char[4];

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
            Console.WriteLine(couleursParOrdinateur);
            Console.ReadLine();

            bool gegnerJeu = false;
            string couleursUtilisateur="";
            char[] couleursJoueur = new char[4];   

            while (!gegnerJeu)
            {

            //L'utilisateur est invité à choisir 4 couleurs. Les couleurs saisies sont transférées vers une variable.
                Console.WriteLine("Entrez 4 couleurs pour deviner.");
                couleursUtilisateur = Console.ReadLine();

                couleursJoueur = couleursUtilisateur.ToCharArray();

                for (int i = 0; i < 3; i++)
                {
                    charCouleuresdUtilisateur[i] = couleurs[i];
                }
                Console.WriteLine("Utilisateur un renkleri :" + charCouleuresdUtilisateur);
                Console.ReadLine();




            }

            Console.WriteLine(couleursUtilisateur);
            Console.ReadLine();


        }
    }
}
