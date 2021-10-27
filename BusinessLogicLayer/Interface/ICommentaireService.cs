using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    public interface ICommentaireService
    {
        IEnumerable<Commentaires> GetAll(int Id);
        bool Delete(int Id);
        int Insert(Commentaires model);
        bool Update(Commentaires model);
    }
}
