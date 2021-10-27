using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    public interface IUsersService
    {
        IEnumerable<Users> GetAll();
        Users GetById(int id);
        bool Delete(int id);

        int Insert(Users user);

        bool Update(Users user);

        Users Login(Users u);
    }
}
