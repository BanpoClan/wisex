using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wisex.Common.Attributes;

namespace Wisex.Entity.Models
{
    [TableMappingAttribute(tableName: "Roles", likeQueryFields: "Name,Description")]
    public class Role : BaseModel
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [Required, DisplayName("角色名称"), MinLength(2), MaxLength(20)]
        [LikeQueryAttribute()]
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Required, DisplayName("描述"), MinLength(1), MaxLength(50)]
        public string Description { get; set; }
    }
}
