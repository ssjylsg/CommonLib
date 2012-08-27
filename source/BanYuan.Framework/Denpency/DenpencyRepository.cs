using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BanYuan.Framework.Denpency;

namespace BanYuan.Framework
{
    public class DenpencyRepository
    {
        internal static IContainer _Resover;
        public static T GetService<T>()
        {
            return _Resover.GetService<T>();
        }
        public static T GetService<T>(string key)
        {
            return _Resover.GetService<T>(key);
        }
    }
}
