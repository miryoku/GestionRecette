using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface ICommentaireRespository
    {
        IEnumerable<Commentaires> GetAll(int id);
        bool Delete(int Id);
        int Insert(Commentaires model);
        bool Update(Commentaires model);
    }
}
