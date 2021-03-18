using System;

namespace SpeakifyAPI.DataModel
{
    public partial class Follower
    {
        public Guid Id { get; set; }
        public string FollowedId { get; set; }
        public string FollowerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsArchived { get; set; }

        public virtual User Followed { get; set; }
        public virtual User FollowerNavigation { get; set; }
    }
}
