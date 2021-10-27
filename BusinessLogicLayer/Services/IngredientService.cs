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
    public class IngredientService : IIngredientService
    {
        private IIngredientRespository _service;

        public IngredientService(IIngredientRespository ingredientRespository)
        {
            _service = ingredientRespository;
        }
        public bool Delete(int Id)
        {
            return _service.Delete(Id);
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return _service.GetAll().Select(x => x.ToBLL());
        }

        public Ingredient GetById(int Id)
        {
            return _service.GetById(Id).ToBLL();
        }

        public int Insert(Ingredient model)
        {
            return _service.Insert(model.ToDAL());
        }

        public bool Update(Ingredient model)
        {
            return _service.Update(model.ToDAL());
        }
    }
}
