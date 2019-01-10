using CPMS.DAL.Context;
using System;
using System.Linq;
using System.Reflection;

namespace CPMS.BL.Factories
{
    /// <summary>
    /// Base factory is template for factory classes.
    /// </summary>
    /// <typeparam name="T">Class type</typeparam>
    public class BaseFactory<T> : IBaseFactory<T> where T : class
    {
        // DB Context
        private readonly ManagementSystemContext _ctx;

        /// <summary>
        /// Constructor of generic factory
        /// </summary>
        /// <param name="ctx">DB context</param>
        public BaseFactory(ManagementSystemContext ctx)
        {
            _ctx = ctx;
        }

        /// <summary>
        /// Helper function that was used when DB indexer fails.
        /// This function is not used in production.
        /// </summary>
        /// <param name="item">Class type</param>
        /// <returns>Class type object</returns>
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
