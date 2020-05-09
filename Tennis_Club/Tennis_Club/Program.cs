using System;
using System.Collections.Generic;
using System.IO;

namespace Tennis_Club
{
    class Program

    {   /// <summary>
    /// Cette Partie représente la Gestion des Membres
    /// </summary>
    /// <returns></returns>
        //Gestion des membres
        static public Membre CreationMembre()
        {

            Console.WriteLine("Entrez votre Nom : ");
            string nom = Console.ReadLine();
            Console.WriteLine("Entrez votre Prenom : ");
            string prenom = Console.ReadLine();
            Console.WriteLine("Entrez votre Année de Naissance ");
            int annee = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Entrez votre Mois de Naissance ");
            int mois = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Entrez votre Jour de Naissance ");
            int jour = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Entrez votre Ville ");
            string adresse = Console.ReadLine();
            Console.WriteLine("Entrez votre genre : M pour Homme, F pour Femme, J pour mineur");
            char genre = Char.Parse(Console.ReadLine());
            Console.WriteLine("Entrez votre titre competitif ou loisir");
            string titre = Console.ReadLine();

            return new Membre(nom, prenom, new DateTime(annee, mois, jour), adresse, genre, titre);

        }
        //Modification de l'Adresse
        static public void ModifAdresse(Club club)
        {
            club.Afficher();
            Console.WriteLine("Entrez le nom du membre à supprimer :");
            string nom = Console.ReadLine();
            Console.WriteLine("Entrez le prénom du membre à supprimer :");
            string prenom = Console.ReadLine();
            Console.WriteLine("Entrez la nouvelle adresse :");
            string adresse = Console.ReadLine();
            bool modif = false;
            for (int i = 0; i < club.ListeMembre.Count; i++)
            {
                if ((club.ListeMembre[i].Nom == nom) && (club.ListeMembre[i].Prenom == prenom))
                {
                    club.ListeMembre[i].Adresse = adresse;
                    modif = true;
                }

            }
            if (modif == false)
            {
                Console.WriteLine("La modification ne s'est pas effectuée");

            }
            else
            {
                Console.WriteLine("La modification s'est effectué");
            }
        }

        static public Membre SelectionMembre(Club club)
        {
            Membre membre = null;
            Console.WriteLine("Entrez le nom du membre à supprimer :");
            string nom = Console.ReadLine();
            Console.WriteLine("Entrez le prénom du membre à supprimer :");
            string prenom = Console.ReadLine();
            for (int i = 0; i < club.ListeMembre.Count; i++)
            {
                if ((club.ListeMembre[i].Nom == nom) && (club.ListeMembre[i].Prenom == prenom))
                {
                    membre = club.ListeMembre[i];
                }
            }
            return membre; 
        }
        static public void SupprimerMembre(Club club)
        {
            club.Afficher();
            Console.WriteLine("Entrez le nom du membre à supprimer :");
            string nom = Console.ReadLine();
            Console.WriteLine("Entrez le prénom du membre à supprimer :");
            string prenom = Console.ReadLine();
            bool supprime = false;

           
            for (int i = 0; i < club.ListeMembre.Count; i++)
            {
                if ((club.ListeMembre[i].Nom == nom) && (club.ListeMembre[i].Prenom == prenom))
                {
                    club.ListeMembre[i] = null;
                    supprime = true;
                }

            }
            if (supprime == false)
            {
                Console.WriteLine("La suppression ne s'est pas effectuée");

            }
            else
            {
                Console.WriteLine("La suppression s'est effectué");
            }
            club.Afficher();
        }

