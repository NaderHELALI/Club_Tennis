using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis_Club
{
    class Tournoi : Evenements
    {
        List<Membre> EnsMembre=new List<Membre>();
        static int identifiant=1;
        public Tournoi(DateTime date):base(date)
        {
            identifiant += 1;
        }
        public List<Membre> Membre { get { return EnsMembre; } }
        public int Identifiant { get { return identifiant; } }
        public override string ToString()
        {
            return "Id : " + identifiant + " le tournoi a lieu le " + base.Date;
        }
    }
}
