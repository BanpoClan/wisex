using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wisex.Common.Attributes;

namespace Wisex.Entity.Models
{
    [TableMappingAttribute(tableName: "RoleMenu")]
    public class RoleMenu : BaseModel
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 菜单ID
        /// </summary>
        public int MenuId { get; set; }
    }
}
