using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppServices
{
    public static class Constant
    {
        public static readonly string USER_EXIST="User already registered.";
        public static readonly string USER_NOT_EXIST = "User does not exist.";
        public static readonly string SIGNUP_EMAIL = "Verification Email-TestApp";
        public static readonly string LINK_EXPIRE = "Verification link is expired.Please create new one";
        public static readonly string USER_INVALID_PASSWORD = "Invalid password.";
        public static readonly string USER_IS_NOT_VERIFIED = "User is not verified yet.Please check your email for link or either click on below link for regenerate verification link.";
    }
}
