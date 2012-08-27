using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BanYuan.Framework.Domain
{
    public class BaseEntity : IEntity<object>
    {
        private object _id;
        public object Id
        {
            get { return this._id; }
        }

        public void SetId(object id)
        {
            this._id = id;
        }
    }
}
