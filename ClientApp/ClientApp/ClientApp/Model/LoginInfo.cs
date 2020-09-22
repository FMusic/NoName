using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementApp.Model
{
    public class LoginInfo
    {
        public LoginInfo(string usr, string pass)
        {
            Usr = usr;
            Pwd = pass;
        }
        public string Usr { get; set; }
        public string Pwd { get; set; }
    }
}
