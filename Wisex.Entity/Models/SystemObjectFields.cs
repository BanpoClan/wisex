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
    [TableMappingAttribute(tableName: "SystemObjectSummary")]
    public class SystemObjectSummary
    {
        public int Id { get; set; }
        [Required, DisplayName("表名称"), MinLength(2), MaxLength(20)]
        public string ObjectName { get; set; }
        [Required, DisplayName("描述"), MinLength(2), MaxLength(500)]
        public string Summary { get; set; }

    }

    [TableMappingAttribute(tableName: "SystemObjectFields")]
    public class SystemObjectFields
    {
        public int Id { get; set; }
        [Required, DisplayName("字段名称"), MinLength(2), MaxLength(20)]
        public string FieldName { get; set; }

        [DisplayName("描述"), MinLength(2), MaxLength(500)]
        public string Summary { get; set; }
        [Required, DisplayName("显示名称"), MinLength(2), MaxLength(20)]
        public string DisplayName { get; set; }
        [DisplayName("字段类型"), MinLength(2), MaxLength(20)]
        public string TypeName { get; set; }
        public bool PKConstraint { get; set; }
        public int SummaryID { get; set; }
    }
}
