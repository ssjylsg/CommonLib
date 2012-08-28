using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Castle.Windsor;

namespace BanYuan.Framework
{
    public static class ExtensionMethods
    {
        public static void RegisterRepositories(this IWindsorContainer container, params  Assembly[] assembly)
        {

        }
        public static void RegisterServices(this IWindsorContainer container, Assembly[] assembly, Type interceptor)
        {

        }
        public static void RegisterRepositories(this IWindsorContainer container, Func<Type,bool> func, Assembly[] assembly)
        {

        }
        public static void RegisterComponent(this IWindsorContainer container, Assembly[] assembly, Type interceptor)
        {

        }
        public static void RegisterFromInterface(this IWindsorContainer container, Func<Type,bool> func, Assembly[] assembly)
        {

        }

    }
}
