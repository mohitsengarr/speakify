using SpeakifyAPI.DataModel;
using SpeakifyAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeakifyAPI.Services
{
    public interface IUsersService
    {
        List<User> ListUsers();
        User UserByID(Guid id);
        int SaveUsers(UserModel model);
        int DeleteUser(Guid id);
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
        public int SaveUsers(UserModel model)
        {
            try
            {
                User userdetails = new User();
                if (!string.IsNullOrEmpty(model.Id))
                {
                    Guid userid = new Guid(model.Id);
                    userdetails = db.Users.FirstOrDefault(d => d.Id == userid);
                    userdetails.UpdatedAt = DateTime.Now;
                }
                else
                {
                    userdetails.Id = Guid.NewGuid();
                    userdetails.CreatedAt = DateTime.Now;
                }
                userdetails.Birthday = model.Birthday;
                userdetails.Country = model.Country;
                userdetails.CoverImage = model.CoverImage;

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

                if (!string.IsNullOrEmpty(model.Id))
                {
                    db.Users.Add(userdetails);
                }
                db.SaveChanges();
                return 1;
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
        public int DeleteUser(Guid id)
        {
            try
            {
                User userdetails = db.Users.FirstOrDefault(d => d.Id == id);
                if (userdetails != null)
                {
                    ///TODO : Check all references of user in other tables before deletion
                    ///TODO : Can user be deleted in the system?
                    db.Users.Remove(userdetails);
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
