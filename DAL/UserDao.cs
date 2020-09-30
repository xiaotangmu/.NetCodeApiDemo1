using Insql;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class UserDao: DbContext
    {
        public UserDao(DbContextOptions<UserDao> options) : base(options)
        {
        }

        public User GetUser(int id)
        {
            //"GetUser"对应 select上的id,
            //第二个查询参数支持 PlainObject和 IDictionary<string,object>两种类型
            return this.Query<User>("GetUser", new { id }).SingleOrDefault();
        }

        public IEnumerable<User> GetUsers()
        {
            return this.Query<User>("GetUsers");
        }

        public void Add(User user)
        {
            this.Execute(nameof(Add), user);
        }

        public void Update(User user)
        {
            this.Execute(nameof(Update), user);
        }

        public void Delete(int id)
        {
            this.Execute(nameof(Delete), new { id });
        }

        public bool insert(string str)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=localhost;uid=sa;pwd=123456;database=Test;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=false;";
            SqlCommand sqlCommand = conn.CreateCommand();
            sqlCommand.CommandType = CommandType.Text;
            string sqlStr = "select * from t_user";
            sqlCommand.CommandText = sqlStr;
            conn.Open();

            object users = sqlCommand.ExecuteScalar();  // "" 只拿第一行第一列单个数据

            conn.Close();   // 关闭，可再次连接
            conn.Dispose(); // 释放，需要重新配置

            return true;
        }

    }
}
