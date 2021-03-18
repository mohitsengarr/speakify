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
        User UserByID(string id);
        APIReturnModel SaveUsers(UserModel model);
        APIReturnModel DeleteUser(string id);
    }
    public class UsersService : IUsersService
    {
        public UsersService(SpeakifyDbContext dbcontext)
        {
            Db = dbcontext;
        }
        private SpeakifyDbContext Db { get; set; }
       
        public List<User> ListUsers()
        {
            return Db.Users.Where(d => d.IsArchived == false).ToList();
        }
        public User UserByID(string id)
        {
            return Db.Users.FirstOrDefault(d => d.Id == id);
        }
        /// <summary>
        /// 1= Success, 0= Failed, 4= Not Found
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public APIReturnModel SaveUsers(UserModel model)
        {
            try
            {
                User userdetails = new User();
                bool isupdate = false;
                //Check user id is provided
                if (!string.IsNullOrEmpty(model.Id))
                {
                    //Check user id exists in db
                    SystemUser chkexisting = Db.SystemUsers.FirstOrDefault(d => d.Id == model.Id && !d.IsArchived);
                    if (chkexisting != null)
                    {
                        userdetails = Db.Users.FirstOrDefault(d => d.Id == model.Id);

                        if (userdetails == null)
                        {
                            userdetails = new User
                            {
                                CreatedAt = DateTime.Now,
                                Id = model.Id
                            };
                        }
                        else
                        {
                            isupdate = true;
                            userdetails.UpdatedAt = DateTime.Now;
                        }
                        userdetails.IsArchived = false;
                        userdetails.VideoTweets = model.VideoTweets;
                        userdetails.DisplayBestTweetsFirst = model.DisplayBestTweetsFirst;
                        userdetails.DisplayNotifications = model.DisplayNotifications;
                        userdetails.IsVerified = model.IsVerified;
                        userdetails.Birthday = model.Birthday;
                        userdetails.Country = model.Country;
                        userdetails.CoverImage = model.CoverImage;
                        userdetails.DescriptionBio = model.DescriptionBio;
                        userdetails.FollowersCount = model.FollowersCount;
                        userdetails.FollowRequestsSent = model.FollowRequestsSent;
                        userdetails.FriendsCount = model.FriendsCount;
                        userdetails.Link = model.Link;
                        userdetails.Location = model.Location;
                        userdetails.Name = model.Name;
                        userdetails.ProfileImage = model.ProfileImage;
                        userdetails.ScreenName = model.ScreenName;
                        userdetails.ThemeColor = model.ThemeColor;
                        userdetails.Website = model.Website;

                        if (!isupdate)
                            Db.Users.Add(userdetails);
                        Db.SaveChanges();
                        return new APIReturnModel { Status = 1, Value = model.Id };
                    }
                    else
                        return new APIReturnModel { Status = 4 };
                }
                else
                    return new APIReturnModel { Status = 4 };
                
            }
            catch (Exception ex)
            {
                return new APIReturnModel { Status = 0 };
            }
        }

        /// <summary>
        /// 1= Success, 0= Failed, 4= User not Found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public APIReturnModel DeleteUser(string id)
        {
            try
            {
                User userdetails = Db.Users.FirstOrDefault(d => d.Id == id);
                if (userdetails != null)
                {
                    ///TODO : Check all references of user in other tables before deletion

                    userdetails.IsArchived = true;
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
