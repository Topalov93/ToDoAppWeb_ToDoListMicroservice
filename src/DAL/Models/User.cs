using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User
    {
        public User()
        {

        }
        public string Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }
    }
}
