
namespace SpeakifyAPI.DataModel
{
    public partial class TweetsHashtag
    {
        public long Id { get; set; }
        public string TweetsId { get; set; }
        public long HashtagId { get; set; }
        public bool IsArchived { get; set; }

        public virtual Hashtag Hashtag { get; set; }
        public virtual Tweet Tweets { get; set; }
    }
}
