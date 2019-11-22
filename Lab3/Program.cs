using System;

namespace lab3_atelier1
{
    class Program
    {
        static int[] CreerTableau(ref string laPhrase)
        {
            string laPhraseM = laPhrase.ToLower();
            int[] tabLettre = new int[26];

            for (int i = 0; i < laPhraseM.Length; i++)
            {
                int indice = (int)laPhraseM[i] - 97;
                if (indice >= 0 && indice < 26)
                    tabLettre[indice]++;
            }
            return tabLettre;
        }
        static void AfficherNbMots(ref string laPhrase)
        {
            string[] tabMots = laPhrase.Split(' ');

            Console.WriteLine(tabMots.Length);
        }
        static void AfficherLettreNbDeFois(ref string laPhrase)
        {
            int[] tabAlphabet = CreerTableau(ref laPhrase);

            Console.WriteLine("Voice vos résultats.");
            for(int i=0;i< tabAlphabet.Length;i++)
            {
                char lettre = Convert.ToChar(i + 97);
                Console.WriteLine("la lettre "+lettre+" est "+ tabAlphabet[i] + " fois dans votre phrase");
            }
        }
        static void AfficherLettrePlus(ref string laPhrase)
        {
            int[] tabAlphabet = CreerTableau(ref laPhrase);

            int lettrePlusUtiliser = 0;
            int position = 0;
             
            for(int i =0;i<tabAlphabet.Length;i++)
            {
                if (tabAlphabet[i] < lettrePlusUtiliser)
                {
                    lettrePlusUtiliser = tabAlphabet[i];
                    position = i;
                }
            }
            char lettre = Convert.ToChar(position + 97);
            Console.WriteLine("la lettre qui apparait le plus de fois est "+lettre);
        }
        static void Encoder(ref string laPhrase)
        {
            string tabLettre = "";
            for (int i = 0; i < laPhrase.Length; i++)
            {
                int noLettre = (int)laPhrase[i];
                tabLettre += char.ConvertFromUtf32((noLettre + 2));
            }
            Console.WriteLine("voici votre phrase "+tabLettre);
        }
        static void AfficherMenu()
        {
            Console.WriteLine("1. Affiche le nombre de mots dans votre phrase ");
            Console.WriteLine("2. Affiche combien de fois chaque apparrait dans votre phrase");
            Console.WriteLine("3. Affiche la lettre qui est le plus de fois dans votre phrase");
            Console.WriteLine("4. Permet d'encoder votre phrase ");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Inscriver un phrase");
            string laPhrase = Console.ReadLine();

            AfficherMenu();
            int choixMenu = Convert.ToInt32(Console.ReadLine());
            switch (choixMenu)
            {
                case 1: AfficherNbMots(ref laPhrase); break;
                case 2: AfficherLettreNbDeFois(ref laPhrase); break;
                case 3: AfficherLettrePlus(ref laPhrase); break;
                case 4: Encoder(ref laPhrase); break;
                default: Console.WriteLine("Entrer un choix existant"); break;
            }

            Console.ReadKey();
        }
    }
}
