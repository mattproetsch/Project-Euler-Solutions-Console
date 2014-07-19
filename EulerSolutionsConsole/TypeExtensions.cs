using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace TypeExtensions
{
    public static class StaticPropertyGetterExension
    {
        public static T GetStaticPropertyValue<T>(this Type t, string propName)
        {
            PropertyInfo pInfo = t.GetProperty(propName, BindingFlags.Public | BindingFlags.Static);

            if (pInfo == null)
            {
                Type paramType = typeof(T);
                throw new NotImplementedException("You must implement the \"public static " + paramType.FullName + " " + propName + "\" property in " + t.Name + ".");
            }

            return (T)pInfo.GetValue(null, null);

        }
    }
}
