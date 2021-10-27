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
    public class EtapeService : IEtapeService
    {
        private IEtapeRespository _service;

        public EtapeService(IEtapeRespository etapeService)
        {
            _service = etapeService;
        }
        public bool Delete(int Id)
        {
            return _service.Delete(Id);
        }

        public IEnumerable<Etapes> GetAll()
        {
            return _service.GetAll().Select(x=>x.ToBLL());
        }

        public Etapes GetById(int Id)
        {
            return _service.GetById(Id).ToBLL();
        }

        public int Insert(Etapes model)
        {
            int x = _service.Insert(model.ToDAL());
            _service.InsertLienTAble(x, model.Id);
            return x;
        }

        public bool Update(Etapes model)
        {
            return _service.Update(model.ToDAL());
        }
    }
}
