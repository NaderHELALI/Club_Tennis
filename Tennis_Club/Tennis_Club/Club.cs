using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Tennis_Club
{
    class Club  
    {
        string name;
        List<Competition> Compt; 
        List<Membre> EnsMembre;
        List<Personnel> EnsPersonnel;
        List<Tournoi> EnsTournoi= new List<Tournoi>();
        List<Entraineur> EnsEntraineurs= new List<Entraineur>();
        List<Stage> EnsStage = new List<Stage>();
        List<DateTime> EnsCours = new List<DateTime>();
        string ville;
        public Club(string nom, string ville ,List<Membre> ListeMembre,List<Personnel>ListPersonnel, List<Competition>ListCompt)
        {
            name = nom;
            EnsMembre = ListeMembre;
            this.ville = ville;
            EnsPersonnel = ListPersonnel;
            Compt = ListCompt;


        }
        public string Name { get { return name; } }
        public string Ville { get { return ville ; } }
        public List<Membre> ListeMembre { get { return EnsMembre; } }
        public List<Competition> ListeCompt{ get { return Compt; } }
        public List<Personnel> ListePersonnel { get { return EnsPersonnel; } }
        public List<Entraineur> Entraineurs { get { return EnsEntraineurs; } }
        public List<Tournoi> ListeTournoi { get { return EnsTournoi;  } }
        public List<Stage> Stages { get { return EnsStage; } }
        public List<DateTime> Cours { get { return EnsCours ; } }
        //Affiche les informations du club
        public string Afficher()
        {
            return "Le club porte le nom de " + Name + " se situant dans la ville de " + Ville;
        }
        //Affiche l'ensemble du Personnel
        public void AfficherPersonnel()
        {
            Console.WriteLine("\n");
            int c = 1;
            foreach (Personnel m in EnsPersonnel)
            {

                if (m != null)
                {
                    Console.WriteLine(c + " : " + m.Afficher());
                    c++;
                }

            }
            Console.WriteLine("\n");
        }
        //Affichage des Membres
        public void AfficherMembre(List<Membre> List)
        {
            Console.WriteLine("\n");
            int c = 1; 
            foreach (Membre m in List)
            {
                if (m != null)
                {
                    Console.WriteLine(c + " : " + m.Afficher());
                    c++;
                }
            }
            Console.WriteLine("\n");
        }
        //Ajoute un membre au club
        public void AjoutMembre(Membre A)
        {
            EnsMembre.Add(A);
        }

        //Référence tous les membres compétitifs 
        public List<Membre> MembreCompt()
        {
            List<Membre> EnsCompt = EnsMembre.FindAll(a => a.Titre == "competitif");
            return EnsCompt;
        }
        //Référence tous les membres qui n'ont pas payé la cotisation
        public List<Membre> MembresCotisation()
        {
            List<Membre> EnsCompt = EnsMembre.FindAll(a => a.Cotisation == false);
            return EnsCompt;
        }
        //Référence tous les membres qui ont payé la cotisation
        public List<Membre> MembresReg()
        {
            List<Membre> EnsCompt = EnsMembre.FindAll(a => a.Cotisation == true);
            return EnsCompt;
        }

        // Référence aux membres Mineurs
        public List<Membre> MembresMineurs()
        {
            List<Membre> EnsCompt = EnsMembre.FindAll(a => a.Genre == 'J');
            return EnsCompt;
        }

        //Tri la liste Sous different Critères
        public List<Membre> TriNom()
        {
            List<Membre> tri = EnsMembre;
            tri.Sort(delegate (Membre A, Membre B) { return A.Nom.CompareTo(B.Nom); });
            return tri;

        }
        public List<Membre> TriClassement()
        {
            List<Membre> Tri = MembreCompt();
            Tri.Sort();
            return Tri;
        }
        public List<Membre> TriSexe()
        {
            List<Membre> Tri = EnsMembre;
            Tri.Sort(delegate (Membre A, Membre B) { return A.Genre.CompareTo(B.Genre); });
            return Tri;
        }
        // A refaire .............................
        public List<Membre> TriCotisation()
        {
            List<Membre> Tri = EnsMembre;
            Tri.Sort(delegate (Membre A, Membre B) { return A.Cotisation.CompareTo(B.Cotisation); });
            return Tri;
        }



        /// <summary>
        /// Gestion des Compts
        /// </summary>
        /// <param name="competition"></param>
        public void AjoutCompt(Competition competition)
        {
            Compt.Add(competition);
        }
        public void MiseAjourCompt()
        {
            for(int i = 0; i < ListeCompt.Count; i++)
            {
                Competition Compt = ListeCompt[i];
                if (DateTime.Now > Compt.Date.AddDays(Compt.NbJour))
                {
                    ListeCompt.Remove(Compt);
                }
            }
        }
        public void AjouterEquipCompt(Equipe Equipe1, Competition competition)
        {
            //Redéfinir la condition 
            
                competition.Equipe.Add(Equipe1);
                Console.WriteLine("L'équipe a été ajouté.");
            
        }
        public void AfficheCompt()
        {
            foreach(Competition compt in Compt)
            {
                Console.WriteLine(compt.ToString());
            }
        }

        





    }
}
