using BusinessLogicLayer.Interface;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Tools;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class UstensileService : IUstensileService
    {
        private IUstensileRespository _service;

        public UstensileService(IUstensileRespository serv)
        {
            _service = serv;
        }
        public bool Delete(int Id)
        {
            return _service.Delete(Id);
        }

        public void DeleteUstensile(int id)
        {
            _service.DeleteLienTable(id);
        }

        public IEnumerable<Ustensiles> GetAll()
        {
            return _service.GetAll().Select(x => x.ToBLL());
        }

        public Ustensiles GetById(int Id)
        {
            return _service.GetById(Id).ToBLL();
        }

        public Intermediaire GetByIdIntermediaire(int Id)
        {
            return _service.GetByIdIntermediaire(Id).ToBLL();
        }

        public int Insert(Ustensiles model)
        {
            return _service.Insert(model.ToDAL());
        }

        public void InsertUstensile(Intermediaire model)
        {
             _service.InsertLienTable(model.ToDAL());
        }

        public bool Update(Ustensiles model)
        {
            return _service.Update(model.ToDAL());
        }

        public void UpdateUstensile(Intermediaire model)
        {
            _service.UpdateLienTable(model.ToDAL());
        }
    }
}
