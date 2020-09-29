using Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class UserDao
    {
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
