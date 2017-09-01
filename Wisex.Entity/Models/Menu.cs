using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wisex.Common.Attributes;
using Wisex.Common.Enums;

namespace Wisex.Entity.Models
{
    [TableMappingAttribute(tableName: "Menu")]
    public class Menu : BaseModel
    {

        /// <summary>
        /// 上级ID
        /// </summary>
        [DisplayName("上级分类")]
        public int ParentId { get; set; }

        public string sql { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [DisplayName("类型")]
        public MenuType Type { get; set; }

        /// <summary>
        /// 类型名称
        /// </summary>
        public string TypeName
        {
            get { return Type.ToString(); }
        }

        /// <summary>
        /// 名称
        /// </summary>
        [DisplayName("名称")]
        public string Name { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DisplayName("数据表名称")]
        public string TableName { get; set; }
        
        /// <summary>
        /// URL
        /// </summary>
        [DisplayName("URL")]
        public string Url { get; set; }

        [DisplayName("排序")]
        public int Order { get; set; }
    }
}
