using System;

namespace ExamenFinal
{
    class Program
    {
        public static Metaux[] tabMetaux = new Metaux[4];
        public struct Metaux
        {
            public string nom;
            public int resistance;
            public int pointFusion;
            public int poids;
            public int conductivite;


            public Metaux(string _nom,int _resistance,int _pointFusion,int _poids,int _conductivite) : this()
            {
                nom = _nom;
                resistance = _resistance;
                pointFusion = _pointFusion;
                poids = _poids;
                conductivite = _conductivite;
            }
        }
        static void AfficherMenu()
        {
            Console.WriteLine("1.	Connaître le métal avec la pirerésistance ");
            Console.WriteLine("2.	Connaître  le  métal  avec  le  meilleur  score ");
            Console.WriteLine("3.	Savoir si un métal avec un point de fusion supérieur de plus de 8 existe ");
            Console.WriteLine("4.	Créer un nouvel alliage");          
            Console.WriteLine("5.   Quitter le programme ");
        }
        static void PireResistance()
        {
                double pireRes = 11;
                string nom = "";
                for (int i = 0; i < tabMetaux.Length; i++)
                {
                    if (pireRes > tabMetaux[i].resistance)
                    {
                        pireRes = tabMetaux[i].resistance;
                        nom = tabMetaux[i].nom;
                    }
                }
                Console.WriteLine("le métaux avec le moins de resistance est le " + nom + " avec une résistance de" + pireRes);          
        }
        static void meilleurScore()
        {
            int meilleurScore = 0;
            string nom = "" ;
            for (int i = 0; i < tabMetaux.Length; i++)
            {
                int score = 0;
                
                score = (tabMetaux[i].resistance + tabMetaux[i].pointFusion + tabMetaux[i].poids + tabMetaux[i].conductivite) / 4;
                if(score == 5)
                {
                    meilleurScore = score;
                    nom = tabMetaux[i].nom;
                }
                else if(score == 4 || score == 6 && meilleurScore!=5)
                {
                    meilleurScore = score;
                    nom = tabMetaux[i].nom;
                }
                else if(score == 3 || score == 7 && meilleurScore != 5 && meilleurScore != 4 && meilleurScore != 6)
                {
                    meilleurScore = score;
                    nom = tabMetaux[i].nom;
                }
                else if(score == 3 || score == 7 && meilleurScore != 5 && meilleurScore != 4 && meilleurScore != 6 && meilleurScore != 3 && meilleurScore != 7)
                {
                    meilleurScore = score;
                    nom = tabMetaux[i].nom;
                }
                else
                {


                }

            }
            Console.WriteLine("le métal avec le meilleur score est le "+ nom +" avec un score de "+meilleurScore);
        }
        static void metauxPlusDe8()
        {
            bool existe8 = false;
            int cpt = 0;
            string nom = "";

            while (existe8 == false && cpt < tabMetaux.Length)
            {
                if (tabMetaux[cpt].pointFusion > 8)
                {
                    existe8 = true;
                    nom = tabMetaux[cpt].nom;


                }
                else
                {
                    cpt++;
                }


            }

            if (existe8 == true)
            {
                Console.WriteLine("il existe un métal avec un point de fusion plus élevé que 8 et c'est le "+nom);

            }
            else
            {
                Console.WriteLine("il n'existe pas de métaux avec un point de fusion plus élevé que 8");
            }
        }
        static void AfficherMenuAlliage()
        {
            Console.WriteLine("0.	Fer");
            Console.WriteLine("1.	Cuivre");
            Console.WriteLine("2.	Plomb");
            Console.WriteLine("3.	Zinc");

        }
        static void caracAlliage( ref int choix1,ref int choix2,ref double pourcentage1,ref double pourcentage2)
        {
            double resistanceAlliage;
            double pointFusionAlliage;
            double poidsAlliage;
            double conductiviteAlliage;
            double pointage = 0;

            resistanceAlliage = (tabMetaux[choix1].resistance * pourcentage1) + (tabMetaux[choix2].resistance * pourcentage2);
            pointFusionAlliage = (tabMetaux[choix1].pointFusion * pourcentage1) + (tabMetaux[choix2].pointFusion * pourcentage2);
            poidsAlliage = (tabMetaux[choix1].poids * pourcentage1) + (tabMetaux[choix2].poids * pourcentage2);
            conductiviteAlliage = (tabMetaux[choix1].conductivite * pourcentage1) + (tabMetaux[choix2].conductivite * pourcentage2);

            pointage = Math.Abs(resistanceAlliage - 5) + Math.Abs(pointFusionAlliage - 5) + Math.Abs(poidsAlliage - 5) + Math.Abs(conductiviteAlliage - 5);

            if(pointage > 7)
            {
                Console.WriteLine("Vous avez créé un alliage de type : Faible");
            }
            else if(pointage <= 7 && pointage > 3.5)
            {
                Console.WriteLine("Vous avez créé un alliage de type : Moyen");
            }
            else if(pointage <= 3.5 && pointage >1)
            {
                Console.WriteLine("Vous avez créé un alliage de type : Bon");
            }
            else if(pointage <= 1)
            {
                Console.WriteLine("Vous avez créé un alliage de type : Parfait\n\n");
            }
        }
        static void creerAlliage()
        {
            string nomAlliage = "";

            Console.WriteLine("Choisir le premier métal");
            AfficherMenuAlliage();
            int choix1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Choisir le deuxième métal DIFFÉRENT du premier");
            AfficherMenuAlliage();
            int choix2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("veuillez entrer le pourcentage du premier métal");
            double pourcentage1 = Convert.ToInt32(Console.ReadLine());
                    
            Console.WriteLine("veuillez entrer le pourcentage du deuxième métal pour que le total soit égal à cent");
            double pourcentage2 = Convert.ToInt32(Console.ReadLine());

            if(pourcentage1>pourcentage2)
            {
                nomAlliage = tabMetaux[choix1].nom + tabMetaux[choix2].nom[0];
            }
            else
            {
                nomAlliage = tabMetaux[choix2].nom + tabMetaux[choix1].nom[0];
            }
            Console.WriteLine("le nom de votre alliage est :" + nomAlliage);
            pourcentage2 = pourcentage2 / 100;
            pourcentage1 = pourcentage1 / 100;
            caracAlliage(ref choix1,ref choix2,ref pourcentage1,ref pourcentage2);

        }

        static void Main(string[] args)
        {
            bool finProgramme = false;

            tabMetaux[0] = new Metaux("Fer", 7 , 9 , 4 , 3);
            tabMetaux[1] = new Metaux("Cuivre", 4 , 8 , 8 , 2);
            tabMetaux[2] = new Metaux("Plomb", 1 , 3 , 7 , 2);
            tabMetaux[3] = new Metaux("Zinc", 2 , 5 , 3 , 6);
            

            while (finProgramme == false)
            {
                AfficherMenu();
                int choixMenu = Convert.ToInt32(Console.ReadLine());
                switch (choixMenu)
                {
                    case 1: PireResistance(); break;
                    case 2: meilleurScore(); break;
                    case 3: metauxPlusDe8(); break;
                    case 4: creerAlliage(); break;
                    case 5: finProgramme = true; break;
                    default: Console.WriteLine("Entrer un choix existant"); break;
                }

            }
        }
    }
}
