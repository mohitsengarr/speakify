using System;


#nullable disable

namespace SpeakifyAPI.DataModel
{
    public partial class UserTweetsFavorite
    {
        public Guid Id { get; set; }
        public Guid TweetsId { get; set; }
        public Guid UserId { get; set; }
    }
}
