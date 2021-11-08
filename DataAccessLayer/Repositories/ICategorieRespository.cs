using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface ICategorieRespository
    {
        IEnumerable<Categorie> GetAll();
        Categorie GetById(int Id);
        bool Delete(int Id);
        int Insert(Categorie model);
        bool Update(Categorie model);

    }
}
