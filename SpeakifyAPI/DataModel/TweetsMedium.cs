using System;

#nullable disable

namespace SpeakifyAPI.DataModel
{
    public partial class TweetsMedium
    {
        public long Id { get; set; }
        public Guid TweetsId { get; set; }
        public string Media { get; set; }
        public string MediaUrl { get; set; }
        public string MediaUrlHttps { get; set; }
        public string Type { get; set; }

        public virtual Tweet Tweets { get; set; }
    }
}
