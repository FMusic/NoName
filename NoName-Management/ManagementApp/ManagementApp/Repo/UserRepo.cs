using ManagementApp.Model;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ManagementApp.Repo
{
    class UserRepo
    {
        public static User CheckLogin(LoginInfo li)
        {
            return RestCom<User, LoginInfo>.CommunicatePost(li, ApiStrings.LOGIN);
        }

        internal static IList<User> GetEmployees(User u)
        {
            return RestCom<List<User>>.CommunicateGet(ApiStrings.EMPLOYEES(u.PlaceId));
        }

        internal static int UpdateEmpl(User u)
        {
            return RestCom<User>.CommunicatePut(ApiStrings.USERS_BASE, u);
        }

        internal static int NewEmpl(User u)
        {
            return RestCom<User>.CommunicatePost(u, ApiStrings.USERS_BASE);
        }
    }
}
