using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;

namespace BanYuan.Framework.Denpency
{
    public class WindsorResolver : IDependencyResolver
    {
        protected IWindsorContainer _container;

        public WindsorResolver(IWindsorContainer container)
        {
            this._container = container;
        }
        /// <summary>
        /// 获取Windsor容器
        /// </summary>
        public virtual IWindsorContainer Container
        {
            get { return this._container; }
        }

        #region IDependencyResolver Members

        public T Resolve<T>()
        {
            return (T)this.Resolve(typeof(T));
        }

        public T Resolve<T>(Type type)
        {
            return this.Resolve<T>(type);
        }

        public object Resolve(Type type)
        {
            return this._container.Kernel.HasComponent(type) ? this._container.Resolve(type) : null;
        }

        public object Resolve(string key)
        {
            return this._container.Kernel.HasComponent(key) ? this._container.Resolve(key) : null;
        }

        public object Resolve(string key, Type type)
        {
            return this._container.Kernel.HasComponent(key) ? this._container.Resolve(key, type) : null;
        }

        public void Release(object instance)
        {
            this._container.Release(instance);
        }
        #endregion
    }
}
