﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wisex.Entity.CommonModel
{
    /// <summary>
    /// 分页查询返回对象  where T : class
    /// </summary>
    /// <typeparam name="T">Data</typeparam>
    public class ResultModel<T> 
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        public int start { get; set; }

        /// <summary>
        /// 每页显示数量
        /// </summary>
        public int length { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int recordsTotal { get; set; }
        /// <summary>
        /// recordsFiltered
        /// </summary>
        public int recordsFiltered
        {
            get { return recordsTotal; }
        }

        /// <summary>
        /// 返回的数据
        /// </summary>
        public List<T> data { get; set; }
    }

    /// <summary>
    /// 通用json返回对象
    /// </summary>
    public class Result<T>
    {
        public Result()
        {
            flag = false;
            data = default(T);
            msg = string.Empty;
        }
        /// <summary>
        /// 是否操作成功
        /// </summary>
        public bool flag { get; set; }

        /// <summary>
        /// 返回的对象
        /// </summary>
        public T data { get; set; }

        /// <summary>
        /// 返回的提示消息
        /// </summary>
        public string msg { get; set; }
    }
}
