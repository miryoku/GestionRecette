﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class Intermediaire
    {
        public int Id { get; set; }

        public int IdRecette { get; set; }
        public int IdBis { get; set; }
        public int Quantite { get; set; }

    }
}
