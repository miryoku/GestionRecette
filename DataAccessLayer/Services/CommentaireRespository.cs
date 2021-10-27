using ADOLibrary;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DataAccessLayer.Tools;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class CommentaireRespository : ICommentaireRespository
    {
        private string _connectionString;

        public CommentaireRespository(IConfiguration config)
        {
            _connectionString= config.GetConnectionString("default");
        }

        public bool Delete(int Id)
        {
            Command cmd = new Command("Delete from Commentaire where Id = @id");
            cmd.AddParameter("id", Id);
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            return cnx.ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<Commentaires> GetAll(int id)
        {
            Command cmd = new Command("select * from Commentaire where id_recette=@id");
            cmd.AddParameter("id", id);
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            return cnx.ExecuteReader<Commentaires>(cmd, Mappers.CommentaireConverter);
        }

        public int Insert(Commentaires model)
        {
            Command cmd = new Command("insert into Commentaire(id_user,id_recette,commentaire,dates) OUTPUT Inserted.ID  values(@idU,@idR,@comm,getdate())");
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            cmd.AddParameter("idU", model.Id_user);
            cmd.AddParameter("idR", model.Id_recette);
            cmd.AddParameter("comm", model.Commentaire);
            model.Id = (int)cnx.ExecuteScalar(cmd);
            return model.Id;
        }

        public bool Update(Commentaires model)
        {

            Command cmd = new Command("update Commentaire set commentaire=@comm where id=@id ");
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            cmd.AddParameter("comm", model.Commentaire);
            cmd.AddParameter("id", model.Id);
            cnx.ExecuteNonQuery(cmd);
            return true;
        }
    }
}
