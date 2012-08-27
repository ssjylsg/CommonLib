using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BanYuan.Framework
{
    public class DependencyResolver
    {
        internal static IDependencyResolver Resolver;
        public static T Resolve<T>()
        {
            return Resolver.Resolve<T>();
        }
    }
}
