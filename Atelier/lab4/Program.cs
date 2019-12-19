using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{

    enum Niveau
    {
        Facile = 0,
        Moyen = 1,
        Difficile = 2

    };
    class Program
    {
        internal static class DllImports
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct COORD
            {

                public short X;
                public short Y;
                public COORD(short x, short y)
                {
                    this.X = x;
                    this.Y = y;
                }

            }
            [DllImport("kernel32.dll")]
            public static extern IntPtr GetStdHandle(int handle);
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool SetConsoleDisplayMode(
                IntPtr ConsoleOutput
                , uint Flags
                , out COORD NewScreenBufferDimensions
                );
        }

        static public Niveau nivTableau;

        static public bool[] tabUnlocked = { false, false, false, false, false, false };
        public struct Joueur
        {
            public int posX;
            public int posY;
            public int oldPosX;
            public int oldPosY;
            public char symbol;
            public int speed;
            public int vie;
            public int money;

            public Joueur(int _posX, int _posY, char _symbol, int _vie, int _money) : this()
            {
                posX = _posX;
                posY = _posY;
                oldPosX = 0;
                oldPosY = 0;

                speed = 1;

                symbol = _symbol;
                vie = _vie;
                money = _money;
            }


        }
        static string AfficherTitre()
        {
            string titre = @"
                            _________          _______    _______  _______  _______  _______    _______  _______  _______  _______ 
                            \__   __/|\     /|(  ____ \  (       )(  ____ \(       )(  ____ \  (       )(  ___  )/ ___   )(  ____ \
                               ) (   | )   ( || (    \/  | () () || (    \/| () () || (    \/  | () () || (   ) |\/   )  || (    \/
                               | |   | (___) || (__      | || || || (__    | || || || (__      | || || || (___) |    /   )| (__    
                               | |   |  ___  ||  __)     | |(_)| ||  __)   | |(_)| ||  __)     | |(_)| ||  ___  |   /   / |  __)   
                               | |   | (   ) || (        | |   | || (      | |   | || (        | |   | || (   ) |  /   /  | (      
                               | |   | )   ( || (____/\  | )   ( || (____/\| )   ( || (____/\  | )   ( || )   ( | /   (_/\| (____/\
                               )_(   |/     \|(_______/  |/     \|(_______/|/     \|(_______/  |/     \||/     \|(_______/(_______/";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(titre);
            Console.ForegroundColor = ConsoleColor.White;
            return titre;
        }
        static void QuitterMenu()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(background.TY4Playing());
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
        static void AfficherChoix(ref Joueur player)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\n Game Difficulties: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n \n 1- Play in Easy Mode \n 2- Play in Medium Mode \n 3- Play in Hard Mode");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\n \n Shop: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n \n 4- Go to Shop");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\n \n Meme Gallery: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n \n 5- See your meme gallery");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\n \n Quit: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n \n 6- Quit the game =(");
            int choixMenu = Convert.ToInt32(Console.ReadLine());

            switch (choixMenu)
            {
                case 1: nivTableau = Niveau.Facile; break;
                case 2: nivTableau = Niveau.Moyen; break;
                case 3: nivTableau = Niveau.Difficile; break;
                case 4: AfficherShop(ref player);  break;
                case 5: AfficherGallerie(player);  break;
                case 6: QuitterMenu(); Environment.Exit(-1); break;

            }
                
        }
        static void AfficherMenu(ref Joueur player)
        {
            Console.Clear();
            AfficherTitre();
            AfficherChoix(ref player);         
        }
        static void Main(string[] args)
        {
            IntPtr hConsole = DllImports.GetStdHandle(-11); 
            DllImports.COORD xy = new DllImports.COORD(100, 100);
            DllImports.SetConsoleDisplayMode(hConsole, 1, out xy);

            Joueur player = new Joueur(0, 0, '*', 3, 0);
            bool finJeu = false;
            bool victoire = false;

            AfficherMenu(ref player); 

            Console.Clear();

            InitialiseGame(player);

            char[,] tabMaze = getMaze();
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            background.AfficherMaze(nivTableau, player);
            while (!finJeu)
            {
                Console.CursorVisible = false;

                player.oldPosX = player.posX;
                player.oldPosY = player.posY;

                ConsoleKey Input = Console.ReadKey(true).Key;
                if (Input == ConsoleKey.W || Input == ConsoleKey.UpArrow)
                {
                    if (tabMaze[player.posY - 1, player.posX] == ' ')
                        player.posY -= player.speed * 1;
                    else if (tabMaze[player.posY - 1, player.posX] == '$')
                    {
                        player.money = player.money + 1;
                        player.posY -= player.speed * 1;
                        UpdateMoney(player, ref tabMaze);
                    }
                    else if (tabMaze[player.posY - 1, player.posX] == 'V')
                    {
                        player.vie = player.vie + 1;
                        player.posY -= player.speed * 1;
                        UpdateLife(player, ref tabMaze);
                    }
                    else if (tabMaze[player.posY - 1, player.posX] == 'F')
                    {
                        player.posY -= player.speed * 1;
                        victoire = true;
                    }
                    else
                    {
                        player.vie = player.vie - 1;
                        UpdateLife(player, ref tabMaze);
                    }
                }
                else if (Input == ConsoleKey.S || Input == ConsoleKey.DownArrow)
                {
                    if (tabMaze[player.posY + 1, player.posX] == ' ')
                        player.posY += player.speed * 1;
                    else if (tabMaze[player.posY + 1, player.posX] == '$')
                    {
                        player.money = player.money + 1;
                        player.posY += player.speed * 1;
                        UpdateMoney(player, ref tabMaze);
                    }
                    else if (tabMaze[player.posY + 1, player.posX] == 'V')
                    {
                        player.vie = player.vie + 1;
                        player.posY += player.speed * 1;
                        UpdateLife(player, ref tabMaze);
                    }
                    else if (tabMaze[player.posY + 1, player.posX] == 'F')
                        victoire = true;
                    else
                    {
                        player.vie = player.vie - 1;
                        UpdateLife(player, ref tabMaze);
                    }
                }
                else if (Input == ConsoleKey.A || Input == ConsoleKey.LeftArrow)
                {
                    if (tabMaze[player.posY, player.posX-1] == ' ')
                        player.posX -= player.speed * 1;
                    else if (tabMaze[player.posY - 1, player.posX] == '$')
                    {
                        player.money = player.money + 1;
                        player.posY -= player.speed * 1;
                        UpdateMoney(player, ref tabMaze);
                    }
                    else if (tabMaze[player.posY - 1, player.posX] == 'V')
                    {
                        player.vie = player.vie + 1;
                        player.posY -= player.speed * 1;
                        UpdateLife(player, ref tabMaze);
                    }
                    else if (tabMaze[player.posY - 1, player.posX] == 'F')
                        victoire = true;
                    else
                    {
                        player.vie = player.vie - 1;
                        UpdateLife(player, ref tabMaze);
                    }
                }
                else if (Input == ConsoleKey.D || Input == ConsoleKey.RightArrow)
                {
                    if (tabMaze[player.posY, player.posX + 1] == ' ')
                        player.posX += player.speed * 1;
                    else if (tabMaze[player.posY + 1, player.posX] == '$')
                    {
                        player.money = player.money + 1;
                        player.posY += player.speed * 1;
                        UpdateMoney(player, ref tabMaze);
                    }
                    else if (tabMaze[player.posY + 1, player.posX] == 'V')
                    {
                        player.vie = player.vie + 1;
                        player.posY += player.speed * 1;
                        UpdateLife(player, ref tabMaze);
                    }
                    else if (tabMaze[player.posY, player.posX + 1] == 'F')
                        victoire = true;
                    else 
                    {
                        player.vie = player.vie - 1;
                        UpdateLife(player, ref tabMaze);
                    }
                }
                if (tabMaze[player.posY, player.posX] == '$')
                    tabMaze[player.posY, player.posX] = ' ';
                else if (tabMaze[player.posY, player.posX] == '¤')
                    tabMaze[player.posY, player.posX] = ' ';

                if ( victoire == true )
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Congrats! You escaped the meme level :)");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey(true);

                    AfficherMenu(ref player);
                    Console.Clear();
                    player.posX = 0;
                    player.posY = 0;
                    victoire = false;
                    InitialiseGame(player);
                }
                

                ClearPerso(player);
                DrawPerso(player);


                if (Input == ConsoleKey.Q)
                    finJeu = true;

                if (player.vie == 0)
                {
                    Console.Clear();
                    background.GameOver();
                    QuitterMenu();
                    Environment.Exit(-1);
                }
            }
        }
        static char[,] getMaze()
        {
            char[,] tabMaze = new char[0, 0];
            switch (nivTableau)
            {
                case Niveau.Facile:
                    tabMaze = background.NiveauFacile(); break;

                case Niveau.Moyen:
                    tabMaze = background.NiveauMoyen(); break;

                case Niveau.Difficile:
                    tabMaze = background.NiveauDifficile(); break;
            }
            return tabMaze;

        }
        static void InitialiseGame(Joueur player)
        {
            Console.SetCursorPosition(0, 0);
            background.AfficherMaze(nivTableau, player);
            DrawPerso(player);
        }
        static void ClearPerso(Joueur player)
        {
            Console.SetCursorPosition(player.oldPosX, player.oldPosY);
            Console.Write(" ");
        }
        static void UpdateMoney(Joueur player, ref char[,]tabMaze)
        {
            Console.SetCursorPosition(8,3+tabMaze.GetLength(0));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(player.money+" $   ");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void UpdateLife(Joueur player, ref char[,] tabMaze)
        {
            Console.SetCursorPosition(8, 2 + tabMaze.GetLength(0));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(player.vie + "   ");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void DrawPerso(Joueur player)
        {
            Console.SetCursorPosition(player.posX, player.posY);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(player.symbol);
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void AfficherShop(ref Joueur player)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Which meme do you want to buy ?");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n1-\n2-\n3-\n4-\n5-");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\n\nGo back to menu : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n6- Menu");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\n\nYour money : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nMoney : " + player.money + " $");
            int choixMeme = Convert.ToInt32(Console.ReadLine());
            Shop(choixMeme, player);
        }
        static void Shop(int choixMeme, Joueur player)
        {
            int[] tabPrix = { 0, 5, 10, 15, 20, 25 };

            if (choixMeme <= 5)
            {

                if (player.money >= tabPrix[choixMeme] && tabUnlocked[choixMeme] == false)
                {
                    player.money = player.money - tabPrix[choixMeme];
                    tabUnlocked[choixMeme] = true;

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Congrats! You unlocked a Meme.");
                    Console.WriteLine("\nYou can have access to your Meme collection in the Gallery Menu");
                    Console.ReadKey();
                    AfficherMenu(ref player);
                }
                else
                {
                    if (tabUnlocked[choixMeme] == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("This Meme has already been unlocked!");
                        Console.WriteLine("\nYou can have access to your Meme collection in the Gallery Menu");
                        Console.ReadKey();
                        AfficherShop(ref player);
                    }
                    else 
                        DisplayNotEnoughMoney(player);
                }
            }
            else if (choixMeme == 6)
                AfficherMenu(ref player);
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid choice!! \n\n (Please Press ''Enter'' Before Making a New Choice)");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                AfficherShop(ref player);
            }
        }
        static void DisplayNotEnoughMoney(Joueur player)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You don't have enough money for the choosen Meme!! \n\n (Please Press ''Enter'' Before Making a New Choice)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            AfficherShop(ref player);
        }
        static void AfficherGallerie(Joueur player)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(background.MemeGallery());
            Console.ForegroundColor = ConsoleColor.White;
            if (tabUnlocked[1] == true)
            {
                Console.WriteLine("\n\n________________________________________________________________________________________________________________________________________\n\n");
                Console.WriteLine(background.Meme1());
            }
            if (tabUnlocked[2] == true)
            {
                Console.WriteLine("\n\n________________________________________________________________________________________________________________________________________\n\n");
                Console.WriteLine(background.Meme2());
            }
            if (tabUnlocked[3] == true)
            {
                Console.WriteLine("\n\n________________________________________________________________________________________________________________________________________\n\n");
                Console.WriteLine(background.Meme3());
            }
            if (tabUnlocked[4] == true)
            {
                Console.WriteLine("\n\n________________________________________________________________________________________________________________________________________\n\n");
                Console.WriteLine(background.Meme4());
            }
            if (tabUnlocked[5] == true)
            {
                Console.WriteLine("\n\n________________________________________________________________________________________________________________________________________\n\n");
                Console.WriteLine(background.Meme5());
            }

            Console.ReadKey();
            AfficherMenu(ref player);
        }
    }
}
