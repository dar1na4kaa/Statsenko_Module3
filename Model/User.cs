using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statsenko_Module3.Model
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public UserStatus Status { get; set; }
        public DateTime? LastDateLogin { get; set; }
        public UserRole Role { get; set; }
    }
}
