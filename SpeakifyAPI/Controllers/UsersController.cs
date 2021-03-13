using Microsoft.AspNetCore.Mvc;
using SpeakifyAPI.Model;
using SpeakifyAPI.Services;
using SpeakifyAPI.Utility;
using System;

namespace SpeakifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersController(IUsersService Service)
        {
            UsersService = Service;
        }
        public IUsersService UsersService { get; set; }

        // GET: api/Users
        [HttpGet]
        public IActionResult Get()
        {
            var result = UsersService.ListUsers();
            return Ok(new { data = result });
        }

        // GET api/Users/{guid}
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var result = UsersService.UserByID(new Guid(id));
                return Ok(new { data = result, status = StatusMessages.Success });
            }
            catch
            {
            }

            return Ok(new { data = string.Empty, status = StatusMessages.Error_UserNotFound });
        }

        // POST api/Users
        [HttpPost]
        public IActionResult Post([FromBody] UserModel model)
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
                        int update = UsersService.SaveUsers(model);
                        return Ok(new { data = string.Empty, status = StatusMessages.Get(update) });
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
                    int create = UsersService.SaveUsers(model);
                    return Ok(new { data = string.Empty, status = StatusMessages.Get(create) });
                }
            }
            catch
            {
            }

            return Ok(new { data = string.Empty, status = StatusMessages.Error_Failed });
        }

        // POST api/UserRemove/{guid}
        [HttpPost("UserRemove")]
        public IActionResult UserRemove(string id)
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
                        int delete = UsersService.DeleteUser(userid);
                        return Ok(new { data = string.Empty, status = StatusMessages.Get(delete) });
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
