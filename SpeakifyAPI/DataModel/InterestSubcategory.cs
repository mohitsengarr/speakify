using System;
using System.Collections.Generic;

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
        public bool IsActive { get; set; }

        public virtual InterestCategory Category { get; set; }
        public virtual ICollection<UserInterest> UserInterests { get; set; }
    }
}
