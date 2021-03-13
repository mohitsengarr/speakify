using System;
using System.Collections.Generic;

#nullable disable

namespace TweeterSMAPI.DataModel
{
    public partial class Tweet
    {
        public Tweet()
        {
            TweetsHashtags = new HashSet<TweetsHashtag>();
            TweetsMedia = new HashSet<TweetsMedium>();
            UserMentions = new HashSet<UserMention>();
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Text { get; set; }
        public Guid? RetweetedFrom { get; set; }
        public Guid? InReplyToStatus { get; set; }
        public Guid? InReplyToUser { get; set; }
        public string PlaceCountry { get; set; }
        public int? ReplyCount { get; set; }
        public int? FavoriteCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<TweetsHashtag> TweetsHashtags { get; set; }
        public virtual ICollection<TweetsMedium> TweetsMedia { get; set; }
        public virtual ICollection<UserMention> UserMentions { get; set; }
    }
}
