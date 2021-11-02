using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    public interface IIngredientService
    {
        IEnumerable<Ingredient> GetAll();
        Ingredient GetById(int Id);
        bool Delete(int Id);
        int Insert(Ingredient model);
        bool Update(Ingredient model);

        void InsertUstensile(Intermediaire model);

        void UpdateUstensile(Intermediaire model);
        void DeleteUstensile(int model);

        IEnumerable<Intermediaire> GetByIdIntermediaire(int Id);
    }
}