        // Affichage des Membres sous différent critères
        static void AffichageTri(Club club)
        {
            Console.WriteLine("\n0 : Pour retourner au menu Gestion des membres");
            Console.WriteLine("1 : Affichage Trié par nom");
            Console.WriteLine("2 : Affichage Trié par Classement");
            Console.WriteLine("3: Affichage Trié par Sexe");
            Console.WriteLine("4 : Affichage Trié par Régulation");
            
            Console.Write("Votre saisie : ");
            int caseSwitch2 = Int32.Parse(Console.ReadLine());
            switch (caseSwitch2)
            {
                case 0:
                    GestionMembre(club);
                    break;
                case 1:
                    List<Membre> Trinom = club.TriNom();
                    club.AfficherMembre(Trinom);
                    goto default;

                case 2:
                    List<Membre> Triclassement = club.TriClassement();
                    club.AfficherMembre(Triclassement);
                    goto default;
                case 3:
                    List<Membre> TriSexe = club.TriSexe();
                    club.AfficherMembre(TriSexe);
                    goto default;
                case 4:
                    List<Membre> TriCotisation = club.TriSexe();
                    club.AfficherMembre(TriCotisation);
                    goto default;
                default:
                    GestionMembre(club);
                    break;
            }
        }

        // Gestion des paiements des cotisations pour les membres qui n'ont pas payé
        static public void NPCotisation(Club club)
        {
            //Récupère et Affiche les membres qui n'ont pas payé la cotisation
            List<Membre> npCotisation = club.MembresCotisation();
            club.AfficherMembre(npCotisation);

            // Choisi Un membre pour une Régulation
            Console.WriteLine("Entrez le nom du membre à régulariser :");
            string nom = Console.ReadLine();
            Console.WriteLine("Entrez le prénom du membre à régulariser :");
            string prenom = Console.ReadLine();
            for (int i = 0; i < club.ListeMembre.Count; i++)
            {
                if ((club.ListeMembre[i].Nom == nom) && (club.ListeMembre[i].Prenom == prenom))
                {
                    Console.WriteLine("La somme totale à payer est de : " + club.ListeMembre[i].RegCotisation(club)+" euros");
                    Console.WriteLine("\n0 : Pour retourner au menu principal");
                    Console.WriteLine("1 s'il vient de payer, 0 sinon ");
                    int caseSwitch = Int32.Parse(Console.ReadLine());
                    switch (caseSwitch)
                    {
                        case 0:
                            Cotisation(club);
                            break;
                        case 1:
                            club.ListeMembre[i].Cotisation = true;
                            break;
                        default:
                            Cotisation(club);
                            break;
                    }
                }
            }
        }

        //Menu de Gestion des Cotisations
        static public void Cotisation(Club club)
        {
            Console.WriteLine("\n0 : Pour retourner au menu principal");
            Console.WriteLine("1 : Afficher les membres qui ont payé la cotisation ");
            Console.WriteLine("2 : Gestion des membres qui n'ont pas payé la cotisation");
            Console.Write("Votre saisie : ");
            int caseSwitch2 = Int32.Parse(Console.ReadLine());
            switch (caseSwitch2)
            {
                case 0:
                    MenuPricipale(club);
                    break;
                case 1:
                    List<Membre> MembresReg = club.MembresReg();
                    club.AfficherMembre(MembresReg);
                    Cotisation(club);
                    break;
                case 2:
                    NPCotisation(club);
                    break;
                default:
                    Cotisation(club);
                    break;
            }
            }

        //Menu de Gestion des Membres 
        static public void GestionMembre(Club club)
        {
            Console.WriteLine("\n0 : Pour retourner au menu principal");
            Console.WriteLine("1 : Ajouter un Membre ");
            Console.WriteLine("2 : Supprimer un Membre");
            Console.WriteLine("3 : Afficher l'ensemble des membres");
            Console.WriteLine("4 : Afficher les membres selon des critères");
            Console.WriteLine("5: Gestion des cotisations");
            Console.WriteLine("6: Modification de l'adrese");


            Console.Write("Votre saisie : ");
            int caseSwitch2 = Int32.Parse(Console.ReadLine());
            switch (caseSwitch2)
            {
                case 0:
                    MenuPricipale(club);
                    break;
                case 1:
                    Membre nouveau = CreationMembre();
                    club.AjoutMembre(nouveau);

                    goto default;

                case 2:
                    SupprimerMembre(club);
                    goto default;
                case 3:
                    club.AfficherMembre(club.ListeMembre);
                    goto default;
                case 4:
                    AffichageTri(club);
                    goto default;
                case 5:
                    Cotisation(club);
                    goto default;
                case 6:
                    ModifAdresse(club);
                    goto default;

                default:

                    GestionMembre(club);
                    break;
            }
        }


