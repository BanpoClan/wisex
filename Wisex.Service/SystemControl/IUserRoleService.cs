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
    public interface IUserRoleService
    {
        /// <summary>
		/// 添加userrole
		/// </summary>
		/// <param name="userrole">userrole实体</param>
		/// <returns></returns>
		bool Add(UserRole userrole);

        /// <summary>
        /// 批量添加userrole
        /// </summary>
        /// <param name="models">userrole集合</param>
        /// <returns></returns>
        bool Add(List<UserRole> models);

        /// <summary>
        /// 编辑userrole
        /// </summary>
        /// <param name="userrole">实体</param>
        /// <returns></returns>
        bool Update(UserRole userrole);

        /// <summary>
        /// 批量更新userrole
        /// </summary>
        /// <param name="userroles">userrole实体集合</param>
        /// <returns></returns>
        bool Update(IEnumerable<UserRole> userroles);

        /// <summary>
        /// 删除userrole
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// 批量删除userrole
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        bool Delete(Expression<Func<UserRole, bool>> exp);

        /// <summary>
        ///  获取单条符合条件的 userrole 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        UserRole GetOne(Expression<Func<UserRole, bool>> exp);

        /// <summary>
        /// 查询符合调价的 userrole
        /// </summary>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        List<UserRole> Query<OrderKeyType>(Expression<Func<UserRole, bool>> exp, Expression<Func<UserRole, OrderKeyType>> orderExp, bool isDesc = true);

        /// <summary>
        /// 分页获取userrole
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        ResultModel<UserRole> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<UserRole, bool>> exp, Expression<Func<UserRole, OrderKeyType>> orderExp, bool isDesc = true);

        /// <summary>
        /// 分页获取userrole
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderBy">排序条件</param>
		/// <param name="orderDir">是否是降序排列</param>
        /// <returns></returns>
        ResultModel<UserRole> GetWithPages(QueryBase queryBase, Expression<Func<UserRole, bool>> exp, string orderBy, string orderDir = "desc");
    }
}
