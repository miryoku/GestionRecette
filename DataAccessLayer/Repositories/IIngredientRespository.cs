using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IIngredientRespository
    {
        IEnumerable<Ingredient> GetAll();
        Ingredient GetById(int Id);
        bool Delete(int Id);
        int Insert(Ingredient model);
        bool Update(Ingredient model);

        void InsertLienTable(Intermediaire model);

        void UpdateLienTable(Intermediaire model);

        bool DeleteLienTable(int id);

        Intermediaire GetByIdIntermediaire(int Id);

    }
}
