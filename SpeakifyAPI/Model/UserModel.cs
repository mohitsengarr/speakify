using System;

namespace SpeakifyAPI.Model
{
    public class UserModel
    {
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
        public ulong? VideoTweets { get; set; }
        public ulong? DisplayBestTweetsFirst { get; set; }
        public ulong? DisplayNotifications { get; set; }
        public ulong? IsVerified { get; set; }
        public int? FollowersCount { get; set; }
        public int? FriendsCount { get; set; }
        public int? FollowRequestsSent { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
