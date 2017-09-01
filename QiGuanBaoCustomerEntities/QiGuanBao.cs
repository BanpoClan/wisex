using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QiGuanBaoCustomerEntities
{
    public class BaseInfo
    {
        /// <summary>
        /// 耐氏地板
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 行业：
        /// </summary>
        public string industry { get; set; }

        /// <summary>
        /// 背景：
        /// </summary>
        public string background { get; set; }

    }



    public class DetailInfoItem
    {
        /// <summary>
        /// 业务需求
        /// </summary>
        public string TitleDIV { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string detail { get; set; }

    }



    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public BaseInfo baseInfo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<DetailInfoItem> detailInfo { get; set; }

    }
}
