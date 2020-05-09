using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis_Club
{
    class Competition : Evenements
    {
        private string nom;
        private string niveau;
        private int nbJour;
        private int nbJoueur;
        private int nbMatch;
        private List<Equipe> EnsEquipe;
        private static List<int> Stats = new List<int>();
        

        public Competition(string nom, string niveau, int nbJour, int nbJoueur, int nbMatch, DateTime date,List<Equipe> EnsEquipe) : base(date)
        {
            this.nom = nom;
            this.niveau = niveau;
            this.nbJour = nbJour;
            this.nbJoueur = nbJoueur;
            this.nbMatch = nbMatch;
            this.EnsEquipe = EnsEquipe;
        }

        public string Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }

        public string Niveau
        {
            get { return this.niveau; }
            set { this.niveau = value; }
        }

        public int NbJour
        {
            get { return this.nbJour; }
            set { this.nbJour = value; }
        }
        public int NbJoueur
        {
            get { return this.nbJoueur; }
            set { this.nbJoueur = value; }

        }

        public int NbMatch
        {
            get { return this.nbMatch; }
            set { this.nbMatch = value; }

        }
        public List<Equipe> Equipe
        {
            get { return EnsEquipe; }

        }



        public string TypeDeMatch(int nbJoueurM)
        {
            string rep = "double";
            if (nbJoueurM == 2)
            {
                rep = "simple";
            
            }
           
            return rep;
        }

        public string TypeDeCompetition()
        {
            int nbJoueurM = int.Parse(Console.ReadLine());
            string type = TypeDeMatch(nbJoueurM);
            for (int i=2;i<=nbMatch;i++)
            {
                nbJoueurM = int.Parse(Console.ReadLine());
                if (type != TypeDeMatch(nbJoueurM))
                {
                    type = "Equipe";
                }

            }
            return type;
        }
        public override string ToString()
        {
            return  Nom + " acceuille " + nbJoueur + " participants sur "+nbJour+" jours";
        }
        public void AfficherEquipe()
        {
            ToString();
            foreach (Equipe equipe in Equipe)
            {
                Console.WriteLine(equipe.ToString());
            }
        }
        public void AfficherEquipeMembre(Equipe equipe)
        {
            ToString();
            foreach (Membre membre in equipe.ListeMembre)
            {
                Console.WriteLine(membre.ToString());
                Console.WriteLine();
            }
        }


    }
}
