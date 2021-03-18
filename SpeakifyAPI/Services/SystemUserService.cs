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
        SystemUser SystemUserByID(string id);
        APIReturnModel CreateSystemUsers(SystemUserModel model);
        APIReturnModel UpdateSystemUsers(SystemUserModel model);
        APIReturnModel DeleteSystemUsers(string id);
        bool IsUserNameExists(string username);
        bool IsEmailExists(string email);
    }
    public class SystemUserService : ISystemUserService
    {
        public SystemUserService(SpeakifyDbContext dbcontext)
        {
            Db = dbcontext;           
        }
        private SpeakifyDbContext Db { get; set; }      

        public List<SystemUser> ListSystemUsers()
        {
            return Db.SystemUsers.Where(d=>d.IsArchived==false).ToList();
        }
        public SystemUser SystemUserByID(string id)
        {
            return Db.SystemUsers.FirstOrDefault(d=>d.Id==id);
        }
        /// <summary>
        /// 1= Success, 0= Failed, 2= Username Exists, 3= Email Exists
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public APIReturnModel CreateSystemUsers(SystemUserModel model)
        {
            try
            {
                if (IsUserNameExists(model.Username))
                {
                    return new APIReturnModel { Status = 2};
                }
                if (IsEmailExists(model.Email))
                {
                    return new APIReturnModel { Status = 3 };
                }
                SystemUser user = new SystemUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Address = model.Address,
                    CreatedAt = DateTime.Now,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Phone = model.Phone,
                    Username = model.Username,
                    PasswordHash = model.PasswordHash,
                    IsArchived =false
                };
                Db.SystemUsers.Add(user);
                Db.SaveChanges();
                return new APIReturnModel { Status = 1, Value= user.Id.ToString() };
            }
            catch (Exception)
            {
                return new APIReturnModel { Status = 0 };
            }
        }
        /// <summary>
        /// 1= Success, 0= Failed, 2= Username Exists, 3= Email Exists, 4= User not Found
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public APIReturnModel UpdateSystemUsers(SystemUserModel model)
        {
            try
            {
                if (IsUserNameExists(model.Username))
                {
                    return new APIReturnModel { Status = 2 };
                }
                if (IsEmailExists(model.Email))
                {
                    return new APIReturnModel { Status = 3 };
                }

                Guid userid = new Guid(model.Id);
                SystemUser userdetails = Db.SystemUsers.FirstOrDefault(d => d.Id == model.Id);                
                if (userdetails != null)
                {
                    userdetails.Address = model.Address;
                    userdetails.Email = model.Email;
                    userdetails.FirstName = model.FirstName;
                    userdetails.LastName = model.LastName;
                    userdetails.Phone = model.Phone;
                    Db.SaveChanges();

                    return new APIReturnModel { Status = 1 ,Value=model.Id};
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
        public APIReturnModel DeleteSystemUsers(string id)
        {
            try
            {
                SystemUser userdetails = Db.SystemUsers.FirstOrDefault(d => d.Id == id);
                if (userdetails != null)
                {
                    ///TODO : Check all references of user in other tables before deletion
                    userdetails.IsArchived =true;
                    Db.SaveChanges();
                    return new APIReturnModel { Status = 1,Value=id.ToString() };
                }
                else
                    return new APIReturnModel { Status = 4 };
            }
            catch
            {
            }
            return new APIReturnModel { Status = 0 };
        }

        public bool IsUserNameExists(string username)
        {
            try
            {
                SystemUser getuser = Db.SystemUsers.FirstOrDefault(d => d.Username == username);
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
                SystemUser getuser = Db.SystemUsers.FirstOrDefault(d => d.Email == email);
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
