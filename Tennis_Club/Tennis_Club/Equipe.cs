using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis_Club
{
    class Equipe 
    {
        public static int numeroEquipe;
        private List<Membre> listeMembre;
        private string categorie;
        private int resultat; 


        
        public Equipe(string categorie, List<Membre> listeMembre)
        {
            this.categorie = categorie;
            numeroEquipe+=1;
            this.listeMembre = listeMembre;

        }
        public List<Membre> ListeMembre
        {
            get { return listeMembre; }
        }
        public int NumEquipe
        {
            get { return numeroEquipe; }
        }
        public string Categorie  
        {
            get { return categorie; }
        }
        public override string ToString()
        {
            return "L'équipe n°" + numeroEquipe + " a une catégorie de : " + categorie;
        }
        public string EnregistrementEquipe()
        {
            string ensmembre = "";
            foreach(Membre m in ListeMembre)
            {
                ensmembre += m.EnregistrementFichier();
            }
            return categorie + ";" + numeroEquipe + ";" + ensmembre;
        }
      
    }
}
