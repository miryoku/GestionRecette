using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Speudo { get; set; }
        public string Mdp { get; set; }

        public string Roles { get; set; }

        public int Id_role{ get; set; }
        public string Token { get; set; }

    }
}
