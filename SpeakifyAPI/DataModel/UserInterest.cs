using System;

namespace SpeakifyAPI.DataModel
{
    public partial class UserInterest
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public Guid InterestSubcategoryId { get; set; }
        public Guid InterestCategoryId { get; set; }
        public bool IsArchived { get; set; }

        public virtual InterestCategory InterestCategory { get; set; }
        public virtual InterestSubcategory InterestSubcategory { get; set; }
        public virtual User User { get; set; }
    }
}
