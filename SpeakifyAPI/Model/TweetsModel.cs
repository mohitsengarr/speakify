
namespace SpeakifyAPI.Model
{
    public class TweetsModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
        public string RetweetedFrom { get; set; }
        public string InReplyToStatus { get; set; }
        public string InReplyToUser { get; set; }
        public string PlaceCountry { get; set; }
        public int? ReplyCount { get; set; }
        public int? FavoriteCount { get; set; }
       
    }
}
