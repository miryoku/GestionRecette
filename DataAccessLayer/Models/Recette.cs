using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Recette
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public string  Img { get; set; }

        public int NbPersonne { get; set; }

        public int Id_categorie { get; set; }
        public string NomCategorie { get; set; }

        public int Prepration { get; set; }

        public int Repos { get; set; }

        public int Cuisson { get; set; }
        public string Rating { get; set; }

    }
}
