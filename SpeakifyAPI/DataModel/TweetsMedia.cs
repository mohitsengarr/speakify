
namespace SpeakifyAPI.DataModel
{
    public partial class TweetsMedia
    {
        public long Id { get; set; }
        public string TweetsId { get; set; }
        public string Media { get; set; }
        public string MediaUrl { get; set; }
        public string MediaUrlHttps { get; set; }
        public string Type { get; set; }
        public bool? IsArchived { get; set; }

        public virtual Tweet Tweets { get; set; }
    }
}
