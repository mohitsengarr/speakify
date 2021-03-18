
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
        public bool? VideoTweets { get; set; }
        public bool? DisplayBestTweetsFirst { get; set; }
        public bool? DisplayNotifications { get; set; }
        public bool? IsVerified { get; set; }
        public int? FollowersCount { get; set; }
        public int? FriendsCount { get; set; }
        public int? FollowRequestsSent { get; set; }
      
    }
}
