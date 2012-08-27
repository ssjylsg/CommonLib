using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BanYuan.Framework
{
   public interface IExceptionSystem
    {
       bool IsKnown(Exception e);
    }
}
