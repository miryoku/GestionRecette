using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    public interface IUniteService
    {
        IEnumerable<Unites> GetAll();
        Unites GetById(int Id);
        bool Delete(int Id);
        int Insert(Unites model);
        bool Update(Unites model);
    }
}
