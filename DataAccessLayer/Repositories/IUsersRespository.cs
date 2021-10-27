using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IUsersRespository
    {
        IEnumerable<Users> GetAll();
        Users GetById(int Id);
        bool Delete(int Id);
        int Insert(Users model);
        bool Update(Users model);

        Users Login(Users u);
    }
}
