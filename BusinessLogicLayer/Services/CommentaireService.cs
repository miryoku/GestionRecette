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
    public class CommentaireService : ICommentaireService
    {
        private ICommentaireRespository _service;

        public CommentaireService(ICommentaireRespository serv)
        {
            _service = serv;
        }
        public bool Delete(int Id)
        {
            return _service.Delete(Id);
        }

        public IEnumerable<Commentaires> GetAll(int Id)
        {
            return _service.GetAll(Id).Select(x => x.ToBLL());
        }

        public int Insert(Commentaires model)
        {
            return _service.Insert(model.ToDAL());
        }

        public bool Update(Commentaires model)
        {
            return _service.Update(model.ToDAL());
        }
    }
}
