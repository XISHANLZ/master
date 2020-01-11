using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using log4net;
using log4net.Config;
using log4net.Repository;
using LZ.IRepository;
using LZ.Model.EntityContext;
using LZ.Repository;
using LZ.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace LZ.web
{
    public class Startup
    {
        public static ILoggerRepository Repository { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            //配置log4Net
            Repository = LogManager.CreateRepository("NETCoreRepository");
            // 指定配置文件
            XmlConfigurator.Configure(Repository, new FileInfo("config/log4net.config"));


        }

        public IConfiguration Configuration { get; }
        public static IContainer AutofacContainer;
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            
            // 配置EF服务注册
            services.AddDbContext<EntityContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));

            services.AddMvcCore()
                .AddAuthorization();//认证服务.AddJsonFormatters()        

            services.Replace(ServiceDescriptor
            .Transient<IControllerActivator, ServiceBasedControllerActivator>());//3.0

            //services.AddControllers();//3.0
            services.AddControllersWithViews().AddControllersAsServices();//3.0
            services.AddRazorPages();//3.0
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMemoryCache();//使用本地缓存必须添加
            services.AddSession();//使用Session

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            //add autofac
            ContainerBuilder containerbuilder = new ContainerBuilder();
            //将services中的服务填充到Autofac中
            containerbuilder.Populate(services);
            //型模块组件注册
            containerbuilder.RegisterModule<DefaultModuleRegister>();//<DefaultModuleRegister>();
            //创建容器
            AutofacContainer = containerbuilder.Build();
            //使用容器
            new AutofacServiceProvider(AutofacContainer);



            // //配置autoMapper
            // services.AddAutoMapper(Assembly.Load("LZ.Model"));

            // #region 仓储层
            // services.AddScoped<DbContext, EntityContext>();
            // #endregion

            // #region 配置autofac
            // var builder = new ContainerBuilder();
            // builder.Populate(services);

            // ConfigureContainer(builder);


            //return new AutofacServiceProvider(builder.Build());
            //#endregion
        }
        //通过配置容器注册接口类

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<DefaultModuleRegister>();
        }
        //public void ConfigureContainer(ContainerBuilder builder)
        //{
        //    //添加依赖注入关系
        //    builder.RegisterModule(new AutofacModuleRegister());
        //    var controllerBaseType = typeof(ControllerBase);
        //    //在控制器中使用依赖注入
        //    builder.RegisterAssemblyTypes(typeof(Program).Assembly)
        //        .Where(t => controllerBaseType.IsAssignableFrom(t) && t != controllerBaseType)
        //        .PropertiesAutowired();
        //}
        //public void ConfigureContainer(ContainerBuilder builder)
        //{
        //    var serviceAssembly = Assembly.Load("LZ.Service");
        //    builder.RegisterAssemblyTypes(serviceAssembly).Where(o => o.Name.Contains("Service")).AsImplementedInterfaces().PropertiesAutowired();
        //    var repositoryAssembly = Assembly.Load("LZ.Repository");
        //    builder.RegisterAssemblyTypes(repositoryAssembly).Where(o => o.Name.Contains("Repository")).AsImplementedInterfaces().PropertiesAutowired();
        //    //builder.RegisterAssemblyTypes(typeof(Program).Assembly).
        //    //    Where(x => x.Name.EndsWith("service", StringComparison.OrdinalIgnoreCase)).AsImplementedInterfaces();
        //    //builder.Register(c => new TokenAuthorizeAttribute(c.Resolve<IUserRoleActionAuthorityRepository>(), c.Resolve<IUserRepository>(), c.Resolve<IRoleViewService>())).InstancePerRequest().PropertiesAutowired();

        //    //    builder.RegisterAssemblyTypes(typeof(Program).Assembly).
        //    //Where(x => x.Name.EndsWith("service", StringComparison.OrdinalIgnoreCase)).AsImplementedInterfaces();
        //    //    builder.RegisterDynamicProxy();

        //    //    builder.RegisterAssemblyTypes(this.GetType().Assembly)
        //    //.AsImplementedInterfaces()
        //    //.PropertiesAutowired();
        //}
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHost host, Microsoft.Extensions.Hosting.IHostApplicationLifetime appLitetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
             
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors("default");//跨域管道

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            appLitetime.ApplicationStopped.Register(() => { AutofacContainer.Dispose(); });
        }
    }
}
