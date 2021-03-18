using SpeakifyAPI.DataModel;
using SpeakifyAPI.Model;
using System.Collections.Generic;
using System.Linq;

namespace SpeakifyAPI.Services
{
    public interface IUserSettingsService
    {
        List<UserSetting> ListUserSettings();
        UserSetting UserSettingsByID(string id);
        APIReturnModel SaveUserSettings(UserSettingsModel model);
        APIReturnModel DeleteUserSettings(string id);
    }
    public class UserSettingsService: IUserSettingsService
    {
        public UserSettingsService(SpeakifyDbContext dbcontext)
        {
            Db = dbcontext;          
        }
        private SpeakifyDbContext Db { get; set; }      

        public List<UserSetting> ListUserSettings()
        {
            return Db.UserSettings.Where(d => d.IsArchived == false).ToList();
        }
        public UserSetting UserSettingsByID(string id)
        {
            return Db.UserSettings.FirstOrDefault(d => d.Id == id);
        }
        /// <summary>
        /// 1= Success, 0= Failed, 4= User not Found
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public APIReturnModel SaveUserSettings(UserSettingsModel model)
        {
            try
            {
                UserSetting usersettings = new UserSetting();
                bool isupdate = false;
                //Check user id is provided
                if (!string.IsNullOrEmpty(model.Id))
                {
                    //Check user id exists in db
                    SystemUser chkexisting = Db.SystemUsers.FirstOrDefault(d => d.Id == model.Id && !d.IsArchived);
                    if (chkexisting != null)
                    {
                        usersettings = Db.UserSettings.FirstOrDefault(d => d.Id == model.Id);

                        if (usersettings == null)
                        {
                            usersettings = new UserSetting
                            {
                                Id = model.Id
                            };
                        }
                        else
                        {
                            isupdate = true;                           
                        }
                       
                        usersettings.EmailNewNotification = model.EmailNewNotification;
                        usersettings.EmailNotification = model.EmailNotification;
                        usersettings.NotificationMuteNewAccount = model.NotificationMuteNewAccount;
                        usersettings.NotificationMuteWhoDontFollow = model.NotificationMuteWhoDontFollow;
                        usersettings.NotificationMuteYouDontFollow = model.NotificationMuteYouDontFollow;
                        usersettings.PrivacyPhotoTagging = model.PrivacyPhotoTagging;
                        usersettings.PrivacyTweetLocation = model.PrivacyTweetLocation;
                        usersettings.PrivacyTweetPrivacy = model.PrivacyTweetPrivacy;

                        usersettings.IsArchived = false;

                        if (!isupdate)
                            Db.UserSettings.Add(usersettings);
                        Db.SaveChanges();

                        return new APIReturnModel { Status = 1 ,Value=usersettings.Id};
                    }
                    else
                        return new APIReturnModel { Status = 4 };
                }
                else
                    return new APIReturnModel { Status = 4 };
               
            }
            catch
            {
                return new APIReturnModel { Status = 0 };
            }
        }

        /// <summary>
        /// 1= Success, 0= Failed, 4= User not Found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public APIReturnModel DeleteUserSettings(string id)
        {
            try
            {
                UserSetting usersettings = Db.UserSettings.FirstOrDefault(d => d.Id == id);
                if (usersettings != null)
                {
                    usersettings.IsArchived = true;
                    Db.SaveChanges();
                    return new APIReturnModel { Status = 1 };
                }
                else
                    return new APIReturnModel { Status = 4 };
            }
            catch
            {
            }
            return new APIReturnModel { Status = 0 };
        }
    }
}
