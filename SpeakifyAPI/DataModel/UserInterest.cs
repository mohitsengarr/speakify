using System;


#nullable disable

namespace SpeakifyAPI.DataModel
{
    public partial class UserInterest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid InterestSubcategoryId { get; set; }
        public Guid InterestCategoryId { get; set; }

        public virtual InterestCategory InterestCategory { get; set; }
        public virtual InterestSubcategory InterestSubcategory { get; set; }
        public virtual User User { get; set; }
    }
}
