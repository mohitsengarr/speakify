using System;
using System.Collections.Generic;

namespace SpeakifyAPI.DataModel
{
    public partial class Tweet
    {
        public Tweet()
        {
            TweetsHashtags = new HashSet<TweetsHashtag>();
            TweetsMedia = new HashSet<TweetsMedia>();
            UserMentions = new HashSet<UserMention>();
        }

        public string Id { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
        public string RetweetedFrom { get; set; }
        public string InReplyToStatus { get; set; }
        public string InReplyToUser { get; set; }
        public string PlaceCountry { get; set; }
        public int? ReplyCount { get; set; }
        public int? FavoriteCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsArchived { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<TweetsHashtag> TweetsHashtags { get; set; }
        public virtual ICollection<TweetsMedia> TweetsMedia { get; set; }
        public virtual ICollection<UserMention> UserMentions { get; set; }
    }
}
