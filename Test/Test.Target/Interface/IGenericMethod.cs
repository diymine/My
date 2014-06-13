using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Target.Interface
{
    public interface IGenericMethod
    {
        T GetValue<T>();
    }
}
