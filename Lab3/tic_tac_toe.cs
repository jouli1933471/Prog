using System;

namespace tic_tac_toe
{

    class Program
    {
        static Random generateur = new Random();
        static char[] tab = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int joueur = 1;
        static int verificateur;

        static void AfficherTableau()

        {

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", tab[1], tab[2], tab[3]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", tab[4], tab[5], tab[6]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", tab[7], tab[8], tab[9]);

            Console.WriteLine("     |     |      ");

        }


        static int VerifierVictoire()
        {
            if (tab[1] == tab[2] && tab[2] == tab[3])
            {
                return 1;
            }
            else if (tab[4] == tab[5] && tab[5] == tab[6])
            {
                return 1;
            }
            else if (tab[6] == tab[7] && tab[7] == tab[8])
            {
                return 1;
            }
            else if(tab[1]==tab[4]&&tab[4]==tab[7])
            {
                return 1;
            }
            else if(tab[2] == tab[5] && tab[5] == tab[8])
            {
                return 1;
            }
            else if(tab[3] == tab[6] && tab[6] == tab[9])
            {
                return 1;
            }
            else if(tab[1]==tab[5] && tab[5]==tab[9])
            {
                return 1;
            }
            else if(tab[3] == tab[5] && tab[5] == tab[7])
            {
                return 1;
            }
            else if (tab[1] != '1' && tab[2] != '2' && tab[3] != '3' && tab[4] != '4' && tab[5] != '5' && tab[6] != '6' && tab[7] != '7' && tab[8] != '8' && tab[9] != '9')
            {
                return -1;
            }
            else
            {
                return 0;
            }

        }
        static void UnContreUn()
        {
            int choix;
            bool dejaUtiliser = false;
            bool finParti = false;
            AfficherTableau();
            while (finParti == false)
            {
                Console.WriteLine("Joueur1:X Joueurs2:O");
                Console.WriteLine("\n");
                if (joueur == 1)
                {
                    Console.Clear();
                    AfficherTableau();
                    Console.WriteLine("c'est au tour du premier joueur");

                    while (dejaUtiliser == false)
                    {
                        Console.WriteLine("quelle est votre choix");
                        choix = Convert.ToInt32(Console.ReadLine());
                        if (tab[choix] != 'X' && tab[choix] != 'O')
                        {
                            tab[choix] = 'X';
                            joueur = joueur + 1;
                            dejaUtiliser = true;

                        }
                        else
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("Cette case est déjà utilisé");
                        }
                    }
                    dejaUtiliser = false;
                    verificateur = VerifierVictoire();
                    if (verificateur == 1)
                    {
                        Console.WriteLine("vous avez gagné!!");
                        finParti = true;
                    }
                    else if (verificateur == -1)
                    {
                        Console.WriteLine("C'est une égalité");
                        finParti = true;
                    }

                    AfficherTableau();

                }
                else
                {
                    Console.WriteLine("c'est au tour du deuxième joueur");

                    while (dejaUtiliser == false)
                    {
                        Console.WriteLine("quelle est votre choix");
                        choix = Convert.ToInt32(Console.ReadLine());
                        if (tab[choix] != 'X' && tab[choix] != 'O')
                        {
                            tab[choix] = 'O';
                            joueur = joueur - 1;
                            dejaUtiliser = true;
                        }
                        else
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("Cette case est déjà utilisé");
                        }
                    }

                    dejaUtiliser = false;

                    AfficherTableau();

                    verificateur = VerifierVictoire();
                    if (verificateur == 1)
                    {
                        Console.WriteLine("vous avez gagné!!");
                        finParti = true;
                    }
                    else if (verificateur == -1)
                    {
                        Console.WriteLine("C'est une égalité");
                        finParti = true;
                    }

                }
            }
        }/*
        static void ContreLordi()
        { pas terminé***
            
            int choix;
            bool dejaUtiliser = false;
            bool finParti = false;
            AfficherTableau();
            int choixOrdi;
            while (finParti == false)
            {
                Console.WriteLine("Joueur1:X Ordi:O");
                Console.WriteLine("\n");
                if (joueur == 1)
                {
                    Console.WriteLine("c'est a votre tour");

                    while (dejaUtiliser == false)
                    {
                        Console.WriteLine("quelle est votre choix");
                        choix = Convert.ToInt32(Console.ReadLine());
                        if (tab[choix] != 'X' && tab[choix] != 'O')
                        {
                            tab[choix] = 'X';
                            joueur = joueur + 1;
                            dejaUtiliser = true;

                        }
                        else
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("Cette case est déjà utilisé");
                        }
                    }
                    dejaUtiliser = false;
                    verificateur = VerifierVictoire();
                    if (verificateur == 1)
                    {
                        Console.WriteLine("vous avez gagné!!");
                        finParti = true;
                    }
                    else if (verificateur == -1)
                    {
                        Console.WriteLine("C'est une égalité");
                        finParti = true;
                    }


                }
                else
                {
                    Console.WriteLine("c'est au tour du deuxième joueur");

                    while (dejaUtiliser == false)
                    {
                        choixOrdi = generateur.Next(1, 10);
                        if (tab[choixOrdi] != 'X' && tab[choixOrdi] != 'O')
                        {
                            tab[choixOrdi] = 'O';
                            joueur = joueur - 1;
                            dejaUtiliser = true;
                        }
                        else
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("Cette case est déjà utilisé");
                        }
                    }
                    dejaUtiliser = false;

                    AfficherTableau();

                    verificateur = VerifierVictoire();
                    if (verificateur == 1)
                    {
                        Console.WriteLine("vous avez gagné!!");
                        finParti = true;
                    }
                    else if (verificateur == -1)
                    {
                        Console.WriteLine("C'est une égalité");
                        finParti = true;
                    }
                }
            }
        }*/
        static void Main(string[] args)
        {
            int choixJeux;
            Console.WriteLine("Quel mode de jeu voulez-jouez?\n 1- Un contre un 2- Vous contre l'ordi");
            choixJeux = Convert.ToInt32(Console.ReadLine());
            if(choixJeux == 1)
            {
                UnContreUn();
            }
            else if(choixJeux == 2)
            {
                /*ContreLordi();*/
            }
            else
            {
                Console.WriteLine("Choissisez un choix valide");
            }
        }

    }
}   

