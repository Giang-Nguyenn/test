using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIDemo.Models
{
    public class User
    {
        public User()
        {
            RefreshTokens = new HashSet<RefreshToken>();
        }


        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public short RoleId { get; set; }
        public virtual Role Role { get; set; }

        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}
