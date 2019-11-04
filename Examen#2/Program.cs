using System;

namespace Examen2
{
    public enum rareter { Commun = 1, Rare = 2, Épique = 3, Légendaire = 4 };    
    class Program
    {
        static Random generateur = new Random();
        
        public struct Vaisseaux
        {
            public string nom;
            public Caracteristique[] tabVaisseaux;

            public Vaisseaux(string _nom): this()
            {
                tabVaisseaux = new Caracteristique[10];
                nom = _nom;
                for (int i = 0; i < tabVaisseaux.Length; i++)
                {
                    tabVaisseaux[i] = new Caracteristique((rareter)generateur.Next(1, 5), generateur.Next(10,70), generateur.Next(100, 2001), generateur.Next(2000,20001));
                }
            }

        }
        public struct Caracteristique
        {

            public rareter rare;
            public int vit;
            public int vie;
            public int prix;
                
            public Caracteristique(rareter _rare, int _vit, int _vie, int _prix) : this()
            {
            
                rare = _rare;
                vit = _vit;
                vie = _vie;
                prix = _prix;                
            }
            
        }
        static void AfficherMenu()
        {
            Console.WriteLine("1.	Afficher tous les vaisseaux ");
            Console.WriteLine("2.	Vérifier si un vaisseau légandaire existe ");
            Console.WriteLine("3.	trouver le vaisseau avec le plus de vie ");
            Console.WriteLine("4.	Afficher la moyenne des prix des vaisseaux ");
            Console.WriteLine("5.	Quitter le programme ");
        }
        static void AfficherVaisseaux(ref Caracteristique[] tabVaisseaux)
        {
            for (int i = 0; i < tabVaisseaux.Length; i++)
            {
                Console.WriteLine(" Vaisseaux " + tabVaisseaux[i].rare + " Vitesse : " + tabVaisseaux[i].vit +
                   " Vie: " + tabVaisseaux[i].vie + "prix" + tabVaisseaux[i].prix);
            }
        }
        static void AfficherSiLegandaireExiste(ref Caracteristique[] tabVaisseaux)
        {
            bool existeLégandaire = false;            
            int cpt = 0;
            
            while (existeLégandaire == false && cpt < tabVaisseaux.Length)
            {
                if (tabVaisseaux[cpt].rare == rareter.Légendaire)
                {
                    existeLégandaire = true;


                }
                else
                {
                    cpt++;
                }
                if (existeLégandaire == true)
                {
                    Console.WriteLine("il existe un vaisseau légandaire");

                }
                else
                {
                    Console.WriteLine("il n'existe pas de vaisseau");
                }

            }
        }
        static void AfficherVaisseauPlusVie(ref Caracteristique[] tabVaisseaux)
        {
            int plusVie = 0;
            int position = 0;

            for (int i = 0; i < tabVaisseaux.Length; i++)
            {
                if (tabVaisseaux[i].vie > plusVie)
                {
                    plusVie = tabVaisseaux[i].vie;
                    position = i;
                }
            }
            Console.WriteLine("le soldat avec le plus de vie est le numéro " + position + " avec " + plusVie + " de vie ");
        }
        static void AfficherMoyennePrix(ref Caracteristique[] tabVaisseaux)
        {

            int moy = 0, tot = 0;
            for (int i = 0; i < tabVaisseaux.Length; i++)
            {
                tot += tabVaisseaux[i].prix;
            }

            moy = tot / tabVaisseaux.Length;
            Console.WriteLine("La moyenne du prix de vos vaisseaux est de " + moy);
        }
        static void Main(string[] args)
        {
            Vaisseaux mesVaisseaux = new Vaisseaux();
            bool finProgramme = false;

            while (finProgramme == false)
            {
                AfficherMenu();
                int choixMenu = Convert.ToInt32(Console.ReadLine());
                switch (choixMenu)
                {
                    case 1: AfficherVaisseaux(ref mesVaisseaux.tabVaisseaux); break;
                    case 2: AfficherSiLegandaireExiste(ref mesVaisseaux.tabVaisseaux); break;
                    case 3: AfficherVaisseauPlusVie(ref mesVaisseaux.tabVaisseaux); break;
                    case 4: AfficherMoyennePrix(ref mesVaisseaux.tabVaisseaux); break;
                    case 5: finProgramme = true; break;
                    default: Console.WriteLine("Entrer un choix existant"); break;
                }
            }
        }
    }
}
