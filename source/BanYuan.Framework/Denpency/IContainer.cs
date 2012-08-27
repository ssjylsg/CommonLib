using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BanYuan.Framework.Denpency
{
    public interface IContainer
    {
        void RegisterComponent(string key, Type type);
        void RegisterComponent<T>(string key);
        void RegisterComponent(Type type);

        T GetService<T>(string key);
        T GetService<T>();
        object GetService(string key);

    }
}
