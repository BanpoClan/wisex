using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wisex.Common.Attributes
{
    public class TableMappingAttribute : Attribute
    {
        public string TableName { get; set; }
        public string LikeQueryFields { get; set; }
        private string[] LikeQueryFieldList
        {
            get
            {
                if (string.IsNullOrEmpty(LikeQueryFields))
                    return null;

                return LikeQueryFields.Split(',');
            }
        }

        public TableMappingAttribute(string tableName, string likeQueryFields=null)
        {
            TableName = tableName;
            LikeQueryFields = likeQueryFields;
        }
    }
}
