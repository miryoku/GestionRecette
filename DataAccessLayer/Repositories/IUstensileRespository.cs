using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IUstensileRespository
    {
        IEnumerable<Ustensile> GetAll();
        Ustensile GetById(int Id);
        bool Delete(int Id);
        int Insert(Ustensile model);
        bool Update(Ustensile model);

        void InsertLienTable(Intermediaire model);

        void UpdateLienTable(Intermediaire model);

        bool DeleteLienTable(int id);

        IEnumerable<Intermediaire> GetByIdIntermediaire(int Id);
    }
}
