using System;

namespace SpeakifyAPI.DataModel
{
    public partial class SystemUser
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
        public DateTime? UpdatedAt { get; set; }
        public bool IsArchived { get; set; }

        public virtual User User { get; set; }
        public virtual UserSetting UserSetting { get; set; }
    }
}
