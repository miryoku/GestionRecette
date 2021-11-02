using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IEtapeRespository
    {
        IEnumerable<Etapes> GetAll();
        Etapes GetById(int Id);
        bool Delete(int Id);
        int Insert(Etapes model);
        bool Update(Etapes model);

        void InsertLienTAble(int idEtape, int idRecette);

        IEnumerable<Intermediaire> GetByIdTEtape(int id);
    }
}
