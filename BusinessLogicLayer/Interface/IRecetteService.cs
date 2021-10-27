using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    public interface IRecetteService
    {
        IEnumerable<Recette> GetAll();
        Recette GetById(int Id);
        bool Delete(int Id);
        int Insert(Recette model);
        bool Update(Recette model);
    }
}
