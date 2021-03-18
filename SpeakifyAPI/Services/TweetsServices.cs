using SpeakifyAPI.DataModel;
using SpeakifyAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeakifyAPI.Services
{
    public interface ITweetsServices
    {
        List<Tweet> ListTweets();
        Tweet TweetsByID(string id);
        APIReturnModel SaveTweets(TweetsModel model);
        APIReturnModel DeleteTweets(string id);
    }
    public class TweetsServices : ITweetsServices
    {
        public TweetsServices(SpeakifyDbContext dbcontext)
        {
            Db = dbcontext;
        }
        private SpeakifyDbContext Db { get; set; }

        public List<Tweet> ListTweets()
        {
            return Db.Tweets.Where(d => d.IsArchived == false).ToList();
        }
        public Tweet TweetsByID(string id)
        {
            return Db.Tweets.FirstOrDefault(d => d.Id == id);
        }
        /// <summary>
        /// 1= Success, 0= Failed
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public APIReturnModel SaveTweets(TweetsModel model)
        {
            try
            {
                Tweet tweets = new Tweet();
                bool isupdate = false;
                //Check tweet id is provided
                if (!string.IsNullOrEmpty(model.Id))
                {

                    tweets = Db.Tweets.FirstOrDefault(d => d.Id == model.Id);

                    if (tweets == null)
                    {
                        tweets = new Tweet
                        {
                            Id = Guid.NewGuid().ToString(),
                            CreatedAt=DateTime.Now
                        };
                    }
                    else
                    {
                        isupdate = true;
                        tweets.UpdatedAt = DateTime.Now;
                    }
                    tweets.UserId = model.UserId;
                    tweets.Text = model.Text;
                    tweets.PlaceCountry = model.PlaceCountry;
                    tweets.InReplyToStatus = model.InReplyToStatus;
                    tweets.InReplyToUser = model.InReplyToUser;
                    tweets.RetweetedFrom = model.RetweetedFrom;                    
                    tweets.ReplyCount = model.ReplyCount;
                    tweets.FavoriteCount = model.FavoriteCount; 

                    tweets.IsArchived = false;

                    if (!isupdate)
                        Db.Tweets.Add(tweets);
                    Db.SaveChanges();

                    return new APIReturnModel { Status = 1 ,Value=tweets.Id};

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
        public APIReturnModel DeleteTweets(string id)
        {
            try
            {
                Tweet tweets = Db.Tweets.FirstOrDefault(d => d.Id == id);
                if (tweets != null)
                {
                    tweets.IsArchived = true;
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
