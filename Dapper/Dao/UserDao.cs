using Dapper;
using Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DapperConn.Dao
{
    public class UserDao
    {
		/// <summary>
		/// 1. 查询
		/// IDbConnection  实际操作类
		/// </summary>
		/// <param name="username"></param>
		/// <returns></returns>
		public List<User> FindListByUserName(string username)
		{
			string connstr = DBHelper.ConnStrings;
			using (IDbConnection db = new SqlConnection(connstr))
			{

				// 1. string sql = "select * from Person where LastName = 'xxx'";

				// 2. 字符串拼接
				// string sql = "select * from Person where Lastname = '" + lastname + "'";

				// 3. Format 格式化
				// string sql = string.Format("select * from Person where LastName='{0}'", lastname);

				// 4. C#6 语法$
				// string sql = $"select * from Person where LastName = '{lastname}'";

				// IEnumerable<Person> lst  = db.Query<Person>(sql);	// Query 为db 对象扩展方法，返回值类型

				// 上面方法存在 SQL 注入问题

				// 5. 解决 SQL　注入问题
				string sql = $"select * from t_user where User_Name = @username";    // 用@作为参数

				IEnumerable<User> lst = db.Query<User>(sql, new { username = username });    // 
				return lst.ToList();    // 转换为List 的类型返回
			}
		}

		/// <summary>
		///  2. 插入
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public bool InsertData(User user)
		{
			using (IDbConnection db = new SqlConnection(DBHelper.ConnStrings))
			{
				// 准备插入的SQL 语句
				string sql = "insert into t_user(User_Name, Pwd) values" +
					"(@username, @pwd)";

				// 调用Dapper 中的 IDbConnection 扩展方法Excute() 来执行插入操作
				int result = db.Execute(sql, user);   // 第一个参数 SQL 语句 第二个参数Person 对象 

				// 简化条件判断返回
				return result > 0;
			}
		}

		/// <summary>
		/// 3. 更新
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public bool UpdateData(User user)
		{
			using (IDbConnection db = new SqlConnection(DBHelper.ConnStrings))
			{
				// 准备更新语句
				string sql = "update t_user set User_Name = @username, Pwd = @pwd where id = @id";

				// 执行更新语句
				int result = db.Execute(sql, user);

				return result > 0;
			}
		}

		/// <summary>
		/// 4. 删除
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool DeleteData(int id)
		{
			// 下面是根据id 执行删除
			using (IDbConnection db = new SqlConnection(DBHelper.ConnStrings))
			{
				// 准备 sql 语句
				string sql = "delete from t_user where id = @ID";

				// 执行删除
				int result = db.Execute(sql, new { ID = id });  // 匿名对象

				return result > 0;
			}
		}
	}
}
