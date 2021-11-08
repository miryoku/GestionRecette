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
    public class RecetteRepository : IRecetteRespository
    {

        private string _connectionString;

        public RecetteRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("default");
        }
        public bool Delete(int Id)
        {
            Command cmd = new Command("Delete from Recette where Id = @id");
            cmd.AddParameter("id", Id);
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            return cnx.ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<Recette> GetAll()
        {
            Command cmd = new Command("SELECT Recette.Id, Recette.nom, Recette.nbPersonne, Recette.img, Categorie.nom NomCategorie, AVG(Rating.note) rating FROM Recette INNER JOIN Categorie ON Recette.id_categorie = Categorie.Id LEFT OUTER JOIN Rating ON Recette.Id = Rating.id_recette group by Recette.Id, Recette.nom, REcette.nbPersonne, Recette.img, Categorie.nom");
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            return cnx.ExecuteReader<Recette>(cmd, Mappers.RecetteConverter);
        }

        public Recette GetById(int Id)
        {
            Command cmd = new Command("select r.Id,r.nom,r.nbPersonne,r.img,c.nom NomCategorie,r.cuisson,r.preparation,r.repos , avg(ra.note) rating  from Recette r, Categorie c, Rating ra where r.id_categorie = c.Id and ra.id_recette = r.Id and r.id = @id group by r.Id, r.nom, r.nbPersonne, r.img, c.nom, r.cuisson, r.preparation, r.repos ");
            cmd.AddParameter("id", Id);
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            Recette r= cnx.ExecuteReader<Recette>(cmd, Mappers.RecetteAllConverter).FirstOrDefault();

            if(r is null)
            {
                cmd = new Command("select r.Id,r.nom,r.nbPersonne,r.img,c.nom NomCategorie, r.cuisson,r.preparation,r.repos from Recette r, Categorie c where r.id_categorie = c.Id and r.id = @id group by r.Id, r.nom, r.nbPersonne, r.img, c.nom, r.cuisson, r.preparation, r.repos");
                cmd.AddParameter("id", Id);
                cnx = new Connection(SqlClientFactory.Instance, _connectionString);
                r = cnx.ExecuteReader<Recette>(cmd, Mappers.RecetteAllConverterNotRating).FirstOrDefault();
              //  r.Rating = "1";
            }
            return r;


        }

        public int Insert(Recette model)
        {
            Command cmd = new Command("insert into Recette(nom,img,nbPersonne,id_categorie,cuisson,preparation,repos)  OUTPUT Inserted.ID  values(@nom,@img,@nbPersonne,@id_categorie,@cuisson,@preparation,@repos)");
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            cmd.AddParameter("nom", model.Nom);
            cmd.AddParameter("img", model.Img);
            cmd.AddParameter("nbPersonne", model.NbPersonne);
            cmd.AddParameter("id_categorie", model.Id_categorie);
            cmd.AddParameter("cuisson",model.Cuisson);
            cmd.AddParameter("preparation", model.Prepration);
            cmd.AddParameter("repos",model.Repos);
            int id= (int)cnx.ExecuteScalar(cmd);
            return id;

        }

        public bool Update(Recette model)
        {
            Command cmd = new Command("update recette set nom=@nom,img=@img,nbPersonne=@nbPersonne,id_categorie=id_categorie,cuisson=@cuisson,preparation=@preparation,repos=@repos where id=@id ");
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            cmd.AddParameter("nom", model.Nom);
            cmd.AddParameter("img", model.Img);
            cmd.AddParameter("nbPersonne", model.NbPersonne);
            cmd.AddParameter("id_categorie", model.Id_categorie);
            cmd.AddParameter("cuisson", model.Cuisson);
            cmd.AddParameter("preparation", model.Prepration);
            cmd.AddParameter("repos", model.Repos);
            cmd.AddParameter("id", model.Id);
            cnx.ExecuteNonQuery(cmd);
            return true;
        }
    }
}
