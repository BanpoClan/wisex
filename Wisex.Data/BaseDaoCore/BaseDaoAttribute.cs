using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wisex.Common.Attributes;

namespace Wisex.Dao
{
    public class BaseDaoAttribute
    {
        public static TableMappingAttribute GetTableMappingAttribute(Type t)
        {
            TableMappingAttribute tableAttribute = null;
            var tableMame = string.Empty;
            var attributes = t.GetCustomAttributes(false);
            foreach (var attribute in attributes)
            {
                var tmp = attribute as Wisex.Common.Attributes.TableMappingAttribute;
                if (tmp != null)
                {
                    tableAttribute = new TableMappingAttribute(tmp.TableName, tmp.LikeQueryFields);
                    break;
                }
            }

            return tableAttribute;
        }
    }
}
