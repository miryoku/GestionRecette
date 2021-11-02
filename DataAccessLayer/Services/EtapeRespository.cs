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
    public class EtapeRespository : IEtapeRespository
    {
        private string _connectionString;

        public EtapeRespository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("default");
        }

        public bool Delete(int Id)
        {
            Command cmd = new Command("Delete from Etape where Id = @id");
            cmd.AddParameter("id", Id);
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            return cnx.ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<Etapes> GetAll()
        {
            Command cmd = new Command("select * from Etape");
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            return cnx.ExecuteReader<Etapes>(cmd, Mappers.EtapeConverter);
        }

        public Etapes GetById(int Id)
        {
            Command cmd = new Command("select * from Etape where Id=@id");
            cmd.AddParameter("id", Id);
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            return cnx.ExecuteReader<Etapes>(cmd, Mappers.EtapeConverter).FirstOrDefault();

        }

        public int Insert(Etapes model)
        {
            Command cmd = new Command("insert into Etape(etape,instruction) OUTPUT Inserted.ID values(@etape,@instruction)");
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            cmd.AddParameter("etape", model.Etape);
            cmd.AddParameter("instruction", model.Instruction);
            model.Id = (int)cnx.ExecuteScalar(cmd);
            return model.Id;
        }

        public void InsertLienTAble(int idEtape, int idRecette)
        {
            Command cmd = new Command("insert into TEtape(id_etape,id_recette) values(@idEtape,@idRecette)");
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            cmd.AddParameter("idEtape", idEtape);
            cmd.AddParameter("idRecette", idRecette);
            cnx.ExecuteNonQuery(cmd);
        }

        public bool Update(Etapes model)
        {
            Command cmd = new Command("update etape set etape=@etape,instruction=@instruction where id=@id ");
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            cmd.AddParameter("etape", model.Etape);
            cmd.AddParameter("instruction", model.Instruction);
            cmd.AddParameter("id", model.Id);
            cnx.ExecuteNonQuery(cmd);
            return true;
        }

        public IEnumerable<Intermediaire> GetByIdTEtape(int id)
        {
            Command cmd = new Command("select id,id_recette idRecette,id_etape idBis from tetape where id_recette=@id");
            Connection cnx = new Connection(SqlClientFactory.Instance,_connectionString);
            cmd.AddParameter("id", id);
            return   cnx.ExecuteReader<Intermediaire>(cmd, Mappers.Intermediaire3Converter);
        }

        
    }
}
