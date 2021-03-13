using System;
using System.Collections.Generic;
using System.Linq;
using SpeakifyAPI.DataModel;
using SpeakifyAPI.Model;

namespace SpeakifyAPI.Services
{
    public interface ISystemUserService
    {
        List<SystemUser> ListSystemUsers();
        SystemUser SystemUserByID(Guid id);
        int CreateSystemUsers(SystemUserModel model);
        int UpdateSystemUsers(SystemUserModel model);
        int DeleteSystemUsers(Guid id);
        bool IsUserNameExists(string username);
        bool IsEmailExists(string email);
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
        public SystemUser SystemUserByID(Guid id)
        {
            return db.SystemUsers.FirstOrDefault(d=>d.Id==id);
        }
        /// <summary>
        /// 1= Success, 0= Failed, 2= Username Exists, 3= Email Exists
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int CreateSystemUsers(SystemUserModel model)
        {
            try
            {
                if (IsUserNameExists(model.Username))
                    return 2;
                if (IsEmailExists(model.Email))
                    return 3;
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
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 1= Success, 0= Failed, 2= Username Exists, 3= Email Exists, 4= User not Found
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateSystemUsers(SystemUserModel model)
        {
            try
            {
                if (IsUserNameExists(model.Username))
                    return 2;
                if (IsEmailExists(model.Email))
                    return 3;

                Guid userid = new Guid(model.Id);
                SystemUser userdetails = db.SystemUsers.FirstOrDefault(d => d.Id == userid);
                if (userdetails != null)
                {
                    userdetails.Address = model.Address;
                    userdetails.Email = model.Email;
                    userdetails.FirstName = model.FirstName;
                    userdetails.LastName = model.LastName;
                    userdetails.Phone = model.Phone;
                    db.SaveChanges();

                    return 1;
                }
                else
                    return 4;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 1= Success, 0= Failed, 4= User not Found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteSystemUsers(Guid id)
        {
            try
            {
                SystemUser userdetails = db.SystemUsers.FirstOrDefault(d => d.Id == id);
                if (userdetails != null)
                {
                    ///TODO : Check all references of user in other tables before deletion
                    ///TODO : Can user be deleted in the system?
                    db.SystemUsers.Remove(userdetails);
                    db.SaveChanges();
                    return 1;
                }
                else
                    return 4;
            }
            catch
            {
            }
            return 0;
        }

        public bool IsUserNameExists(string username)
        {
            try
            {
                SystemUser getuser = db.SystemUsers.FirstOrDefault(d => d.Username == username);
                if (getuser != null)
                    return true;
            }
            catch
            {
            }
            return false;
        }
        public bool IsEmailExists(string email)
        {
            try
            {
                SystemUser getuser = db.SystemUsers.FirstOrDefault(d => d.Email == email);
                if (getuser != null)
                    return true;
            }
            catch
            {
            }
            return false;
        }
    }
}
