using System;
using System.Collections.Generic;

#nullable disable

namespace TweeterSMAPI.DataModel
{
    public partial class UserTweetsFavorite
    {
        public Guid Id { get; set; }
        public Guid TweetsId { get; set; }
        public Guid UserId { get; set; }
    }
}
