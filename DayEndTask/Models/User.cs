using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayEndTask.Models
{
    public class User
    {
        private static int _id ;
        public User()
        {
            _id += 1;
        }
        public int Id
        {
            get { return _id; }
          
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username  { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
