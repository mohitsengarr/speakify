using System.Collections.Generic;


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
        public bool IsArchived { get; set; }

        public virtual ICollection<TweetsHashtag> TweetsHashtags { get; set; }
    }
}
