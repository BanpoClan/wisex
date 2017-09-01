using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wisex.Entity.CommonModel;
using Wisex.Entity.Models;

namespace Wisex.Service.SystemControl
{
    public interface IEmailPoolService
    {
        /// <summary>
        /// 获取指定数量的待发送邮件
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        List<EmailPool> GetWithReceivers(int top);
        /// <summary>
		/// 添加emailpool
		/// </summary>
		/// <param name="emailpool">emailpool实体</param>
		/// <returns></returns>
		bool Add(EmailPool emailpool);

        /// <summary>
        /// 批量添加emailpool
        /// </summary>
        /// <param name="models">emailpool集合</param>
        /// <returns></returns>
        bool Add(List<EmailPool> models);

        /// <summary>
        /// 编辑emailpool
        /// </summary>
        /// <param name="emailpool">实体</param>
        /// <returns></returns>
        bool Update(EmailPool emailpool);

        /// <summary>
        /// 批量更新emailpool
        /// </summary>
        /// <param name="emailpools">emailpool实体集合</param>
        /// <returns></returns>
        bool Update(IEnumerable<EmailPool> emailpools);

        /// <summary>
        /// 删除emailpool
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// 批量删除emailpool
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        bool Delete(Expression<Func<EmailPool, bool>> exp);

        /// <summary>
        ///  获取单条符合条件的 emailpool 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        EmailPool GetOne(Expression<Func<EmailPool, bool>> exp);

        /// <summary>
        /// 查询符合调价的 emailpool
        /// </summary>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        List<EmailPool> Query<OrderKeyType>(Expression<Func<EmailPool, bool>> exp, Expression<Func<EmailPool, OrderKeyType>> orderExp, bool isDesc = true);

        /// <summary>
        /// 分页获取emailpool
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        ResultModel<EmailPool> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<EmailPool, bool>> exp, Expression<Func<EmailPool, OrderKeyType>> orderExp, bool isDesc = true);

        /// <summary>
        /// 分页获取emailpool
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderBy">排序条件</param>
		/// <param name="orderDir">是否是降序排列</param>
        /// <returns></returns>
        ResultModel<EmailPool> GetWithPages(QueryBase queryBase, Expression<Func<EmailPool, bool>> exp, string orderBy, string orderDir = "desc");
    }
}
