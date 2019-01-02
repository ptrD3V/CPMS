using CPMS.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CPMS.BL.Factories
{
    public class BaseFactory<T> : IBaseFactory<T> where T : class
    {
        private readonly ManagementSystemContext _ctx;

        public BaseFactory(ManagementSystemContext ctx)
        {
            _ctx = ctx;
        }

        public T Identify(T item)
        {
            try
            {
                Type type = item.GetType();
                object obj = Activator.CreateInstance(type);
                obj = item;
                PropertyInfo prop = type.GetProperty("ID");
                Type propertyType = prop.PropertyType;
                TypeCode typeCode = Type.GetTypeCode(propertyType);
                int oldID = (int)prop.GetValue(obj, null);
                if (prop != null && oldID <= 0)
                {
                    int value = _ctx.Set<T>().Count() + 1;
                    prop.SetValue(obj, value, null);
                }

                return (T)obj;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return null;
        }
    }
}
