using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackberryApi.Models.UsersModel
{
    public class Users
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
    }
}
