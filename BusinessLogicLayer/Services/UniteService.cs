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
    public class UniteService : IUniteService
    {
        private IUniteRespository _service;

        public UniteService(IUniteRespository respo)
        {
            _service = respo;
        }

        public bool Delete(int Id)
        {
            return _service.Delete(Id);
        }

        public IEnumerable<Unites> GetAll()
        {
            return _service.GetAll().Select(x => x.ToBLL());
        }

        public Unites GetById(int Id)
        {
            return _service.GetById(Id).ToBLL();
        }

        public int Insert(Unites model)
        {
            return _service.Insert(model.ToDAL());
        }

        public bool Update(Unites model)
        {
            return _service.Update(model.ToDAL());
        }
    }
}
