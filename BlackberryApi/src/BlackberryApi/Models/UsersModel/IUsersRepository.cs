using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackberryApi.Models.UsersModel
{
    public interface IUsersRepository
    {
        void Add(Users user);
        IEnumerable<Users> GetAll();
        Users Find(int ID);
        Users Remove(int ID);
        void Update(Users users);
    }
}
