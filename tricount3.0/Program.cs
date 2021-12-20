using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricount.DAL;

namespace Tricount
{
    class Program
    {
        private static userService US = new userService();
        private static soireeService SS = new soireeService();


        static int menu()
        {
            Console.WriteLine("Bienvenue sur l'Application de soirée !");
            Console.WriteLine("------------------------------------------\n");
            Console.WriteLine("1 Créer une soirée");
            Console.WriteLine("2 Participer à une soirée");
            Console.WriteLine("3 Affichage des dettes et dépenses");
            int choixmenu = int.Parse(Console.ReadLine());

            if (choixmenu == 1)
            {
                creersoiree();
            }
            if (choixmenu == 2)
            {
                participersoiree();
            }
            if (choixmenu == 3)
            {
                debutcalc();
            }
            else
            {
                menu();
            }

            return 0;
        }

        static soiree creersoiree()
        {
            Console.WriteLine("quel est le nom de votre soirée ?");
            var name = Console.ReadLine();
            var n = new soiree(name);
            SS.Insert(n);

            Console.WriteLine("\nsoirée créee !");

            return n;
        }

        static void AfficherPartie()
        {
            var parties = SS.GetAllSoiree();
            parties.ForEach(p =>
            {
                Console.WriteLine(p.ToString());
            });
            Console.WriteLine("\n");
        }

        static int participersoiree()
        {
            var listeSoiree = SS.GetAllSoiree();

            Console.WriteLine("Voici la liste des soirée :\n");

            AfficherPartie();

            Console.WriteLine("Vous souhaitez participer à quelle soirée ?");
            int choixsoiree = int.Parse(Console.ReadLine());

            var Soiree = SS.GetSoireeByID(choixsoiree);


            Console.WriteLine("Comment vous appelez-vous ?\n");
            var user = Console.ReadLine();

            Console.WriteLine("Combien voulez-vous mettre d'argent ?");
            int depense = int.Parse(Console.ReadLine());
            var dettes = 0;
            var u = new user(user, depense, choixsoiree, dettes);
            US.Insert(u);

            return 0;
        }
        static List<user> debutcalc()
        {
            var listeSoiree = SS.GetAllSoiree();

            Console.WriteLine("Voici la liste des soirée :\n");

            AfficherPartie();

            Console.WriteLine("Vous souhaitez voir quelle soirée ?");
            int choixsoiree = int.Parse(Console.ReadLine());

            var soiree = SS.GetSoireeByID(choixsoiree);
            var listUser = US.GetUserBySoiree(choixsoiree);
            float PrixTotal = 0;

                foreach (user user in listUser)
                {
                    PrixTotal += user.depenses;
                }
                float moyenne = (float)Math.Round(PrixTotal / listUser.Count, 2);
                foreach (user user in listUser)
                {
                    user.dettes= moyenne - user.depenses;
                    US.Update(user);

                }
            return listUser;
        }

        static void calculRepayment(List<user> listUser)
        {
            for (int i = 0; i < listUser.Count; i++)
            {
                while (listUser[i].depenses< 0)
                {
                    for (int j = 0; j < listUser.Count; j++)
                    {
                        if (listUser[j].depenses > 0)
                        {
                            var tmp = listUser[i].depenses + listUser[j].depenses;
                            switch (tmp)
                            {
                                case > 0:

                                    Console.WriteLine($"{listUser[j].nom} doit {Math.Round(Math.Abs(listUser[i].depenses), 2)}euros à {listUser[i].nom}");
                                    listUser[i].depenses= 0;
                                    listUser[j].depenses = tmp;
                                    break;
                                case < 0:
                                    Console.WriteLine($"{listUser[j].nom} doit {Math.Round(Math.Abs(listUser[i].depenses), 2)}euros à {listUser[i].nom}");
                                    listUser[i].depenses = tmp;
                                    listUser[j].depenses = 0;
                                    break;
                                case 0:
                                    Console.WriteLine($"{listUser[j].nom} doit {Math.Round(Math.Abs(listUser[i].depenses), 2)}euros à {listUser[i].nom}");
                                    listUser[i].depenses = 0;
                                    listUser[j].depenses = 0;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }

        }


        /*   static void affichageDettes()
           {
               var listeSoiree = SS.GetAllSoiree();

               Console.WriteLine("Voici la liste des soirée :\n");

               AfficherPartie();

               Console.WriteLine("Vous souhaitez voir quelle soirée ?");
               int choixsoiree = int.Parse(Console.ReadLine());

               var soiree = SS.GetSoireeByID(choixsoiree);
               var nbrUser = US.GetUserBySoiree(choixsoiree);
               nbrUser.Sort();*/













        /*
                    float prix1;
                    float prix2;
                    float prixtmp;
                    float moyenne = 0; //faire la moyenne

                    foreach (var item in nbrUser)
                    {
                        moyenne += item.depenses;
                    }

                    moyenne /= nbrUser.Count;

                    //depense - moyenne
                    int cpt = 0;
                    for (int i = 0; i < nbrUser.Count; i++)
                    {
                        prix1 = nbrUser[1].depenses - moyenne;
                        while (nbrUser[cpt].depenses - moyenne < 0)
                        {
                            cpt++;
                        }

                    }
                }
        */

        /*
            int prix1;
            int prix2;
            int prixtmp;

            int moyenne = 0; //faire la moyenne

            for (int i = 0; i < nbuser; i++)
            {
                if (user.depenses < moyenne)
                {
                    //définir le prix 1 sur les depenses du user devant rembourser
                    prix1 = moyenne - user.depenses;

                    for (int i = 0; i < nbuser; i++)
                    {
                        //définir le prix 2 sur les depenses du user devant être rembourser
                        prix2 = moyenne - user.depenses;
                    }

                    prixtmp = prix1 - prix2;
                    Console.WriteLine("L'utilisateur ... doit" prix1 "à l'urtilisateur ...");

                    if (prixtmp > 0)
                    {
                        prix1 = prix1 - prixtmp;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }*/


        static void Main(string[] args)
        {
            menu();
        }
    }
}