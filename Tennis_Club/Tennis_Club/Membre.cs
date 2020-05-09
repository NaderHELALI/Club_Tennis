using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis_Club
{
    class Membre : Personne ,IComparable<Membre>
    {
        private string titre;
        private bool cotisation;
        private int classement;

        public Membre(string nom, string prenom, DateTime naissance, string adresse, char genre, string titre) : base(nom, prenom, naissance, adresse, genre)
        {
            if (titre == "competitif")
            {
                Console.WriteLine("Entrez votre classement du membre "+nom+" "+prenom+" : ");
                classement = Int32.Parse(Console.ReadLine());
            }
            this.titre = titre;
            this.cotisation = false;
        }
        public string Titre { get { return titre; } set { titre = value; } }
        public bool Cotisation
        {
            get { return cotisation; }
            set { cotisation = value; }
        }
        public int Classement
        {
            get { return classement; }
            set { classement = value; }
        }


        public int Age()
        {
            
                return DateTime.Now.Year - Naissance.Year -
                         (DateTime.Now.Month < Naissance.Month ? 1 :
                         (DateTime.Now.Month == Naissance.Month && DateTime.Now.Day < Naissance.Day) ? 1 : 0);
            
        }
        public string Afficher()
        {
            string a = " a réglé la cotisation";
            if (cotisation == false)
            {
                a = " n' a pas réglé la cotisation";
            }
            
            return Genre + " : " + Nom + " " + Prenom + " néé le " + Naissance + " habite à " + Adresse+a;
        }
        public int RegCotisation(Club B)
        {
            if (Adresse==B.Ville)
            {
                if (Age() < 18)
                {
                    return 130;
                }
                else { return 200; }
            }
            else
            {
                if (Age() < 18)
                {
                    return 180;
                }
                else { return 280; }

            }
        }
        public string EnregistrementFichier()
        {
            return base.Nom+";"+base.Prenom + ";" + base.Naissance + ";" + base.Adresse + ";" + base.Genre+ ";"+ titre + ";" +cotisation+";" + Classement;
        }

        public int CompareTo(Membre m)
        {

            int res = 0;

            if (this.Classement < m.Classement)
            {
                res = -1;
            }
            else
                res = 1;
            return res;

        }
    }
}
