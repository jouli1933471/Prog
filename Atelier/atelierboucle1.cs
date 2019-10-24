using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fonction2
{
    class Program
    {
        static void AfficherIntro()
        {
            Console.WriteLine("Bienvenue au guichet interactif Vince. INC");
        }

        static int ChoisirOption()
        {
            Console.WriteLine("Veuillez choisir l'option qui vous interesse ");
            Console.WriteLine("1- trouver le plus grand nombre ");
            Console.WriteLine("2- trouver le plus peit nombre ");
            Console.WriteLine("3- verifier que le nombre saisi est dans le tableau ");
            Console.WriteLine("4- faire la moyenne");
            Console.WriteLine("5- Quitter ");
            return Convert.ToInt32(Console.ReadLine());

        }

        static void AfficherPlusGrand(ref int[] tab)
        {
            int plusGrandNb = 0;
            for (int i = 0;i<tab.Length; i++ )
            {
                if (tab[i] > plusGrandNb)
                    plusGrandNb = tab[i];
            }
        }

        static void AfficherPlusPetit(ref int[] tab)
        {
            int plusPetitNb = 0;
            for (int i = 0; i < tab.Length; i++)
            {
                if (tab[i] < plusPetitNb)
                    plusPetitNb = tab[i];
            }
        }

        static void AfficherNbDansTableau(ref int[] tab)
        {
            Console.WriteLine("veuillez entrer un nombre pour qu'il soit vérifié ");

            int cpt = 0;

            bool nbExistant = false;
            int nbSaisi= Convert.ToInt32(Console.ReadLine());
            while (nbExistant == false && cpt < tab.Length)
            {
                if(nbSaisi == tab[cpt])
                {
                    nbExistant = true;
                }
                else
                {
                    cpt++;
                }
            }
            
        }
        static void moyenne (ref int[]tab)
        {
            int moyenne = 0;
            for(int i=0;i< tab.Length; i++)
            {
                moyenne = moyenne + tab[i];
            }
            moyenne = moyenne / tab.Length;
            Console.WriteLine("la moyenne est de " + moyenne);                                        
        }

        static void QuitterMenu()
        {
            Console.WriteLine("Merci d'avoir utilisé le programme ");
        }

        static void Main(string[] args)
        {
            Random generateurNb = new Random();
            int[] tab = new int[300];

            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = (int)generateurNb.Next(1, 10001);
            }
            int menu = 0;
            bool continuer = true;

            while(continuer==true)
            {
                menu = ChoisirOption();

                switch (menu)
                {
                    case 1: AfficherPlusGrand(ref tab); break;
                    case 2: AfficherPlusPetit(ref tab); break;
                    case 3: AfficherNbDansTableau (ref tab); break;
                    case 4: moyenne(ref tab);break;
                    case 5: QuitterMenu(); break;
                    default: Console.WriteLine("Cette option n'est pas valide"); break;
                }

            }





        }


    }
}
