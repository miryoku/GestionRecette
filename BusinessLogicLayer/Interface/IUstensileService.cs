using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    public interface IUstensileService
    {
        IEnumerable<Ustensiles> GetAll();
        Ustensiles GetById(int Id);
        bool Delete(int Id);
        int Insert(Ustensiles model);
        bool Update(Ustensiles model);

        void InsertUstensile(Intermediaire model);

        void UpdateUstensile(Intermediaire model);
        void DeleteUstensile(int model);

       Intermediaire GetByIdIntermediaire(int Id);
    }
}
