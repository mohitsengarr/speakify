using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeakifyAPI.Utility
{
    public class StatusMessages
    {
        public const string Success = "Success";
        public const string Error_Failed = "Failed";
        public const string Error_UserNotFound = "User Not Found.";
        public const string Error_UserNameExists = "Username is taken.";
        public const string Error_EmailExists = "Email already exists in our system.";
        public const string Error_LoginFailed = "Login Failed";
        public const string Error_Login_UserNamePasswordNotFound = "User not available.";
        public const string Error_UserUpdateFailed_GUID = "Failed to update user. (User ID is empty GUID)";
        public const string Error_UserDeleteFailed_GUID = "Failed to delete user. (User ID is empty GUID)";

        public static string Get(int code)
        {
            switch (code)
            {
                case 0:
                    return Error_Failed;
                    
                case 1:
                    return Success;
                    
                case 2:
                    return Error_UserNameExists;
                   
                case 3:
                    return Error_EmailExists;

                case 4:
                    return Error_UserNotFound;

                default:
                    break;
            }
            return string.Empty;
        }

    }
}
