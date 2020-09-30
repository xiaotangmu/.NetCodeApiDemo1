using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.Impl;
using DAL;
using Insql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SlowApp
{
    public class Startup
    {
        /// <summary>
        /// ���񼯺�
        /// </summary>
        private IServiceCollection _services;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // ������ݿ�orm insql ���
            services.AddInsql();
            services.AddInsqlDbContext<UserDao>(options =>
            {
                //����������������ʹ�����SqlServer���ݿ�
                options.UseSqlServer("Server=localhost;uid=sa;pwd=123456;database=Test;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=false;");
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                      .AllowAnyOrigin() //.WithOrigins(new string[] {"",""})
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .AllowCredentials()
                .Build());
            });

            // ����ע��
            services.AddSingleton(Configuration);
            services.AddScoped<UserService, UserServiceImpl>();
            services.AddScoped(typeof(DAL.UserDao));
            services.AddScoped(typeof(DapperConn.Dao.UserDao));

            services.AddHttpClient();

            services.AddControllers();
            _services = services;

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
