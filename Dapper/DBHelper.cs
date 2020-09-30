using Common;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;

namespace DapperConn
{
    public class DBHelper
    {
        public static string ConnStrings
        {
            get
            {
                // framework 项目使用 获取 Web.config 或者 App.config 文件节点信息
                //return ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;

                // .net code 项目使用 读取启动项目 appsettings.json 配置文件
                //return AppConfigurtaionServices.Configuration.GetSection("ConnectionStrings").GetConnectionString("SqlServerConnection");   // null 没有读到

                return AppConfigurtaionServices.Configuration["ConnectionStrings:SqlServerConnection"];   // 读取二级菜单
            }
        }
    }
}
