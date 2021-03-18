
namespace SpeakifyAPI.Model
{
    public class UserSettingsModel
    {
        public string Id { get; set; }
        public bool PrivacyTweetPrivacy { get; set; }
        public bool PrivacyTweetLocation { get; set; }
        public bool PrivacyPhotoTagging { get; set; }
        public bool EmailNotification { get; set; }
        public bool EmailNewNotification { get; set; }
        public bool NotificationMuteYouDontFollow { get; set; }
        public bool NotificationMuteWhoDontFollow { get; set; }
        public bool NotificationMuteNewAccount { get; set; }
       
    }
}
