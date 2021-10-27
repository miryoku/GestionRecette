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
    public class UnitesRespository : IUniteRespository
    {
        private string _connectionString;

        public UnitesRespository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("default");
        }
        public bool Delete(int Id)
        {
            Command cmd = new Command("Delete from unite where Id = @id");
            cmd.AddParameter("id", Id);
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            return cnx.ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<Unites> GetAll()
        {
            Command cmd = new Command("select * from Unite");
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            return cnx.ExecuteReader<Unites>(cmd, Mappers.UniteConverter);
        }

        public Unites GetById(int Id)
        {
            Command cmd = new Command("select * from Unite where Id=@id");
            cmd.AddParameter("id", Id);
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            return cnx.ExecuteReader<Unites>(cmd, Mappers.UniteConverter).FirstOrDefault();
        }

        public int Insert(Unites model)
        {
            Command cmd = new Command("insert into unite(unite)values(@unite)");
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            cmd.AddParameter("unite", model.Unite);
            return cnx.ExecuteNonQuery(cmd);
        }

        public bool Update(Unites model)
        {
            Command cmd = new Command("update unite set unite=@unite where id=@id ");
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            cmd.AddParameter("unite", model.Unite);
            cmd.AddParameter("id", model.Id);
            cnx.ExecuteNonQuery(cmd);
            return true;
        }
    }
}
