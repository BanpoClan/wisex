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
    public interface IEmailReceiverService
    {
        /// <summary>
		/// 添加emailreceiver
		/// </summary>
		/// <param name="emailreceiver">emailreceiver实体</param>
		/// <returns></returns>
		bool Add(EmailReceiver emailreceiver);

        /// <summary>
        /// 批量添加emailreceiver
        /// </summary>
        /// <param name="models">emailreceiver集合</param>
        /// <returns></returns>
        bool Add(List<EmailReceiver> models);

        /// <summary>
        /// 编辑emailreceiver
        /// </summary>
        /// <param name="emailreceiver">实体</param>
        /// <returns></returns>
        bool Update(EmailReceiver emailreceiver);

        /// <summary>
        /// 批量更新emailreceiver
        /// </summary>
        /// <param name="emailreceivers">emailreceiver实体集合</param>
        /// <returns></returns>
        bool Update(IEnumerable<EmailReceiver> emailreceivers);

        /// <summary>
        /// 删除emailreceiver
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// 批量删除emailreceiver
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        bool Delete(Expression<Func<EmailReceiver, bool>> exp);

        /// <summary>
        ///  获取单条符合条件的 emailreceiver 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        EmailReceiver GetOne(Expression<Func<EmailReceiver, bool>> exp);

        /// <summary>
        /// 查询符合调价的 emailreceiver
        /// </summary>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        List<EmailReceiver> Query<OrderKeyType>(Expression<Func<EmailReceiver, bool>> exp, Expression<Func<EmailReceiver, OrderKeyType>> orderExp, bool isDesc = true);

        /// <summary>
        /// 分页获取emailreceiver
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        ResultModel<EmailReceiver> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<EmailReceiver, bool>> exp, Expression<Func<EmailReceiver, OrderKeyType>> orderExp, bool isDesc = true);

        /// <summary>
        /// 分页获取emailreceiver
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderBy">排序条件</param>
		/// <param name="orderDir">是否是降序排列</param>
        /// <returns></returns>
        ResultModel<EmailReceiver> GetWithPages(QueryBase queryBase, Expression<Func<EmailReceiver, bool>> exp, string orderBy, string orderDir = "desc");
    }
}
