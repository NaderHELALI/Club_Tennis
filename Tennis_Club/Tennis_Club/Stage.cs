using System;
using System.Collections.Generic;
using System.Text;


namespace Tennis_Club
{
    class Stage
    {
        Entraineur entraineur;
        List<Membre> membres;
        DateTime horaire;
        public Stage(Entraineur entraineur, DateTime horaire)
        {
            this.entraineur = entraineur;
            this.membres = new List<Membre>();
            this.horaire = horaire;
        }
        public Entraineur Entraineur
        {
            get { return entraineur; }
            set { entraineur = value; }
        }
        public List<Membre> Membres
        {
            get { return membres; }
            set { membres = value; }
        }
        public DateTime Horaire
        {
            get { return horaire; }
            set { horaire = value; }
        }
        public override string ToString()
        {
            return " Le Stage est dirigé par" + Entraineur.Nom + " le " + Horaire;
        }
    }
}
