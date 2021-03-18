using Microsoft.AspNetCore.Mvc;
using SpeakifyAPI.Model;
using SpeakifyAPI.Services;
using SpeakifyAPI.Utility;
using System;

namespace SpeakifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetsController : ControllerBase
    {
        public TweetsController(ITweetsServices Service)
        {
            TweetsServices = Service;
        }
        private ITweetsServices TweetsServices { get; set; }

        // GET: api/Tweets
        [HttpGet]
        public IActionResult Get()
        {
            var result = TweetsServices.ListTweets();
            return Ok(new { data = result });
        }

        // GET api/Tweets/{guid}
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var result = TweetsServices.TweetsByID(id);
                return Ok(new { data = result, status = StatusMessages.Success });
            }
            catch
            {
            }

            return Ok(new { data = string.Empty, status = StatusMessages.Error_UserNotFound });
        }

        // POST api/Tweets
        [HttpPost]
        public IActionResult Post([FromBody] TweetsModel model)
        {
            try
            {
                if (!string.IsNullOrEmpty(model.Id))
                {
                    //Check Empty Guid
                    Guid userid = new Guid(model.Id);
                    if (userid != Guid.Empty)
                    {
                        //Update
                        APIReturnModel update = TweetsServices.SaveTweets(model);
                        return Ok(new { data =update.Value, status = StatusMessages.Get(update.Status) });
                    }
                    else
                    {
                        //Passed User ID is empty guid
                        return Ok(new { data = string.Empty, status = StatusMessages.Error_UserUpdateFailed_GUID });
                    }
                }
                else
                {
                    //Insert 
                    APIReturnModel create = TweetsServices.SaveTweets(model);
                    return Ok(new { data = create.Value, status = StatusMessages.Get(create.Status) });
                }
            }
            catch
            {
            }

            return Ok(new { data = string.Empty, status = StatusMessages.Error_Failed });
        }

        // POST api/Tweets/TweetsRemove/{guid}
        [HttpPost("TweetsRemove")]
        public IActionResult TweetsRemove(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    //Check Empty Guid
                    Guid userid = new Guid(id);
                    if (userid != Guid.Empty)
                    {
                        //Delete
                        APIReturnModel delete = TweetsServices.DeleteTweets(id);
                        return Ok(new { data = string.Empty, status = StatusMessages.Get(delete.Status) });
                    }
                    else
                    {
                        //Passed User ID is empty guid
                        return Ok(new { data = string.Empty, status = StatusMessages.Error_UserDeleteFailed_GUID });
                    }
                }
                else
                {
                    //Passed User ID is empty guid
                    return Ok(new { data = string.Empty, status = StatusMessages.Error_UserDeleteFailed_GUID });
                }

            }
            catch
            {
            }
            return Ok(new { data = string.Empty, status = StatusMessages.Error_Failed });
        }
    }
}
