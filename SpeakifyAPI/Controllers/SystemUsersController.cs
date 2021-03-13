﻿using Microsoft.AspNetCore.Mvc;
using SpeakifyAPI.Model;
using SpeakifyAPI.Services;
using SpeakifyAPI.Utility;
using System;


namespace SpeakifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemUsersController : ControllerBase
    {
        public SystemUsersController(ISystemUserService Service)
        {
            SystemUserService = Service;
        }
        public ISystemUserService SystemUserService { get; set; }

        // GET: api/SystemUsers
        [HttpGet]
        public IActionResult Get()
        {
            var result = SystemUserService.ListSystemUsers();
            return Ok(new { data = result });
            
        }

        // GET api/SystemUsers/{guid}
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var result = SystemUserService.SystemUserByID(new Guid(id));
                return Ok(new { data = result, status = StatusMessages.Success });
            }
            catch
            {
            }

            return Ok(new { data = string.Empty, status = StatusMessages.Error_UserNotFound });
        }

        // POST api/SystemUsers
        [HttpPost]
        public IActionResult Post([FromBody] SystemUserModel model)
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
                        int update = SystemUserService.UpdateSystemUsers(model);
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
                    int create = SystemUserService.CreateSystemUsers(model);
                    return Ok(new { data = string.Empty, status = StatusMessages.Get(create) });
                }
            }
            catch
            {
            }

            return Ok(new { data = string.Empty, status = StatusMessages.Error_Failed });
        }

        // POST api/SystemUserRemove/{guid}
        [HttpPost("SystemUserRemove")]
        public IActionResult SystemUserRemove(string id)
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
                        int delete = SystemUserService.DeleteSystemUsers(userid);
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
