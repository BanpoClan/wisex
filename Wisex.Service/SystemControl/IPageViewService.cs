using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wisex.Dao.SystemControl;
using Wisex.Entity.CommonModel;
using Wisex.Entity.Models;

namespace Wisex.Service.SystemControl
{
    public interface IPageViewService
    {
        
        /// <summary>
		/// 添加pageview
		/// </summary>
		/// <param name="pageview">pageview实体</param>
		/// <returns></returns>
		bool Add(PageView pageview);

        /// <summary>
        /// 批量添加pageview
        /// </summary>
        /// <param name="models">pageview集合</param>
        /// <returns></returns>
        bool Add(List<PageView> models);

        /// <summary>
        /// 编辑pageview
        /// </summary>
        /// <param name="pageview">实体</param>
        /// <returns></returns>
        bool Update(PageView pageview);

        /// <summary>
        /// 批量更新pageview
        /// </summary>
        /// <param name="pageviews">pageview实体集合</param>
        /// <returns></returns>
        bool Update(IEnumerable<PageView> pageviews);

        /// <summary>
        /// 删除pageview
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// 批量删除pageview
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        bool Delete(Expression<Func<PageView, bool>> exp);

        /// <summary>
        ///  获取单条符合条件的 pageview 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        PageView GetOne(Expression<Func<PageView, bool>> exp);

        /// <summary>
        /// 查询符合调价的 pageview
        /// </summary>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        List<PageView> Query<OrderKeyType>(Expression<Func<PageView, bool>> exp, Expression<Func<PageView, OrderKeyType>> orderExp, bool isDesc = true);

        /// <summary>
        /// 分页获取pageview
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        ResultModel<PageView> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<PageView, bool>> exp, Expression<Func<PageView, OrderKeyType>> orderExp, bool isDesc = true);

        /// <summary>
        /// 分页获取pageview
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderBy">排序条件</param>
		/// <param name="orderDir">是否是降序排列</param>
        /// <returns></returns>
        ResultModel<PageView> GetWithPages(QueryBase queryBase, Expression<Func<PageView, bool>> exp, string orderBy, string orderDir = "desc");
    }
}
