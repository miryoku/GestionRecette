using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class UstensilesQuantite
    {
        public int Id { get; set; }

        public Ustensiles Ustensiles{ get; set; }

        public int Quantite{ get; set; }
    }
}
