
using System.Collections.Generic;

#nullable disable

namespace SpeakifyAPI.DataModel
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