        /// <summary>
        /// Cette Partie représente la Gestion du Personnels
        /// </summary>
        /// <returns></returns>
        //Gestion Personnel
        static public Personnel CreationPersonnel()
        {

            Console.WriteLine("Entrez votre Nom : ");
            string nom = Console.ReadLine();
            Console.WriteLine("Entrez votre Prenom : ");
            string prenom = Console.ReadLine();
            Console.WriteLine("Entrez votre Année de Naissance ");
            int annee = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Entrez votre Mois de Naissance ");
            int mois = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Entrez votre Jour de Naissance ");
            int jour = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Entrez votre Ville ");
            string adresse = Console.ReadLine();
            Console.WriteLine("Entrez votre genre : M pour Homme, F pour Femme, J pour mineur");
            char genre = Char.Parse(Console.ReadLine());
            Console.WriteLine("Entrez le salaire :");
            int salaire = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Entrez le IBAN  :");
            string iban = Console.ReadLine();
            Console.WriteLine("Entrez l'Année d'entrée au club : ");
            int annee1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Entrez le mois d'entrée au club : ");
            int mois1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Entrez le jour d'entrée au club : ");
            int jour1 = Int32.Parse(Console.ReadLine());

            return new Personnel(nom, prenom, new DateTime(annee, mois, jour), adresse, genre, salaire,iban,new DateTime(annee1,mois1,jour1));

        }
        static public void AjoutPersonnel(Club club)
        {
            Personnel nouveau = CreationPersonnel();
            club.ListePersonnel.Add(nouveau);
        }
        static public void SupprimerPersonnel(Club club)
        {
            club.AfficherPersonnel();
            Console.WriteLine("Entrez le nom du salairié à supprimer :");
            string nom = Console.ReadLine();
            Console.WriteLine("Entrez le prénom du salarié à supprimer :");
            string prenom = Console.ReadLine();
            bool supprime = false;


            for (int i = 0; i < club.ListePersonnel.Count; i++)
            {
                if ((club.ListePersonnel[i].Nom == nom) && (club.ListePersonnel[i].Prenom == prenom))
                {
                    club.ListePersonnel[i] = null;
                    supprime = true;
                }

            }
            if (supprime == false)
            {
                Console.WriteLine("La suppression ne s'est pas effectuée");

            }
            else
            {
                Console.WriteLine("La suppression s'est effectué");
            }
            club.AfficherPersonnel();
        }
        static public void GestionPersonnel(Club club)
        {
            Console.WriteLine("\n0 : Pour retourner au menu principal");
            Console.WriteLine("1 : Ajouter un Salarié ");
            Console.WriteLine("2 : Supprimer un Salarié");
            Console.WriteLine("3 : Afficher l'ensemble des salariés");
            Console.Write("Votre saisie : ");
            int caseSwitch2 = Int32.Parse(Console.ReadLine());
            switch (caseSwitch2)
            {
                case 0:
                    MenuPricipale(club);
                    break;
                case 1:
                    AjoutPersonnel(club);
                    goto default;

                case 2:
                    SupprimerPersonnel(club);
                    goto default;
                case 3:
                    club.AfficherPersonnel();
                    goto default;
                default:
                    GestionPersonnel(club);
                    break;


            }
        }

        
        /// <summary>
        /// Gestion des Entraineurs 
        /// </summary>
        /// <returns></returns>
        static public Entraineur CreationEntraineur()
        {
            Console.WriteLine("Entrez votre Nom : ");
            string nom = Console.ReadLine();
            Console.WriteLine("Entrez votre Prenom : ");
            string prenom = Console.ReadLine();
            Console.WriteLine("Entrez votre Année de Naissance ");
            int annee = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Entrez votre Mois de Naissance ");
            int mois = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Entrez votre Jour de Naissance ");
            int jour = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Entrez votre Ville ");
            string adresse = Console.ReadLine();
            Console.WriteLine("Entrez votre genre : M pour Homme, F pour Femme, J pour mineur");
            char genre = Char.Parse(Console.ReadLine());
            Console.WriteLine("Entrez le statut de l'entraineur :(Salairie ou Membre) ");
            string statut = Console.ReadLine();
            Console.WriteLine("Entrez le nombre de cours où il participe : ");
            int cours = Int32.Parse(Console.ReadLine());
            return new Entraineur(statut, cours, nom, prenom, new DateTime(annee, mois, jour), adresse, genre);
        }
        static public void AfficherEntraineur(Club club)
        {
            int c = 1;
            foreach(Entraineur A in club.Entraineurs)
            {

                Console.WriteLine(c + " : " + A.ToString());
            }
        }

