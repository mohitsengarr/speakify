using System;
using System.Collections.Generic;

#nullable disable

namespace TweeterSMAPI.DataModel
{
    public partial class UserContact
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactDescription { get; set; }
    }
}
