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
    public class CategorieService : ICategorieService
    {
        ICategorieRespository _service;

        public CategorieService(ICategorieRespository serv)
        {
            _service = serv;
        }

        public bool Delete(int Id)
        {
            return _service.Delete(Id);
        }

        public IEnumerable<Categorie> GetAll()
        {
            return  _service.GetAll().Select(x=>x.ToBLL());
        }

        public Categorie GetById(int Id)
        {
            return _service.GetById(Id).ToBLL();
        }

        public int Insert(Categorie model)
        {
            return _service.Insert(model.ToDAL());
        }

        public bool Update(Categorie model)
        {
            return _service.Update(model.ToDAL());
        }
    }
}
