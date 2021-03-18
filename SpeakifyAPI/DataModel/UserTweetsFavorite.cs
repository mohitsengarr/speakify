
namespace SpeakifyAPI.DataModel
{
    public partial class UserTweetsFavorite
    {
        public string Id { get; set; }
        public string TweetsId { get; set; }
        public string UserId { get; set; }
        public bool IsArchived { get; set; }
    }
}
