using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Impl
{
    public class UserServiceImpl : UserService
    {
        private readonly UserDao _userDao;
        private readonly DapperConn.Dao.UserDao _userDao2;

        public UserServiceImpl(UserDao userDao, DapperConn.Dao.UserDao userDao2)
        {
            _userDao = userDao;
            _userDao2 = userDao2;
        }

        public bool add(string str)
        {
            if (_userDao.insert(str))
            {
                return true;
            }

            return false;
        }

        public void add(User user)
        {
            _userDao.Add(user);
        }

        public bool addUser(User user)
        {
            return _userDao2.InsertData(user);
        }

        public void delete(int id)
        {
            _userDao.Delete(id);
        }

        public bool deleteUser(int id)
        {
            return _userDao2.DeleteData(id);
        }

        public User getUser(int id)
        {
            return _userDao.GetUser(id);
        }

        public List<User> getUserByUserName(string username)
        {
            return _userDao2.FindListByUserName(username);
        }

        public IEnumerable<User> getUsers()
        {
            return _userDao.GetUsers();
        }

        public void update(User user)
        {
            _userDao.Update(user);
        }

        public bool updateUser(User user)
        {
            return _userDao2.UpdateData(user);
        }
    }
}
