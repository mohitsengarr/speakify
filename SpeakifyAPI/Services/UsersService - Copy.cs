using SpeakifyAPI.DataModel;
using SpeakifyAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeakifyAPI.Services
{
    public interface IUsersService
    {

    }
    public class UsersService : IUsersService
    {
        public UsersService(socmed8_devContext dbcontext)
        {
            db = dbcontext;
        }
        public socmed8_devContext db { get; set; }

        public List<User> ListUsers()
        {
            return db.Users.ToList();
        }
        public User UserByID(Guid id)
        {
            return db.Users.FirstOrDefault(d => d.Id == id);
        }
        /// <summary>
        /// 1= Success, 0= Failed
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int CreateUsers(UserModel model)
        {
            try
            {
                db.Users.Add(new User
                {
                    Id = Guid.NewGuid(),
                    Birthday = model.Birthday,
                    Country = model.Country,
                    CoverImage = model.CoverImage,
                    CreatedAt = DateTime.Now,
                    DescriptionBio = model.DescriptionBio,
                    DisplayBestTweetsFirst = model.DisplayBestTweetsFirst,
                    DisplayNotifications = model.DisplayNotifications,
                    FollowersCount = model.FollowersCount,
                    FollowRequestsSent = model.FollowRequestsSent,
                    FriendsCount = model.FriendsCount,
                    IsVerified = model.IsVerified,
                    Link = model.Link,
                    Location = model.Location,
                    Name = model.Name,
                    ProfileImage = model.ProfileImage,
                    ScreenName = model.ScreenName,
                    ThemeColor = model.ThemeColor,
                    VideoTweets = model.VideoTweets,
                    Website = model.Website
                });
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 1= Success, 0= Failed, 2= Username Exists, 3= Email Exists, 4= User not Found
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateUsers(UserModel model)
        {
            try
            {                 
                User userdetails = db.Users.FirstOrDefault(d => d.Id == model.Id);
                if (userdetails != null)
                {
                    userdetails.Birthday = model.Birthday;
                    userdetails.Country = model.Country;
                    userdetails.CoverImage = model.CoverImage;
                    userdetails.UpdatedAt = DateTime.Now;
                    userdetails.DescriptionBio = model.DescriptionBio;
                    userdetails.DisplayBestTweetsFirst = model.DisplayBestTweetsFirst;
                    userdetails.DisplayNotifications = model.DisplayNotifications;
                    userdetails.FollowersCount = model.FollowersCount;
                    userdetails.FollowRequestsSent = model.FollowRequestsSent;
                    userdetails.FriendsCount = model.FriendsCount;
                    userdetails.IsVerified = model.IsVerified;
                    userdetails.Link = model.Link;
                    userdetails.Location = model.Location;
                    userdetails.Name = model.Name;
                    userdetails.ProfileImage = model.ProfileImage;
                    userdetails.ScreenName = model.ScreenName;
                    userdetails.ThemeColor = model.ThemeColor;
                    userdetails.VideoTweets = model.VideoTweets;
                    userdetails.Website = model.Website;
                    db.SaveChanges();

                    return 1;
                }
                else
                    return 4;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 1= Success, 0= Failed, 2= User not Found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteSystemUsers(Guid id)
        {
            try
            {
                SystemUser userdetails = db.SystemUsers.FirstOrDefault(d => d.Id == id);
                if (userdetails != null)
                {
                    ///TODO : Check all references of user in other tables before deletion
                    ///TODO : Can user be deleted in the system?
                    db.SystemUsers.Remove(userdetails);
                    db.SaveChanges();
                    return 1;
                }
                else
                    return 2;
            }
            catch
            {
            }
            return 0;
        }
    }
}
