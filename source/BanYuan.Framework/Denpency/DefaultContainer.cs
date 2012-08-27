using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;

namespace BanYuan.Framework.Denpency
{
  public   class DefaultContainer 
    {
        public DefaultContainer()
        {
            Castle.Windsor.IWindsorContainer container = new Castle.Windsor.WindsorContainer(""); 
            container.Register(Component.For(typeof (string)).ImplementedBy(typeof (int)).Named("").LifeStyle.Singleton);
        }
    }
}
