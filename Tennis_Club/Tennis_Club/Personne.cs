using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis_Club
{
    abstract class Personne 
    {
        private string nom;
        private string prenom;
        private DateTime naissance;
        private string adresse;
        private char genre;
        public Personne(string nom,string prenom,DateTime naissance, string adresse, char genre)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.naissance = naissance;
            this.adresse = adresse;
            this.genre = genre;
        }
        public string Nom { get { return nom; } }
        public string Prenom { get { return prenom; } }
        public string Adresse { get { return adresse; }
            set { adresse=value; } }
        public DateTime Naissance { get { return naissance; } }
        public char Genre { get { return genre; } }
      
        public override string ToString()
        {
            return genre +" : "+  Nom + " " + Prenom + " néé le " + Naissance + " habite à " + adresse;
        }
    }
}
