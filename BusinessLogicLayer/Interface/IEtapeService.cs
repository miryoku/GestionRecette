using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    public interface IEtapeService
    {
        IEnumerable<Etapes> GetAll();
        Etapes GetById(int Id);
        bool Delete(int Id);
        int Insert(Etapes model);
        bool Update(Etapes model);

        IEnumerable<Intermediaire> GetByIdTEtape(int id);
    }
}
