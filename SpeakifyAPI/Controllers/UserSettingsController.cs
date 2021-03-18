using Microsoft.AspNetCore.Mvc;
using SpeakifyAPI.Model;
using SpeakifyAPI.Services;
using SpeakifyAPI.Utility;
using System;

namespace SpeakifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSettingsController : ControllerBase
    {
        public UserSettingsController(IUserSettingsService Service)
        {
            UserSettingsService = Service;
        }
        private IUserSettingsService UserSettingsService { get; set; }

        // GET: api/UserSettings
        [HttpGet]
        public IActionResult Get()
        {
            var result = UserSettingsService.ListUserSettings();
            return Ok(new { data = result });
        }

        // GET api/UserSettings/{guid}
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var result = UserSettingsService.UserSettingsByID(id);
                return Ok(new { data = result, status = StatusMessages.Success });
            }
            catch
            {
            }

            return Ok(new { data = string.Empty, status = StatusMessages.Error_UserNotFound });
        }

        // POST api/UserSettings
        [HttpPost]
        public IActionResult Post([FromBody] UserSettingsModel model)
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
                        APIReturnModel update = UserSettingsService.SaveUserSettings(model);
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
                    APIReturnModel create = UserSettingsService.SaveUserSettings(model);
                    return Ok(new { data = create.Value, status = StatusMessages.Get(create.Status) });
                }
            }
            catch
            {
            }

            return Ok(new { data = string.Empty, status = StatusMessages.Error_Failed });
        }

        // POST api/UserSettings/UserRemove/{guid}
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
                        APIReturnModel delete = UserSettingsService.DeleteUserSettings(id);
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
