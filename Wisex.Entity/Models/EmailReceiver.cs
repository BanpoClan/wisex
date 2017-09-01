using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wisex.Common.Enums;

namespace Wisex.Entity.Models
{
    /// <summary>
    /// 邮件接收人
    /// </summary>
    public class EmailReceiver : BaseModel
    {
        /// <summary>
        /// 邮件ID
        /// </summary>
        public int EmailId { get; set; }

        /// <summary>
        /// 邮件地址
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 类型:收件人/抄送人/密送人 ext;
        /// </summary>
        public EmailReceiverType Type { get; set; }


        public string TypeName
        {
            get { return Type.ToString(); }
        }
    }
}
