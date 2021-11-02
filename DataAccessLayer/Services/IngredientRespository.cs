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
    public class IngredientRespository : IIngredientRespository
    {
        private string _connectionString;

        public IngredientRespository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("default");
        }
        public bool Delete(int Id)
        {
            Command cmd = new Command("Delete from Ingredient where Id = @id");
            cmd.AddParameter("id", Id);
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            return cnx.ExecuteNonQuery(cmd) == 1;
        }

        public bool DeleteLienTable(int id)
        {
            Command cmd = new Command("Delete from TIngredient where Id = @id");
            cmd.AddParameter("id", id);
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            return cnx.ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<Ingredient> GetAll()
        {
            Command cmd = new Command("select * from Ingredient");
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            return cnx.ExecuteReader<Ingredient>(cmd, Mappers.IngredientConverter);
        }

        public Ingredient GetById(int Id)
        {
            Command cmd = new Command("select * from Ingredient where Id=@id");
            cmd.AddParameter("id", Id);
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            return cnx.ExecuteReader<Ingredient>(cmd, Mappers.IngredientConverter).FirstOrDefault();
        }

        public IEnumerable<Intermediaire> GetByIdIntermediaire(int Id)
        {
            Command cmd = new Command("select Id,id_recette idRecette,id_ingredient idBis,id_unite idTries, quantite  from TIngredient where id_recette=@id");
            cmd.AddParameter("id", Id);
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            return cnx.ExecuteReader<Intermediaire>(cmd, Mappers.Intermediaire2Converter);
        }

        public int Insert(Ingredient model)
        {
            Command cmd = new Command("insert into Ingredient(nom,descriptions,img)values(@nom,@descriptions,@img)");
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            cmd.AddParameter("nom", model.Nom);
            cmd.AddParameter("descriptions", model.Descrptions);
            cmd.AddParameter("img",model.Img);
            return cnx.ExecuteNonQuery(cmd);
        }

        public void InsertLienTable(Intermediaire model)
        {
            Command cmd = new Command("insert into TIngredient(id_recette,id_Ingredient,id_unite,quantite)values(@idR,@idI,@idU,@quantite)");
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            cmd.AddParameter("idR", model.IdRecette);
            cmd.AddParameter("idI", model.IdBis);
            cmd.AddParameter("idU", model.IdTries);
            cmd.AddParameter("quantite", model.Quantite);
            cnx.ExecuteNonQuery(cmd);
        }

        public bool Update(Ingredient model)
        {
            Command cmd = new Command("update Ingredient set nom=@nom,descriptions=@descriptions where id=@id ");
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            cmd.AddParameter("nom", model.Nom);
            cmd.AddParameter("descriptions", model.Descrptions);
            cmd.AddParameter("img", model.Img);
            cmd.AddParameter("id", model.Id);
            cnx.ExecuteNonQuery(cmd);
            return true;
        }

        public void UpdateLienTable(Intermediaire model)
        {
            Command cmd = new Command("update TIngredient set id_recette=@idR,id_ingredient=@idI, id_unite=@idU,quantite=@quantite where id=@id ");
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            cmd.AddParameter("idR", model.IdRecette);
            cmd.AddParameter("idI", model.IdBis);
            cmd.AddParameter("idU", model.IdTries);
            cmd.AddParameter("quantite", model.Quantite);
            cmd.AddParameter("id", model.Id);
            cnx.ExecuteNonQuery(cmd);
        }
    }
}
