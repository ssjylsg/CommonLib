using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using BanYuan.Framework.Denpency;
using Castle.MicroKernel.Registration;

namespace BanYuan.Framework
{
    public class SystemConfig
    {
        private static SystemConfig _systemConfig;
        private IExceptionSystem _exceptionSystem;
        public static SystemConfig Init()
        {
            _systemConfig = new SystemConfig();
            return _systemConfig;
        }
        /// <summary>
        /// 版本
        /// </summary>
        public string VersionFlag { get; private set; }
        /// <summary>
        /// 获取当前应用的名称
        /// </summary>
        public string AppName { get; private set; }
        private SystemConfig(string app, string versionFlag)
        {
            this.AppName = app;
            this.VersionFlag = versionFlag;
        }
        public static SystemConfig Initialize(string app, Action<WindsorResolver> func, params Assembly[] assemblies)
        {
            return Initialize(app, "DEBUG", func, assemblies);
        }
        private static void PrepareBase(SystemConfig config, WindsorResolver resolver, params Assembly[] assemblies)
        {
            //基础服务使用全局容器
            var windsor = resolver.Container;
            //注册工厂支持
            windsor.AddFacility<Castle.Facilities.FactorySupport.FactorySupportFacility>();
            //基础库注册
            //将web上下文服务注册为默认的上下文服务,HACK:由于过早提供该类，导致无法默认使用threadcontext
            //config.ContextService<WebContextService>();
            //默认的异常体系声明
            windsor.Register(Component
                .For<IExceptionSystem>()
                .UsingFactoryMethod(o => config._exceptionSystem)
                .LifeStyle.Transient);
            //注册拦截器
            windsor.Register(Component.For<ServiceInterceptor>().LifeStyle.Transient);

            var list = new List<Assembly>();
            //基础程序集
            //list.Add(Assembly.Load("Taobao.Repositories"));
            //list.Add(Assembly.Load("Taobao.Application"));
            //list.Add(Assembly.Load("Taobao.Model"));
            if (assemblies != null) list.AddRange(assemblies);
            list = list.Distinct().ToList();
            //DDD支持
            windsor.RegisterRepositories(list.ToArray());
            windsor.RegisterServices(list.ToArray(), typeof(ServiceInterceptor));
            //自定义类型注册
            windsor.RegisterComponent(list.ToArray(), typeof(ServiceInterceptor));
            windsor.RegisterFromInterface(IsFactory, list.ToArray());
            windsor.RegisterFromInterface(IsDao, list.ToArray());
            windsor.RegisterFromInterface(IsSpecial, list.ToArray());

        }

        private static bool IsSpecial(Type arg)
        {
            throw new NotImplementedException();
        }

        private static bool IsDao(Type arg)
        {
            throw new NotImplementedException();
        }

        private static bool IsFactory(Type arg)
        {
            throw new NotImplementedException();
        }


        public static SystemConfig Initialize(string app, string versionFlag, Action<WindsorResolver> func, params Assembly[] assemblies)
        {

            var assembly = Assembly.GetExecutingAssembly();
            var prefix = "Taobao.BusinessFramework.ConfigFiles.";
            var properties = prefix + "{0}.properties.config";

            //初始化
            _systemConfig = new SystemConfig(app, versionFlag);
            
            return _systemConfig;
        }
        public static SystemConfig Settings
        {
            get
            {
                if (_systemConfig == null)
                    throw new InvalidOperationException("请先调用Initialize执行配置初始化");
                return _systemConfig;
            }
        }
    }
}
