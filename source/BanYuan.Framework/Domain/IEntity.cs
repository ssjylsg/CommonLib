using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BanYuan.Framework.Domain
{
    public interface IEntity<T>
    {
        T Id { get; }
        void SetId(T id);
    }
}
