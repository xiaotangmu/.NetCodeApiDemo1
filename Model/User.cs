using System;
using System.Collections.Generic;

namespace Model
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string pwd { get; set; }

        public List<Role> roles { get; set; }

        public UserInfo userInfo { get; set; }
    }
}
