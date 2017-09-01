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
    public interface IRoleMenuService
    {
        /// <summary>
		/// 添加rolemenu
		/// </summary>
		/// <param name="rolemenu">rolemenu实体</param>
		/// <returns></returns>
		bool Add(RoleMenu rolemenu);

        /// <summary>
        /// 批量添加rolemenu
        /// </summary>
        /// <param name="models">rolemenu集合</param>
        /// <returns></returns>
        bool Add(List<RoleMenu> models);

        /// <summary>
        /// 编辑rolemenu
        /// </summary>
        /// <param name="rolemenu">实体</param>
        /// <returns></returns>
        bool Update(RoleMenu rolemenu);

        /// <summary>
        /// 批量更新rolemenu
        /// </summary>
        /// <param name="rolemenus">rolemenu实体集合</param>
        /// <returns></returns>
        bool Update(IEnumerable<RoleMenu> rolemenus);

        /// <summary>
        /// 删除rolemenu
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// 批量删除rolemenu
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        bool Delete(Expression<Func<RoleMenu, bool>> exp);

        /// <summary>
        ///  获取单条符合条件的 rolemenu 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        RoleMenu GetOne(Expression<Func<RoleMenu, bool>> exp);

        /// <summary>
        /// 查询符合调价的 rolemenu
        /// </summary>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        List<RoleMenu> Query(string exp, string orderExp, bool isDesc = true);

        /// <summary>
        /// 分页获取rolemenu
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        ResultModel<RoleMenu> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<RoleMenu, bool>> exp, Expression<Func<RoleMenu, OrderKeyType>> orderExp, bool isDesc = true);

        /// <summary>
        /// 分页获取rolemenu
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderBy">排序条件</param>
		/// <param name="orderDir">是否是降序排列</param>
        /// <returns></returns>
        ResultModel<RoleMenu> GetWithPages(QueryBase queryBase, Expression<Func<RoleMenu, bool>> exp, string orderBy, string orderDir = "desc");
    }
}
