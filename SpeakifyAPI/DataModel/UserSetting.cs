using System;


#nullable disable

namespace SpeakifyAPI.DataModel
{
    public partial class UserSetting
    {
        public Guid Id { get; set; }
        public ulong PrivacyTweetPrivacy { get; set; }
        public ulong PrivacyTweetLocation { get; set; }
        public string PrivacyPhotoTagging { get; set; }
        public ulong EmailNotification { get; set; }
        public ulong EmailNewNotification { get; set; }
        public ulong NotificationMuteYouDontFollow { get; set; }
        public ulong NotificationMuteWhoDontFollow { get; set; }
        public ulong NotificationMuteNewAccount { get; set; }

        public virtual SystemUser IdNavigation { get; set; }
    }
}
