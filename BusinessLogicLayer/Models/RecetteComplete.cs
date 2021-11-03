using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class RecetteComplete
    {
        public Recette recette{ get; set; }
        public List<IngredientQuantiteUnite>  Composant{ get; set; }


        public List<UstensilesQuantite> Ustensiles { get; set; }
        public List<Etapes> Etapes { get; set; }
    }

    
}
