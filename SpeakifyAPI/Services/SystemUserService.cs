using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweeterSMAPI.DataModel;
using TweeterSMAPI.Model;

namespace TweeterSMAPI.Services
{
    public interface ISystemUserService
    {
        List<SystemUser> ListSystemUsers();
    }
    public class SystemUserService : ISystemUserService
    {
        public SystemUserService(socmed8_devContext dbcontext)
        {
            db = dbcontext;
        }
        public socmed8_devContext db { get; set; }

        public List<SystemUser> ListSystemUsers()
        {
            return db.SystemUsers.ToList();
        }
        public bool CreateSystemUsers(SystemUserModel model)
        {
            try
            {
                db.SystemUsers.Add(new SystemUser
                {
                    Id = Guid.NewGuid(),
                    Address = model.Address,
                    CreatedAt = DateTime.Now,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Phone = model.Phone,
                    Username = model.Username
                });
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
