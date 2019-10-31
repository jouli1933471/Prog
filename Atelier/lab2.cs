using System;

namespace ConsoleApp5
{
    public enum sorte {coeur = 1, pique=2, carreaux=3, Trèfle=4 };
    class Program 
    {
        public static Random generateur = new Random();                    
        public struct Cartes 
        {           
            public sorte type;
            public int grosseur;
            public string grosseurAfficher;
            
            
            public Cartes(sorte _type, int _grosseur):this()
            {               
                type = _type;
                grosseur = _grosseur;
                grosseurAfficher = ConvertirGrosseurCarte(grosseur);

            }
        }
         static string ConvertirGrosseurCarte(int grosseur)
        {
            string grosseurAfficher = "";            
            if (grosseur == 1)
                grosseurAfficher = "As";
            else if (grosseur == 11)
                grosseurAfficher = "Valet";
            else if (grosseur == 12)
                grosseurAfficher = "Reine";
            else if (grosseur == 13)
                grosseurAfficher = "Roi";
            return grosseurAfficher;
        }
        public struct Joueurs
        {
            public Cartes[] tabCartes;
            public int nbVie;

            public Joueurs(int _nbVie) : this()
            {
                    tabCartes = new Cartes[3];
                    tabCartes[0] = new Cartes((sorte)generateur.Next(1, 5), generateur.Next(1, 14));
                    tabCartes[1] = new Cartes((sorte)generateur.Next(1, 5), generateur.Next(1, 14));
                    tabCartes[2] = new Cartes((sorte)generateur.Next(1, 5), generateur.Next(1, 14));

                    nbVie = _nbVie;

            }

        }
            static void AfficherMenu()
            {
                Console.WriteLine("1- Cogner");
                Console.WriteLine("2- piger");
                Console.WriteLine("3- prendre la carte dans la défausse");               

            }
            static void AfficherCartes(Joueurs joueur)
            {
                Console.WriteLine(joueur.tabCartes[0].type + "-" + joueur.tabCartes[0].grosseurAfficher);
                Console.WriteLine(joueur.tabCartes[1].type + "-" + joueur.tabCartes[1].grosseurAfficher);
                Console.WriteLine(joueur.tabCartes[2].type + "-" + joueur.tabCartes[2].grosseurAfficher);

            }
            static void PrendreDefausse(ref Cartes carteDefausse,ref Cartes[] tabCartes)
            {
                int choix = 0;

                Console.WriteLine("laquelle de ces cartes voulez vous changer?");
                Console.WriteLine(tabCartes[0].type + "-" + tabCartes[0].grosseurAfficher);
                Console.WriteLine(tabCartes[1].type + "-" + tabCartes[1].grosseurAfficher);
                Console.WriteLine(tabCartes[2].type + "-" + tabCartes[2].grosseurAfficher);
                choix = Convert.ToInt32(Console.ReadLine());
                Cartes temp;
                temp = tabCartes[choix - 1];
                tabCartes[choix - 1]=carteDefausse;
                carteDefausse = temp;
            }
                           
            static void Main(string[] args)
            {        
                Joueurs joueur1 = new Joueurs(3);
                Joueurs joueur2 = new Joueurs(3);
                bool finManche = true;
                Cartes carteDefausse = new Cartes((sorte)generateur.Next(1, 5), generateur.Next(1, 14));
                Joueurs joueurActif = joueur1;
                int choixMenu = 0;
            

                while(finManche == true)
                {
                    AfficherCartes(joueurActif);
                    AfficherMenu();

                    choixMenu = Convert.ToInt32(Console.ReadLine());
                    switch(choixMenu)
                    {
                        case 1:/*Cogner;*/break;
                        case 2:/*PigerNouvelleCartes()*/;break;
                        case 3:PrendreDefausse(ref carteDefausse, ref joueurActif.tabCartes);break;                        

                    }
                }

            
            

            


               
            }


        

    }
}

