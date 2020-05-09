using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis_Club
{
    class Personnel : Personne
    {
        private int salaire;
        private string iban;
        private DateTime entree;

        public Personnel(string nom, string prenom, DateTime naissance, string adresse, char genre, int salaire, string iban, DateTime entree):base(nom,prenom,naissance,adresse,genre )
        {
            this.salaire = salaire;
            this.iban = iban;
            this.entree = entree; 
        }
        public string Iban { get { return iban; } }
        public int Salaire { get { return salaire; } }
        public DateTime Entree { get { return entree; } }

        public string Afficher()
        {
            return  Genre + " : " + Nom + " " + Prenom + " néé le " + Naissance + " habite à " + Adresse +"est à un salaire de "+salaire+"e a intégré le club le "+Entree;
        }
    }
}
