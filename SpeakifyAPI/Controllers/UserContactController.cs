using Microsoft.AspNetCore.Mvc;
using SpeakifyAPI.Model;
using SpeakifyAPI.Services;
using SpeakifyAPI.Utility;
using System;

namespace SpeakifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserContactController : ControllerBase
    {
        public UserContactController(IUserContactsService Service)
        {
            UserContactServices = Service;
        }
        private IUserContactsService UserContactServices { get; set; }

        // GET: api/UserContact
        [HttpGet]
        public IActionResult Get()
        {
            var result = UserContactServices.ListUserContacts();
            return Ok(new { data = result });
        }

        // GET api/UserContact/{guid}
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var result = UserContactServices.UserContactByID(id);
                return Ok(new { data = result, status = StatusMessages.Success });
            }
            catch
            {
            }

            return Ok(new { data = string.Empty, status = StatusMessages.Error_UserNotFound });
        }

        // POST api/UserContact
        [HttpPost]
        public IActionResult Post([FromBody] UserContactModel model)
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
                        APIReturnModel update = UserContactServices.SaveUserContacts(model);
                        return Ok(new { data = update.Value, status = StatusMessages.Get(update.Status) });
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
                    APIReturnModel create = UserContactServices.SaveUserContacts(model);
                    return Ok(new { data =create.Value, status = StatusMessages.Get(create.Status) });
                }
            }
            catch
            {
            }

            return Ok(new { data = string.Empty, status = StatusMessages.Error_Failed });
        }

        // POST api/UserContact/UserContactRemove/{guid}
        [HttpPost("UserContactRemove")]
        public IActionResult UserContactRemove(string id)
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
                        APIReturnModel delete = UserContactServices.DeleteUserContacts(id);
                        return Ok(new { data =string.Empty, status = StatusMessages.Get(delete.Status) });
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
