using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis_Club
{
    class Entraineur : Personne
    {
        private string statut;
        private int nbCours;

        public Entraineur(string statut, int nbCours, string nom, string prenom, DateTime naissance, string adresse, char genre) : base(nom,prenom,naissance,adresse,genre)
            {
               this.statut = statut;
               this.nbCours = nbCours;
            }

        public string Statut
        {
            get { return this.statut; }
            set { this.statut = value; }
        }

        public int NbCours
        {

            get { return this.nbCours; }
            set { this.nbCours = value; }
        }

        public override string ToString()
        {
            return base.ToString() + "Le statut est : " + statut + ", le nombre de cours est : " + nbCours;
        }
    }
}
