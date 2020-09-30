using Insql;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class CommonDbContext<TScope> : DbContext where TScope : class
    {
        public CommonDbContext(CommonDbContextOptions<TScope> options): base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string str = "Server=localhost;uid=sa;pwd=123456;database=Test;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=false;";
            optionsBuilder.UseSqlServer(str);
        }


    }


}
