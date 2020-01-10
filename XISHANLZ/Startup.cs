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
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            //����log4Net
            Repository = LogManager.CreateRepository("NETCoreRepository");
            // ָ�������ļ�
            XmlConfigurator.Configure(Repository, new FileInfo("config/log4net.config"));


        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public AutofacServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            // ����EF����ע��
            services.AddDbContext<EntityContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));
            //services.AddScoped<IconcardContext, EntityContext>();
            //services.AddScoped<ILZRepositoryFactory, LZRepositoryFactory>();
            //services.AddScoped<IService, Service>();
            //����autoMapper
            services.AddAutoMapper(Assembly.Load("LZ.Model"));
            #region �ִ���
            services.AddScoped<DbContext, EntityContext>();
            #endregion

            #region ����autofac
            var builder = new ContainerBuilder();
            builder.Populate(services);

            ConfigureContainer(builder);
            

           return new AutofacServiceProvider(builder.Build());
            #endregion
        }
        //public void ConfigureContainer(ContainerBuilder builder)
        //{
        //    //�������ע���ϵ
        //    builder.RegisterModule(new AutofacModuleRegister());
        //    var controllerBaseType = typeof(ControllerBase);
        //    //�ڿ�������ʹ������ע��
        //    builder.RegisterAssemblyTypes(typeof(Program).Assembly)
        //        .Where(t => controllerBaseType.IsAssignableFrom(t) && t != controllerBaseType)
        //        .PropertiesAutowired();
        //}
        public void ConfigureContainer(ContainerBuilder builder)
        {
            var serviceAssembly = Assembly.Load("LZ.Service");
            builder.RegisterAssemblyTypes(serviceAssembly).Where(o => o.Name.Contains("Service")).AsImplementedInterfaces().PropertiesAutowired();
            var repositoryAssembly = Assembly.Load("LZ.Repository");
            builder.RegisterAssemblyTypes(repositoryAssembly).Where(o => o.Name.Contains("Repository")).AsImplementedInterfaces().PropertiesAutowired();
            //builder.RegisterAssemblyTypes(typeof(Program).Assembly).
            //    Where(x => x.Name.EndsWith("service", StringComparison.OrdinalIgnoreCase)).AsImplementedInterfaces();
            //builder.Register(c => new TokenAuthorizeAttribute(c.Resolve<IUserRoleActionAuthorityRepository>(), c.Resolve<IUserRepository>(), c.Resolve<IRoleViewService>())).InstancePerRequest().PropertiesAutowired();

            //    builder.RegisterAssemblyTypes(typeof(Program).Assembly).
            //Where(x => x.Name.EndsWith("service", StringComparison.OrdinalIgnoreCase)).AsImplementedInterfaces();
            //    builder.RegisterDynamicProxy();

            //    builder.RegisterAssemblyTypes(this.GetType().Assembly)
            //.AsImplementedInterfaces()
            //.PropertiesAutowired();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            //�������ã�������app.UserMvc ����app.Run ǰ
            //app.UseCors(e =>
            //{
            //    e.AllowAnyMethod();
            //    e.AllowAnyOrigin();
            //    e.AllowAnyHeader();
            //});
            //app.UseMvc();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            
           
        }
    }
}
