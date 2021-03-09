using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Zoomtel.Persist;
using System.Configuration;
using Zoomtel.AutoMapper;
using Zoomtel.Service;
using EFCoreRepository.DbContexts;
using Zoomtel.Entity;
using Zoomtel.Service.Auth;
using Zoomtel.Auth;
using Zoomtel.Utils;
using Zoomtel.Swagger;
using Zoomtel.Cache;
using Zoomtel.Quartz.Core;
using Quartz;
using Zoomtel.Quartz.Abstractions;
using Zoomtel.MiniProfiler;
namespace Zoomtel.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        //用于配置应用启动时加载的Service
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
            });
            services.AddNetModularServices();
            //services.AddModuleServices();
            //services.AddSingleton<ILog, Log>();
            string path = Directory.GetCurrentDirectory();

            services.AddMappers(new string[1] { "Zoomtel.Service" });
            services.AddModuleServices(new string[1] { "Zoomtel.Service" });
            services.AddModuleRepository(new string[1] {  "Zoomtel.Persist" });


            services.AddSingleton<ISchedulerListener, Zoomtel.Service.Quartz.SchedulerListener>();//注入Quartz监听
            services.AddSingleton<ITaskLogger, Service.Quartz.TaskLogger>();

            services.AddQuartz();
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json");
            var config = builder.Build();
            //添加缓存
            services.AddCache(config);





            //services.AddDbContext<DefaultDbContext>(options =>
            // options.UseSqlServer("Data Source=127.0.0.1;Initial Catalog=zoomtel;User ID=sa;Password=sasa;"));

            //Init Swagger
            services.AddSwagger();//API 文档 以及在线调试功能
        
            #region Jwt配置
           //config.GetSection()
            //将appsettings.json中的JwtSettings部分文件读取到JwtSettings中，这是给其他地方用的
            services.Configure<JwtSettings>(config.GetSection("JwtSettings"));

            //由于初始化的时候我们就需要用，所以使用Bind的方式读取配置
            //将配置绑定到JwtSettings实例中
            var jwtSettings = new JwtSettings();
            config.Bind("JwtSettings", jwtSettings);


            //添加授权角色策略
            services.AddAuthorization(options =>
            {
                options.AddPolicy("BaseRole", options2 => options2.RequireRole("admin"));
            });
            //添加身份验证
            services.AddAuthentication(options =>
            {
                //认证middleware配置
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                //options.AddPolicy("BaseRole", options => options.RequireRole("admin"));

            })
            .AddJwtBearer(o =>
            {
                //jwt token参数设置
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = JwtClaimTypes.Name,
                    RoleClaimType = JwtClaimTypes.Role,
                    //Token颁发机构
                    ValidIssuer = jwtSettings.Issuer,
                    //颁发给谁
                    ValidAudience = jwtSettings.Audience,
                    //这里的key要进行加密
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),

                    /***********************************TokenValidationParameters的参数默认值***********************************/
                    // RequireSignedTokens = true,
                    // SaveSigninToken = false,
                    // ValidateActor = false,
                    // 将下面两个参数设置为false，可以不验证Issuer和Audience，但是不建议这样做。
                    // ValidateAudience = true,
                    // ValidateIssuer = true, 
                    // ValidateIssuerSigningKey = false,
                    // 是否要求Token的Claims中必须包含Expires
                    // RequireExpirationTime = true,
                    // 允许的服务器时间偏移量
                    // ClockSkew = TimeSpan.FromSeconds(300),
                    // 是否验证Token有效期，使用当前时间与Token的Claims中的NotBefore和Expires对比
                    // ValidateLifetime = true
                };
            });

            #endregion
         
            //引入MVC模块
            services.AddMvc(options =>
            {
                //options.Filters.Add(new ActionFilter());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            .AddJsonOptions
            (
                json =>
                {
                 
                    //统一设置JsonResult中的日期格式
                    json.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";//设置json 返回日期的格式
                }
            );


            services.AddHttpContextAccessor();
            //services.AddSingleton<ILoginInfo, LoginInfo>();

            // 配置跨域处理，允许所有来源
            services.AddCors(options =>
            options.AddPolicy("cors",
            p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials()));

            services.AddMiniProfiler();

            var connstr = config["ConnectionStrings:DefaultConnection"];
           
            services.AddCustomMiniProfiler();
            services.AddDbContext<DefaultDbContext>(options =>
              options.UseSqlServer(connstr, b => b.UseRowNumberForPaging()));//添加EF数据库引用  支持sql server 2008
            //注入权限集合
            services.AddScoped<PermissionCollection>();

          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //用于配置HTTP请求管道
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,DefaultDbContext dbcontent)
        {

            app.UseCustomMiniProfiler();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }



            //app.UseHttpsRedirection();
            //1.先开启认证

            //app.UseMvc(routes =>
            //{
            //    //配置默认路由
            //    routes.MapRoute(
            //        name: "Default",
            //        template: "api/{controller}/{action}",
            //        defaults: new { controller = "Home", action = "Index" }
            //    );
            //});
            // 允许所有跨域，cors是在ConfigureServices方法中配置的跨域策略名称
            app.UseCors("cors");
            app.UseStaticFiles();
            app.UseCookiePolicy();
            //Add User session
            app.UseSession();
            //Add JWToken to all incoming HTTP Request Header
            app.Use(async (context, next) =>
            {

                var JWToken = context.Session.GetString("JWToken");
                if (!string.IsNullOrEmpty(JWToken) && !context.Request.Headers.Keys.Contains("Authorization"))
                {
                    context.Request.Headers.Add("Authorization", "Bearer " + JWToken);
                }
                await next();
            });

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "default",
                   template: "{controller=Home}/{action=Index}/{id?}"
                 );
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });


            //2.再开启授权
            //app.UseAuthorization();
            
            app.UseCustomSwagger();
            //app.UseMiniProfiler();

            dbcontent.Database.EnsureCreated();//数据库不存在自动创建
        }
    }
}
