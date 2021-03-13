using System;
using System.Collections.Generic;

#nullable disable

namespace TweeterSMAPI.DataModel
{
    public partial class UserMention
    {
        public Guid Id { get; set; }
        public Guid TweetId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }

        public virtual Tweet Tweet { get; set; }
        public virtual User User { get; set; }
    }
}
