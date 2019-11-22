using System;

namespace lab3_atelier2
{
    class Program
    {
        static Random generateur = new Random();
        static void Main(string[] args)
        {
            string vie6 = @" 
                              +---+
                              |   |
                              O   |
                                  |
                                  |
                                  |
                            =========";
            string vie5 = @"  
                              +---+
                              |   |
                              O   |
                              |   |
                                  |
                                  |
                            =========";
            string vie4 = @"  
                              +---+
                              |   |
                              O   |
                             /|   |
                                  |
                                  |
                            =========";
            string vie3 = @"  
                              +---+
                              |   |
                              O   |
                             /|\  |
                                  |
                                  |
                            =========";
            string vie2 = @"  
                              +---+
                              |   |
                              O   |
                             /|\  |
                             /    |
                                  |
                            =========";
            string vie1 = @"  
                              +---+
                              |   |
                              O   |
                             /|\  |
                             / \  |
                                  |
                            =========";

            string vie0 = @"     
                                  _____          __  __ ______    ______      ________ _____  _            
                                 / ____|   /\   |  \/  |  ____|  / __ \ \    / /  ____|  __ \| |           
                                | |  __   /  \  | \  / | |__    | |  | \ \  / /| |__  | |__) | |           
                                | | |_ | / /\ \ | |\/| |  __|   | |  | |\ \/ / |  __| |  _  /| |           
                                | |__| |/ ____ \| |  | | |____  | |__| | \  /  | |____| | \ \|_|           
                                 \_____/_/    \_\_|  |_|______|  \____/   \/   |______|_|  \_(_) ";




            string[] tabMots = {"lama","poney","chien","chat","oiseau","mouche","ours","lapin","vache","cochon"};
            string motATrouve = tabMots[generateur.Next(0,10)];
            char[] tabJeu = new char[motATrouve.Length];
            for(int i=0;i<tabJeu.Length;i++)
            {
                tabJeu[i] = '_';
            }
            int vie = 7;
            bool motTrouver = false;
            bool lettreTrouver = false;
            bool underscore = false;

            Console.WriteLine("Bienvenue sur le jeu du pendu"+"\n vous avez 7 vie pour pour trouver le mot");

            while (vie>0 && motTrouver==false)
            {
                for(int i=0;i<tabJeu.Length;i++)
                {
                    Console.Write(tabJeu[i] + " ");
                }
                Console.WriteLine("quelle lettre voulez-vous essayer?");
                char lettre = Convert.ToChar(Console.ReadLine());
                for(int i=0;i<tabJeu.Length;i++)
                {
                   if(motATrouve[i]==lettre)
                    {
                        tabJeu[i] = lettre;
                        lettreTrouver = true;
                    }
                  
                }
                if(lettreTrouver==false)
                {
                    vie--;
                    switch(vie)
                    {
                        case 0: Console.WriteLine(vie0); break;
                        case 1: Console.WriteLine(vie1); break;
                        case 2: Console.WriteLine(vie2); break;
                        case 3: Console.WriteLine(vie3); break;
                        case 4: Console.WriteLine(vie4); break;
                        case 5: Console.WriteLine(vie5); break;
                        case 6: Console.WriteLine(vie6); break;
                    }
                }
                else
                {
                    if (underscore == false)
                    {
                        for (int i = 0; i < tabJeu.Length; i++)
                        {
                            if (tabJeu[i] == '_')
                            {
                                underscore = true;
                            }
                            if (underscore == false)
                            {
                                motTrouver = true;
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Bravo vous avez gagner!!");
        }
    }
}
