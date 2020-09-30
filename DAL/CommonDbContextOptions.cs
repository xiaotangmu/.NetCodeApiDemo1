using Insql;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class CommonDbContextOptions<TScope> : DbContextOptions<CommonDbContext<TScope>> where TScope : class
    {
        public CommonDbContextOptions(IServiceProvider serviceProvider)
        {
        }
    }
}
