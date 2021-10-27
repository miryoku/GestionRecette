using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IRecetteRespository
    {
        IEnumerable<Recette> GetAll();
        Recette GetById(int Id);
        bool Delete(int Id);
        int Insert(Recette model);
        bool Update(Recette model);
    }
}
