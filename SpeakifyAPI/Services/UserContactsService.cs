using SpeakifyAPI.DataModel;
using SpeakifyAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeakifyAPI.Services
{
    public interface IUserContactsService
    {
        List<UserContact> ListUserContacts();
        UserContact UserContactByID(string id);
        APIReturnModel SaveUserContacts(UserContactModel model);
        APIReturnModel DeleteUserContacts(string id);
    }
    public class UserContactsService: IUserContactsService
    {
        public UserContactsService(SpeakifyDbContext dbcontext)
        {
            Db = dbcontext;
        }
        private SpeakifyDbContext Db { get; set; }

        public List<UserContact> ListUserContacts()
        {
            return Db.UserContacts.Where(d => d.IsArchived == false).ToList();
        }
        public UserContact UserContactByID(string id)
        {
            return Db.UserContacts.FirstOrDefault(d => d.Id == id);
        }
        /// <summary>
        /// 1= Success, 0= Failed, 4= User Not Found
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public APIReturnModel SaveUserContacts(UserContactModel model)
        {
            try
            {
                UserContact contacts = new UserContact();
                bool isupdate = false;
                //Check user id is provided
                if (!string.IsNullOrEmpty(model.UserId))
                {
                    //Check user id exists in db
                    SystemUser chkexisting = Db.SystemUsers.FirstOrDefault(d => d.Id == model.UserId && !d.IsArchived);
                    if (chkexisting != null)
                    {
                        contacts = Db.UserContacts.FirstOrDefault(d => d.Id == model.Id);

                        if (contacts == null)
                        {
                            contacts = new UserContact
                            {
                                Id = Guid.NewGuid().ToString()                                
                            };
                        }
                        else
                        {
                            isupdate = true;
                        }

                        contacts.UserId = model.UserId;
                        contacts.ContactPhone = model.ContactPhone;
                        contacts.ContactName = model.ContactName;
                        contacts.ContactDescription = model.ContactDescription;

                        contacts.IsArchived = false;

                        if (!isupdate)
                            Db.UserContacts.Add(contacts);
                        Db.SaveChanges();

                        return new APIReturnModel { Status = 1,Value=contacts.Id };
                    }
                    else
                        return new APIReturnModel { Status = 4 };
                }
                else
                    return new APIReturnModel { Status = 4 };

            }
            catch (Exception ex)
            {
                return new APIReturnModel { Status = 0 };
            }
        }

        /// <summary>
        /// 1= Success, 0= Failed, 4= User not Found
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public APIReturnModel DeleteUserContacts(string id)
        {
            try
            {
                UserContact contact = Db.UserContacts.FirstOrDefault(d => d.Id == id);
                if (contact != null)
                {
                    contact.IsArchived = true;
                    Db.SaveChanges();
                    return new APIReturnModel { Status = 1,Value=contact.Id };
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
