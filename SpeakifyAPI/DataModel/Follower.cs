using System;
using System.Collections.Generic;

#nullable disable

namespace TweeterSMAPI.DataModel
{
    public partial class Follower
    {
        public Guid Id { get; set; }
        public Guid FollowedId { get; set; }
        public Guid FollowerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual User Followed { get; set; }
        public virtual User FollowerNavigation { get; set; }
    }
}
