using Autofac;
using Interfaces.Repository.Repository;
using LZ.IRepository.IRepository;
using LZ.IService;
using LZ.Service;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading.Tasks;

namespace LZ.Web
{
    public class DefaultModuleRegister : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ////注册当前程序集中以“Service”及“Repository”结尾的类,暴漏类实现的所有接口，生命周期为PerLifetimeScope

            //以“Service”及“Repository”结尾的类是利用发型实现的数据仓库的管理及业务处理的类和接口
            //builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            //builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

            //builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("Controller")).AsImplementedInterfaces().InstancePerLifetimeScope();
            var serviceAssembly = Assembly.Load("LZ.Service");
            builder.RegisterAssemblyTypes(serviceAssembly).Where(o => o.Name.Contains("Service")).AsImplementedInterfaces().PropertiesAutowired();
            var repositoryAssembly = Assembly.Load("LZ.Repository");
            builder.RegisterAssemblyTypes(repositoryAssembly).Where(o => o.Name.Contains("Repository")).AsImplementedInterfaces().PropertiesAutowired();

           

            //builder.Register(c => new UserRepository())
            //  .As<IUserRepository>()
            //  .InstancePerLifetimeScope();

            //builder.Register(c => new BaseService(c.Resolve<IUserRepository>()))
            //   .As<IBaseService>()
            //   .InstancePerLifetimeScope();
        }

        public static Assembly GetAssembly(string assemblyName)
        {
            var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(AppContext.BaseDirectory + $"{assemblyName}.dll");
            return assembly;
        }

    }
}
