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
    public class CategorieRespository : ICategorieRespository
    {
        private string _connectionString;

        public CategorieRespository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("default");
        }

        public bool Delete(int Id)
        {
            Command cmd = new Command("Delete from categorie where Id = @id ");
            cmd.AddParameter("id", Id);
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            return cnx.ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<Categorie> GetAll()
        {
            Command cmd = new Command("select * from categorie order by nom");
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            return cnx.ExecuteReader<Categorie>(cmd, Mappers.CategorieConverter);
        }

        public Categorie GetById(int Id)
        {
            Command cmd = new Command("select * from categorie where Id=@id");
            cmd.AddParameter("id", Id);
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            return cnx.ExecuteReader<Categorie>(cmd, Mappers.CategorieConverter).FirstOrDefault();
        }

        public int Insert(Categorie model)
        {
            Command cmd = new Command("insert into Categorie(nom)values(@nom)");
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            cmd.AddParameter("nom", model.Nom);
            return cnx.ExecuteNonQuery(cmd);
        }

        public bool Update(Categorie model)
        {
            Command cmd = new Command("update categorie set nom=@nom where id=@id ");
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            cmd.AddParameter("nom", model.Nom);
            cmd.AddParameter("id", model.Id);
            cnx.ExecuteNonQuery(cmd);
            return true;
        }
    }
}