        static public void GestionEntraineur(Club club)
        {
            Console.WriteLine("\n0 : Pour retouner au Menu Principale");
            Console.WriteLine("1 : Creer un Entraineur");
            Console.WriteLine("2 : Afficher les Entraineurs");
            Console.Write("Votre saisie : ");
            int caseSwitch2 = Int32.Parse(Console.ReadLine());
            switch (caseSwitch2)
            {
                case 0:
                    MenuPricipale(club);
                    break;
                case 1:
                    
                    club.Entraineurs.Add(CreationEntraineur());

                    goto default;
                case 2:
                    AfficherEntraineur(club);
                    goto default;
                case 3:
                    AjouterParticipantTournoi(club);
                    break;

                default:
                    GestionTournoi(club);
                    break;
            }
        }

        // Gestion des Compts

         //Création d'une compétition 
         static public Competition CreationCompt()
        {
            Console.WriteLine("Entrez le Nom de la compétition : ");
            string nom = Console.ReadLine();
            Console.WriteLine("Entrez le Niveau de la compétition : ");
            string niveau = Console.ReadLine();
            Console.WriteLine("Entrez le nombre de jour de a compétition : ");
            int nbJour = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Entrez le nombre de joueur dans la compétition : ");
            int nbJoueur = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Entrez le nombre de Match dans la compétition : ");
            int nbMatch = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Entrez votre Année de la compétition ");
            int annee = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Entrez votre Mois de la compétition ");
            int mois = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Entrez votre Jour de la compétition ");
            int jour = Int32.Parse(Console.ReadLine());
            List<Equipe> EnsEquipe = new List<Equipe>();
            Competition compt = new Competition(nom, niveau, nbJour, nbJoueur, nbMatch, new DateTime(annee, mois, jour),EnsEquipe);
            return compt;
        }
        static public void GestionCompt(Club club)
        {
            Console.WriteLine("\n0 : Pour retourner au menu principal");
            Console.WriteLine("1 : Afficher l'ensemble des compétiteurs ");
            Console.WriteLine("2 : Création d'une compétition ");
            Console.WriteLine("3 : Afficher l'ensemble des compétitions");
            Console.WriteLine("4 : Mise à jour de compétition");
            Console.WriteLine("5 : Gestion des Equipes ");
            Console.WriteLine("6 : Analyse des résultats de matchs");
            Console.Write("Votre saisie : ");
            int caseSwitch2 = Int32.Parse(Console.ReadLine());
            switch (caseSwitch2)
            {
                case 0:
                    MenuPricipale(club);
                    break;
                case 1:
                    club.AfficherMembre(club.MembreCompt());
                    goto default;
                case 2:
                    Competition compt = CreationCompt();
                    club.AjoutCompt(compt);
                    goto default;
                case 3:
                    club.AfficheCompt();

                    goto default;
                case 4:
                    club.MiseAjourCompt();
                    goto default;
                case 5:
                    Competition compt1 =SelectionCompt(club);
                    GestionEquipe(club, compt1);
                    goto default;
                case 6:
                    Competition competition = SelectionCompt(club);
                    Equipe ep = SelectionEquipe(club, competition);

                    int res = AnalyseResultat(club,competition);

                    Console.WriteLine("Les resultats pour la compétition "+competition.Nom +"");
                    break;
                default:
                    GestionCompt(club);
                    break;

            }
        }
        static public Competition SelectionCompt(Club club)
        {
            club.AfficheCompt();
            Console.WriteLine("Entrez le nom de la Compétition:");
            string nom = Console.ReadLine();
            Competition competition = null;
            for (int i = 0; i< club.ListeCompt.Count; i++)
            {
                if (club.ListeCompt[i].Nom == nom)
                {
                    competition = club.ListeCompt[i];
                }
            }
            if (competition == null)
            {
                SelectionCompt(club);
            }
            return competition;

        }
        

