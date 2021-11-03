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
    public class UstensileRespository : IUstensileRespository
    {
        private string _connectionString;

        public UstensileRespository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("default");
        }
        public bool Delete(int Id)
        {
            Command cmd = new Command("Delete from Ustensiles where Id = @id");
            cmd.AddParameter("id", Id);
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            return cnx.ExecuteNonQuery(cmd) == 1;
        }

        public void DeleteLienTable(int id)
        {
            Command cmd = new Command("Delete from TUstensiles where Id = @id");
            cmd.AddParameter("id",id);
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
             cnx.ExecuteNonQuery(cmd) ;
        }

        public IEnumerable<Ustensile> GetAll()
        {
            Command cmd = new Command("select * from Ustensiles");
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            return cnx.ExecuteReader<Ustensile>(cmd, Mappers.UstensileConverter);
        }

        public Ustensile GetById(int Id)
        {
            Command cmd = new Command("select * from Ustensiles where Id=@id");
            cmd.AddParameter("id", Id);
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            return cnx.ExecuteReader<Ustensile>(cmd, Mappers.UstensileConverter).FirstOrDefault();
        }

        public IEnumerable<Intermediaire> GetByIdIntermediaire(int Id)
        {
            Command cmd = new Command("select id,id_recette idRecette,id_ustensiles idBis,quantite from TUstensiles where Id_Recette=@id");
            cmd.AddParameter("id", Id);
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            return cnx.ExecuteReader<Intermediaire>(cmd, Mappers.IntermediaireConverter);
        }

        public int Insert(Ustensile model)
        {
            Command cmd = new Command("insert into Ustensiles(nom,img) output Inserted.ID values(@nom,@img)");
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            cmd.AddParameter("nom", model.Nom);
            cmd.AddParameter("img", model.Img);
            model.Id=(int)cnx.ExecuteScalar(cmd);
            return model.Id;
        }

        public void InsertLienTable(Intermediaire model)
        {

            Command cmd = new Command("insert into TUstensiles(id_ustensiles,id_recette,quantite) values(@idBis,@idRecette,@quantite)");
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            cmd.AddParameter("idBis",model.IdBis);
            cmd.AddParameter("idRecette", model.IdRecette);
            cmd.AddParameter("quantite", model.Quantite);
            cnx.ExecuteNonQuery(cmd);
        }

        public bool Update(Ustensile model)
        {
            Command cmd = new Command("update Ustensiles set nom=@nom,img=@img where id=@id ");
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            cmd.AddParameter("nom", model.Nom);
            cmd.AddParameter("img", model.Img); 
            cmd.AddParameter("id", model.Id);
            cnx.ExecuteNonQuery(cmd);
            return true;
        }

        public void UpdateLienTable(Intermediaire model)
        {
            Command cmd = new Command("update TUstensiles set quantite=@quantite where id=@id ");
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            cmd.AddParameter("quantite", model.Quantite);
            cmd.AddParameter("id", model.Id);
            cnx.ExecuteNonQuery(cmd);
        }

        bool IUstensileRespository.DeleteLienTable(int id)
        {
            Command cmd = new Command("delete from TUstensiles where id=@id");
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            cmd.AddParameter("id",id);
            cnx.ExecuteNonQuery(cmd);
            return true;
        }
    }
}
