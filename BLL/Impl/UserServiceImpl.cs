using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Impl
{
    public class UserServiceImpl : UserService
    {
        UserDao _userDao;

        public UserServiceImpl(UserDao userDao)
        {
            _userDao = userDao;
        }
        public bool add(string str)
        {
            if (_userDao.insert(str))
            {
                return true;
            }

            return false;
        }
    }
}
