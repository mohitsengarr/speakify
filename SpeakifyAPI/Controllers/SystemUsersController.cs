using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweeterSMAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TweeterSMAPI.Controllers
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

        // GET: api/<SystemUsersController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = SystemUserService.ListSystemUsers();
            return Ok(new { data = result });
            //return new string[] { "value1", "value2" };
        }

        // GET api/<SystemUsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SystemUsersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SystemUsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SystemUsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
