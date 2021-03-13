using System;


#nullable disable

namespace SpeakifyAPI.DataModel
{
    public partial class TweetsHashtag
    {
        public long Id { get; set; }
        public Guid TweetsId { get; set; }
        public long HashtagId { get; set; }

        public virtual Hashtag Hashtag { get; set; }
        public virtual Tweet Tweets { get; set; }
    }
}
