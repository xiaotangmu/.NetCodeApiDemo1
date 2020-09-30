using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SlowApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(UserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IEnumerable<User> Post([FromBody] User user)    // params 参数
        {

            //_userService.add(user.username);

            #region 测试Insql
            // add
            //_userService.add(user);

            //user = _userService.getUser(user.id);
            //_logger.LogInformation("getUser: id: " + user.id + ", username: " +
            //     user.username + ", pwd: " + user.pwd);

            //// getUsers
            //_logger.LogInformation("getUsers: " + _userService.getUsers());

            //// update
            //user.username = "xiao";
            //_userService.update(user);

            //// delete
            //_userService.delete(3);
            #endregion

            #region 测试 Dapper
            // 添加
            bool res1 = _userService.addUser(user);
            _logger.LogInformation("addUser: " + res1);
            // 查找
            List<User> users = _userService.getUserByUserName(user.username);
            _logger.LogInformation(users.ToString());

            // 更新 C# 6 语法
            User user2 = new User
            {
                id = 1,
                username = "xxx",
                pwd = "123456"
            };
            bool res2 = _userService.updateUser(user2);
            _logger.LogInformation("updateUser: " + res2);

            // 删除
            bool res3 = _userService.deleteUser(2);
            _logger.LogInformation("Delete: " + res3);
            #endregion

            return users;
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IEnumerable<string> Put(int id, string value) // 报415 没有[FromBody] 可以接受到value，有接收不到
        {
            return new string[] { id + "", value };
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return true;
        }
    }
}
