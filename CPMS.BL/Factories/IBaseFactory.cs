using System;
using System.Collections.Generic;
using System.Text;

namespace CPMS.BL.Factories
{
    public interface IBaseFactory<T>
    {
        T Identify(T item);
    }
}
