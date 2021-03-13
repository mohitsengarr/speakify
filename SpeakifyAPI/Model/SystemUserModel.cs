using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TweeterSMAPI.Model
{
    public class SystemUserModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }       
    }
}
