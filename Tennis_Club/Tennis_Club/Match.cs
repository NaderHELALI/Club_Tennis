using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis_Club
{
    class Match : Evenements
    {

        private int numeroMatch;
        
        private string type;
        private Equipe equipe;
        private int resultat;


        public Match(int numeroMatch, string type, Equipe equipe, int resultat, DateTime date) : base(date)
        {
            this.numeroMatch = numeroMatch;
            this.type = type;
            this.equipe = equipe;
            this.resultat = resultat;
        }
        public Match(int numeroMatch, string type, Equipe equipe, DateTime date) : base(date)
        {
            this.numeroMatch = numeroMatch;
            this.type = type;
            this.equipe = equipe;
        }

        public int NumeroMatch
        {
            get { return numeroMatch; }
        }
        public int Resultat
        {
            get { return resultat; }
        }
    }
}