        /// <summary>
        /// Gestion des Equipes
        /// </summary>
        /// <returns></returns>
        /// 
        static public Equipe CreationEquipe(Club club)
        {
            Console.WriteLine("Entrez la categorie de l'équipe");
            string cat = Console.ReadLine();
            List<Membre> listeMembre = new List<Membre>();
            return new Equipe(cat,listeMembre);
        }
        static void AjouterMembreInEquipe(Club club,Competition compt)
        {
            
            Membre membreAjout = null;
            club.AfficherMembre(club.MembreCompt());
            Console.WriteLine("Entrez le nom du Membre à ajouter  :");
            string nom = Console.ReadLine();
            Console.WriteLine("Entrez le prénom du Membre à ajouter :");
            string prenom = Console.ReadLine();
            
            for (int i = 0; i < club.ListeMembre.Count; i++)
            {

                if ((club.ListeMembre[i].Nom == nom) && (club.ListeMembre[i].Prenom == prenom))
                {
                    membreAjout = club.ListeMembre[i];
                    compt.AfficherEquipe();
                    Console.WriteLine("Choisir l'ID d'equipe à : ");
                    int id = Int32.Parse(Console.ReadLine());

                    if (Int32.Parse(compt.Niveau) >=(membreAjout.Classement))
                    {
                        if (membreAjout.Cotisation == true)
                        {
                            compt.Equipe[id-1].ListeMembre.Add(membreAjout);
                            Console.WriteLine("Le membre a été ajouté.");
                        }
                        Console.WriteLine("Le membre n'a pas réglé la cotisation donc il ne peut pas participé.");
                    }
                    else
                    {
                        Console.WriteLine("Le membre ne peut pas être ajouté à la compétition.");
                    }
                }
            }

            

        }
        static public Equipe SelectionEquipe(Club club,Competition Compt)
        {
            Compt.AfficherEquipe();
            Console.WriteLine("Entrez le numéro d'équipe :");
            int id = Int32.Parse(Console.ReadLine())-1;

            return Compt.Equipe[id];

        }
        static public void GestionEquipe(Club club, Competition competition)
        {
            Console.WriteLine("\n0 : Pour retourner au menu de gestion des compétitions");
            Console.WriteLine("1 : Création d'une équipe");
            Console.WriteLine("2 : Ajouter un membre à une équipe ");
            Console.WriteLine("3 : Afficher les équipes ");
            Console.WriteLine("3 : Afficher les membres d'une équipe ");
            Console.Write("Votre saisie : ");
            int caseSwitch2 = Int32.Parse(Console.ReadLine());
            switch (caseSwitch2)
            {
                case 0:
                    GestionCompt(club);
                    break;
                case 1:
                    Equipe equipe = CreationEquipe(club);
                    club.AjouterEquipCompt(equipe, competition);
                    goto default;
                case 2:
                    AjouterMembreInEquipe(club, competition);
                    goto default;
                case 3:
                    competition.AfficherEquipe();
                    goto default;
                case 4:
                    Equipe selEquipe = SelectionEquipe(club,competition);
                    competition.AfficherEquipeMembre(selEquipe);
                    goto default;
                default:
                    GestionEquipe(club,competition);
                    break;

            }
        }
        static public int AnalyseResultat(Club club, Competition competition)
        {

            int resultat = 0;
            for (int i = 1; i <= competition.NbMatch; i++)
            {
                Console.WriteLine("Entrer le résulat du match n°" + i + "(1 si le match est gagné, 0 si perdu et -1 si l'équipe a abandonné");
                string res = Console.ReadLine();
                if (res == "-1") { break; }
                else
                {
                    resultat += Int32.Parse(res);
                }


            }
            return resultat;

        }


