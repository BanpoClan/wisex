using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wisex.Common.Attributes;

namespace Wisex.Entity.Models
{
    [TableMappingAttribute(tableName: "Articles")]
    public class Articles : BaseModel
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Contents { get; set; }

    }
}
