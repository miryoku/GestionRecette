

using ADOLibrary;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DataAccessLayer.Tools;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccessLayer.Services
{
    public class UsersRepository : IUsersRespository
    {
        private string _connectionString;

        public UsersRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("default");
        }



        public bool Delete(int Id)
        {
            Command cmd = new Command("Delete from Users where Id = @id");
            cmd.AddParameter("id", Id);
            Connection cnx= new Connection(SqlClientFactory.Instance,_connectionString);
            return cnx.ExecuteNonQuery(cmd) == 1;
        }
    
        public IEnumerable<Users> GetAll()
        {
            Command cmd = new Command("select u.Id,u.speudo,u.mdp,r.nom Roles, r.id id_role from Users u, Roles r where u.id_role=r.Id;");
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            return cnx.ExecuteReader<Users>(cmd, Mappers.UsersConverter);
        }

        public Users GetById(int Id)
        {
            Command cmd = new Command("select u.Id,u.speudo,u.mdp,r.nom Roles, r.id id_role from Users u, Roles r where u.id_role=r.Id and u.id=@id ;");
            cmd.AddParameter("id", Id);
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            return cnx.ExecuteReader<Users>(cmd, Mappers.UsersConverter).FirstOrDefault();
        }

        public int Insert(Users model)
        {
            Command cmd = new Command("insert into Users(speudo,mdp,id_role) values(@speudo,HASHBYTES('SHA2_512',@mdp),@id_role)");
            Connection cnx= new Connection(SqlClientFactory.Instance, _connectionString);
            cmd.AddParameter("speudo", model.Speudo);
            cmd.AddParameter("mdp", model.Mdp);
            cmd.AddParameter("id_Role", model.Id_role);
            return cnx.ExecuteNonQuery(cmd);

        }

        public Users Login(Users u)
        {
            Connection c = new Connection(SqlClientFactory.Instance, _connectionString);
            Command cmd = new Command("select u.Id,u.speudo,u.mdp,r.nom Roles, r.id id_role from Users u, Roles r where u.id_role=r.Id and u.speudo=@login and u.mdp = HASHBYTES('SHA2_512',@mdp)");
            cmd.AddParameter("login", u.Speudo);
            cmd.AddParameter("mdp", u.Mdp);
            return c.ExecuteReader<Users>(cmd, Mappers.UsersConverter).FirstOrDefault();

        }

        public bool Update(Users model)
        {
            Command cmd = new Command("update users set mdp=HASHBYTES('SHA2_512',@mdp),id_Role=@id_Role where id=@id ");
            Connection cnx = new Connection(SqlClientFactory.Instance, _connectionString);
            cmd.AddParameter("mdp", model.Mdp);
            cmd.AddParameter("id_Role", model.Id_role);
            cmd.AddParameter("id",model.Id);
            cnx.ExecuteNonQuery(cmd);
            return true;
        }
    }
}
