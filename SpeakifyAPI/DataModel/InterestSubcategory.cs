using System;
using System.Collections.Generic;

#nullable disable

namespace SpeakifyAPI.DataModel
{
    public partial class InterestSubcategory
    {
        public InterestSubcategory()
        {
            UserInterests = new HashSet<UserInterest>();
        }

        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ulong IsActive { get; set; }

        public virtual InterestCategory Category { get; set; }
        public virtual ICollection<UserInterest> UserInterests { get; set; }
    }
}
