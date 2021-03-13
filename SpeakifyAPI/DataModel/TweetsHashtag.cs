using System;
using System.Collections.Generic;

#nullable disable

namespace TweeterSMAPI.DataModel
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
