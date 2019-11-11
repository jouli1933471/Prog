using System;

namespace spider_krypton
{
    class Program
    {
        static void AfficherLongeurChaine(ref string maPhrase)
        {
            Console.WriteLine(maPhrase.Length);
        }
        static void DetermineSiOctopus(ref string maPhrase)
        {
            if (maPhrase.Contains("octopus") == true)
            {
                Console.WriteLine("il a le mot octopus dans cette phrase");
            }
            else
            {
                Console.WriteLine("il n'a pas le mot octopus dans cette phrase");
            }
        }
        static void PremierE(ref string maPhrase)
        {
            int premierE = maPhrase.IndexOf('e');
            Console.WriteLine(premierE);
        }
        static void AfficherUneSousPhrase(ref string maPhrase)
        {
            int dernierEspace = maPhrase.LastIndexOf(' ');
            string dernierMot = maPhrase.Substring(dernierEspace + 1);
            int premierEspace = maPhrase.IndexOf(' ');
            string premier = maPhrase.Substring(0, premierEspace);

            Console.WriteLine(premier + dernierMot);
        }
        static void AfficherMajuscule(ref string maPhrase)
        {
            string maPhraseMajuscule = maPhrase.ToUpper();
            Console.WriteLine(maPhraseMajuscule);
        }
        static void AfficherMinuscule(ref string maPhrase)
        {
            string maPhraseMinuscule = maPhrase.ToLower();
            Console.WriteLine(maPhraseMinuscule);
        }
        static void AfficherMenu()
        {
            Console.WriteLine("1. Permet d’afficher la longueur de la chaîne de caractèr ");
            Console.WriteLine("2. Permet de déterminer si la phrase contient «octopus»");
            Console.WriteLine("3. Permet de connaître la position du premier ‘e’");
            Console.WriteLine("4. Permet d’afficher une sous phrase	 ");
            Console.WriteLine("5. Transforme la chaînen majuscule puis l’afficher");
            Console.WriteLine("6. Transforme la chaîne en minuscule puis l’afficher");
            Console.WriteLine("7. Termine le programme");


        }
        static void QuitterMenu()
        {
            Console.WriteLine("Merci d'avoir utilisé le programme");
        }
        static void Main(string[] args)
        {
            string maPhrase = ("je suis le plus beau");
            AfficherMenu();
            int choixMenu = Convert.ToInt32(Console.ReadLine());
            switch (choixMenu)
            {
                case 1: AfficherLongeurChaine(ref maPhrase); break;
                case 2: DetermineSiOctopus(ref maPhrase); break;
                case 3: PremierE(ref maPhrase); break;
                case 4: ; break;
                case 5:
                     AfficherMajuscule(ref maPhrase)
                 ; break;
                case 6: AfficherMinuscule(ref maPhrase); break;
                case 7: QuitterMenu; break;
                default: Console.WriteLine("Entrer un choix existant"); break;
            }

        }
    }
}
