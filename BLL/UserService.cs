using System;
using System.Collections;
using System.Collections.Generic;
using DAL;
using Model;

namespace BLL
{
    public interface UserService
    {
        bool add(string str);

        User getUser(int id);

        IEnumerable<User> getUsers();

        void add(User user);
        void update(User user);
        void delete(int id);

        // Dapper test find
        List<User> getUserByUserName(string username);
        bool addUser(User user);
        bool updateUser(User user);
        bool deleteUser(int id);
    }
}
