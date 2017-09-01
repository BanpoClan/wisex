using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wisex.Common.Attributes
{
    public class AttributeUtils
    {
        public static object[] CheckIsExistAttribute<T>(Type attribute)
        {
            var type = typeof(T);
            return type.GetCustomAttributes(attribute, false);
        }
    }
}
