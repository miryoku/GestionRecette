using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class Commentaires
    {
        public int Id { get; set; }

        public int Id_user { get; set; }

        public int Id_recette { get; set; }

        public string Commentaire { get; set; }

        public DateTime Dates { get; set; }
    }
}
