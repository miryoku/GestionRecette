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
    public class UsersService : IUsersService
    {
        private IUsersRespository _usersService;

        public UsersService(IUsersRespository userRepo)
        {
            _usersService = userRepo;
        }

        public bool Delete(int id)
        {
            return _usersService.Delete(id);
        }

        public IEnumerable<Users> GetAll()
        {
            return _usersService.GetAll().Select(x => x.ToBLL());
        }

        public Users GetById(int id)
        {
            Users currentUsers= _usersService.GetById(id).ToBLL();
            return currentUsers;
        }

        public int Insert(Users user)
        {
            return _usersService.Insert(user.ToDAL());
        }

        public Users Login(Users u)
        {
            return _usersService.Login(u.ToDAL()).ToBLL();
        }

        public bool Update(Users user)
        {
            return _usersService.Update(user.ToDAL());
        }
    }
}
