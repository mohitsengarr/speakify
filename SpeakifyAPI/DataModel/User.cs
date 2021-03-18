using System;
using System.Collections.Generic;

namespace SpeakifyAPI.DataModel
{
    public partial class User
    {
        public User()
        {
            FollowerFolloweds = new HashSet<Follower>();
            FollowerFollowerNavigations = new HashSet<Follower>();
            Tweets = new HashSet<Tweet>();
            UserContacts = new HashSet<UserContact>();
            UserInterests = new HashSet<UserInterest>();
            UserMentions = new HashSet<UserMention>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string ScreenName { get; set; }
        public string Link { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public string DescriptionBio { get; set; }
        public string Website { get; set; }
        public string Birthday { get; set; }
        public string CoverImage { get; set; }
        public string ProfileImage { get; set; }
        public string ThemeColor { get; set; }
        public bool? VideoTweets { get; set; }
        public bool? DisplayBestTweetsFirst { get; set; }
        public bool? DisplayNotifications { get; set; }
        public bool? IsVerified { get; set; }
        public int? FollowersCount { get; set; }
        public int? FriendsCount { get; set; }
        public int? FollowRequestsSent { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsArchived { get; set; }

        public virtual SystemUser IdNavigation { get; set; }
        public virtual ICollection<Follower> FollowerFolloweds { get; set; }
        public virtual ICollection<Follower> FollowerFollowerNavigations { get; set; }
        public virtual ICollection<Tweet> Tweets { get; set; }
        public virtual ICollection<UserContact> UserContacts { get; set; }
        public virtual ICollection<UserInterest> UserInterests { get; set; }
        public virtual ICollection<UserMention> UserMentions { get; set; }
    }
}
