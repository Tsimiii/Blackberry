using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackberryApi.Models.UsersModel
{
    public class UsersRepository : IUsersRepository
    {

        private static ConcurrentDictionary<int, Users> _todos = new ConcurrentDictionary<int, Users>();

        public void Add(Users user)
        {
            _todos[user.ID] = user;
        }

        public Users Find(int ID)
        {
            Users user;
            _todos.TryGetValue(ID, out user);
            return user;
        }

        public IEnumerable<Users> GetAll()
        {
            return _todos.Values;
        }

        public Users Remove(int ID)
        {
            Users user;
            _todos.TryRemove(ID, out user);
            return user;
        }

        public void Update(Users user)
        {
            _todos[user.ID] = user;
        }
    }
}