        /// <summary>
        /// Gestion du Club 
        /// </summary>
        /// <returns></returns>
        //Creation club 
        static public Club CreerClub()
        {
            List<Membre> membre = new List<Membre>();
            List<Personnel> personnel = new List<Personnel>();
            List<Competition> compt = new List<Competition>();
            //Console.WriteLine("Entrez le nom du club : ");
            string nom = "Club de tennis 3arbi";
            //Console.WriteLine("Entrez la ville du club : ");
            string ville = "Beyrouth";
            Club club = new Club(nom, ville, membre, personnel,compt);
            return club; 
        }

        static public void CreationFichierMembre(string nom,List<Membre>List)
        {
            StreamWriter sw = new StreamWriter(nom+".txt",true);
            for(int i = 0; i < List.Count; i++)
            {
                
                sw.WriteLine(List[i].EnregistrementFichier());
            }
            sw.Close();
            ;
        }
        static public void LectureFichierMembre(string nom,Club club)
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(nom+".txt");
            while ((line = file.ReadLine()) != null)
            {
                

                string[] data = line.Split(';');
                string []datetime =data[2].Split(new char[2] { '/', ' ' });
                DateTime Date = new DateTime(Int32.Parse(datetime[2]), Int32.Parse(datetime[1]), Int32.Parse(datetime[0]));

                Membre membre = new Membre(data[0], data[1],Date, data[3], Convert.ToChar(data[4]), data[5]) ;
                if (membre.Titre == "loisir")
                { membre.Classement = int.Parse(data[6]); }
                club.ListeMembre.Add(membre);
                counter++;
            }
            Console.WriteLine("La liste de membre du club : ");
            club.AfficherMembre(club.ListeMembre);
            file.Close();
        }
        
        static public void GestionFichier(Club club)
        {
            Console.WriteLine("\n0 : Pour retourner au menu principal");
            Console.WriteLine("1 : Enregistrement de fichier membres");
            Console.WriteLine("2 : Charger les données des membres");
            
            Console.Write("Votre saisie : ");
            int caseSwitch2 = Int32.Parse(Console.ReadLine());
            switch (caseSwitch2)
            {
                case 0:
                    MenuPricipale(club);
                    break;
                case 1:
                    CreationFichierMembre("Membre", club.ListeMembre);
                    goto default;
                case 2:
                    LectureFichierMembre("Membre",club);
                    goto default;
               
                default:
                    GestionFichier(club);
                    break;

            }
        }
        /// <summary>
        /// Creation des Tournois
        /// </summary>
        /// <param name="club"></param>
        static public Tournoi CreerTournoi()
        {
            Console.WriteLine("Entrez votre Année du Tournoi ");
            int annee = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Entrez votre Mois du Tournoi ");
            int mois = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Entrez votre Jour du Tournoi ");
            int jour = Int32.Parse(Console.ReadLine());
            return new Tournoi(new DateTime(annee, mois, jour));
        }
        static public void AfficherLesTournois(Club club)
        {
            foreach(Tournoi tournoi in club.ListeTournoi)
            {
                tournoi.ToString();
            }
        }
        static public Tournoi SelectionTournoi(Club club )
        {
            AfficherLesTournois(club);
            Console.WriteLine("Entrez l'ID du tournoi :  ");
            int jour = Int32.Parse(Console.ReadLine());
            return club.ListeTournoi[jour - 1];

        }
        static public void AjouterParticipantTournoi(Club club)

