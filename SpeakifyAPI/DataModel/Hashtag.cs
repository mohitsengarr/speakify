using System;
using System.Collections.Generic;

#nullable disable

namespace TweeterSMAPI.DataModel
{
    public partial class Hashtag
    {
        public Hashtag()
        {
            TweetsHashtags = new HashSet<TweetsHashtag>();
        }

        public long Id { get; set; }
        public string Hashtag1 { get; set; }

        public virtual ICollection<TweetsHashtag> TweetsHashtags { get; set; }
    }
}
