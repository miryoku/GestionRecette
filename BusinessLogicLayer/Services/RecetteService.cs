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
    public class RecetteService : IRecetteService
    {
        private IRecetteRespository _RecetteService;

        public RecetteService(IRecetteRespository ReceteRepo)
        {
            _RecetteService = ReceteRepo;
        }
        public bool Delete(int Id)
        {
           return _RecetteService.Delete(Id);
        }

        public IEnumerable<Recette> GetAll()
        {
            return _RecetteService.GetAll().Select(x=>x.ToBLL());
        }

        public Recette GetById(int Id)
        {
            return _RecetteService.GetById(Id).ToBLL();
        }

        public int Insert(Recette model)
        {
            return _RecetteService.Insert(model.ToDAL());
        }

        public bool Update(Recette model)
        {
            return _RecetteService.Update(model.ToDAL());
        }
    }
}
