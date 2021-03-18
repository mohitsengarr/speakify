
namespace SpeakifyAPI.DataModel
{
    public partial class UserMention
    {
        public string Id { get; set; }
        public string TweetId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public bool IsArchived { get; set; }

        public virtual Tweet Tweet { get; set; }
        public virtual User User { get; set; }
    }
}