        {
            club.AfficherMembre(club.ListeMembre);
            Tournoi tournoi = SelectionTournoi(club);
            Membre membre = SelectionMembre(club);
            tournoi.Membre.Add(membre);


          
        }
        static public void GestionTournoi(Club club)
        {
            Console.WriteLine("\n0 : Pour retourner au menu principal");
            Console.WriteLine("1 : Créer un Tournoi");
            Console.WriteLine("2 : Afficher les tournois");
            Console.WriteLine("3 : Ajouter un participant à un tournoi");
            Console.Write("Votre saisie : ");
            int caseSwitch2 = Int32.Parse(Console.ReadLine());
            switch (caseSwitch2)
            {
                case 0:
                    MenuPricipale(club);
                    break;
                case 1:
                    Tournoi nouveau = CreerTournoi();
                    club.ListeTournoi.Add(nouveau);

                    goto default;
                case 2:
                    AfficherLesTournois(club);
                    goto default;
                case 3:
                    AjouterParticipantTournoi(club);
                    break;

                default:
                    GestionTournoi(club);
                    break;
            }
        }
        /// <summary>
        /// Gestion des Stages et des Cours de Tennis
        /// </summary>
        /// <param name="club"></param>
        
        
        static public void CreerCourt(Club club)
        {
            Console.WriteLine("Entrez votre Année du Court ");
            int annee = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Entrez votre Mois du Court ");
            int mois = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Entrez votre Jour du Court");
            int jour = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Entrez l'heure du Court ");
            int heure = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Entrez la minutes du Court ");
            int minutes = Int32.Parse(Console.ReadLine());
            club.Cours.Add(new DateTime(annee, mois, jour, heure, minutes, 0));

        }
        static public void AffichageCourt(Club club)
        {
            int c = 1;
            foreach(DateTime A in club.Cours)
            {
                Console.WriteLine("Les cours disponibles sont les suivants: " );
                Console.WriteLine(c + ": " + A.ToString());
            }
        }
        static void AffichageStage(Club club)
        {
            int c = 1;
            foreach (Stage A in club.Stages)
            {
                Console.WriteLine("Les stages disponibles sont les suivants: ");
                Console.WriteLine(c + ": " + A.ToString());
            }
        }
        static public DateTime SelectionCourt(Club club)
        {
            Console.WriteLine("Entrez le numéro du Cours : ");
            int id = Int32.Parse(Console.ReadLine());
            return club.Cours[id-1];
        }
        static public Stage SelectionStage(Club club)
        {
            Console.WriteLine("Entrez le numéro du Stage : ");
            int id = Int32.Parse(Console.ReadLine());
            return club.Stages[id - 1];
        }
        static public Stage CreerStage(Club club)
        {
            AfficherEntraineur(club);
            Console.WriteLine("Entrer l'identifiant du Entrainement : ");
            int id = Int32.Parse(Console.ReadLine());
            Entraineur entraineur = club.Entraineurs[id - 1];
            entraineur.NbCours++;
            AffichageCourt(club);
            Console.WriteLine("Entrer l'identifiant du Cours : ");
            int id_cours = Int32.Parse(Console.ReadLine());
            return new Stage(entraineur, club.Cours[id_cours - 1]);

        }
        static public void AjouterMembreDansStage(Club club,Stage stage)
        {
            List<Membre> Mineurs = club.MembresMineurs();
            club.AfficherMembre(Mineurs);
            Console.WriteLine("Entrer l'identifiant du membres : ");
            int id = Int32.Parse(Console.ReadLine());
            stage.Membres.Add(Mineurs[id - 1]);

        }
        static public void GestionStage(Club club)
        {
            Console.WriteLine("\n0 : Pour revenir au Menu Principal ");
            Console.WriteLine("1 : Pour Créer un stage");
            Console.WriteLine("2 : Ajouter un Membre dans un stage");
            Console.WriteLine("3 : Afficher l'ensemble des stages ");
            Console.WriteLine("4 : Afficher les membres dans un stage");
            Console.WriteLine("5 : Creation d'un Cours");
            int caseSwitch = Int32.Parse(Console.ReadLine());

            switch (caseSwitch)
            {
                case 0:
                    MenuPricipale(club);
                    break;

                case 1:
                    Stage stage = CreerStage(club);
                    club.Stages.Add(stage);
                    goto default;
                case 2:
                    Stage stage1 = SelectionStage(club);
                    AjouterMembreDansStage(club, stage1);
                    break;
                case 3:
                    AffichageStage(club);
                    break;
                case 4:
                    Stage stage2 = SelectionStage(club);
                    club.AfficherMembre(stage2.Membres);
                    break;
                case 5:
                    CreerCourt(club);
                    break; 
                default:
                    GestionStage(club);
                    break;

            }
        }
        
        
        static public void MenuPricipale(Club club)
        {
            Console.WriteLine("\n0 : Pour quitter le programme");
            Console.WriteLine("1 : Pour enregistrer les membres ou pour lire des membres dans un fichier");
            Console.WriteLine("2 : Gestion des Membres ");
            Console.WriteLine("3 : Gestion des salarié");
            Console.WriteLine("4 : Gestions des joueurs du club inscrits en compétition");
            Console.WriteLine("5 : Gestion des Tournois");
            Console.WriteLine("6: Gestion des stages de tennis");
            Console.WriteLine("5 : Gestion des Entraineurs");
            Console.Write("Votre saisie : ");
            int caseSwitch = Int32.Parse(Console.ReadLine());

            switch (caseSwitch)
            {
                case 0:
                    Console.WriteLine("\n\nsAu revoir ");
                    break;

                case 1:
                    GestionFichier(club);
                    goto default;
                case 2:
                    GestionMembre(club);

                    break;
                case 3:
                    GestionPersonnel(club);
                    break;
                case 4:
                    GestionCompt(club);
                    break;
                case 5:
                    GestionTournoi(club);
                    break;
                case 6:
                    if (club.Cours.Count == 0) 
                    {
                        Console.WriteLine("Nous créons une date car il n'y a pas de cours disponible");
                        CreerCourt(club); 
                    }
                    if (club.Entraineurs.Count == 0) 
                    {
                        Console.WriteLine("Nous créons un entraineur car il n'y  pas de entraineur au club");
                        club.Entraineurs.Add(CreationEntraineur()); 
                    }

                    Stage stage = CreerStage(club);
                    club.Stages.Add(stage);
                    GestionStage(club);
                    break;

                case 7:
                    GestionEntraineur(club);
                    break;
                default:
                    MenuPricipale(club);
                    break;
            }
            }

            static void Main(string[] args)
            {
            Console.WriteLine("Entrer le chemin du fichier du membres : ");
            //Entrer manuellement le chemin si cela ne fonctionne pas
            string dir = @"C:/Users/Asus/Documents/Cours Esilv/POO Avancé/Club de Tennis_ HELALI Nader/Tennis_Club/Tennis_Club/NewFolder";
            string dir1 = Console.ReadLine();
            try
            {
                //Set the current directory.
                Directory.SetCurrentDirectory(dir1);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("Le dossier n'existe pas ", e);
            }
            
            Club club = CreerClub();
            Console.WriteLine(club.Afficher());
            Console.WriteLine("Le Fichier des membres est en cours de lecture \n");
            LectureFichierMembre("Membre", club);
            MenuPricipale(club);
            

            }
    }
}
