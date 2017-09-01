using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wisex.Entity.CommonModel;
using Wisex.Entity.Models;

namespace Wisex.Service.SystemControl
{
    public interface IRoleService
    {
        /// <summary>
		/// 添加role
		/// </summary>
		/// <param name="role">role实体</param>
		/// <returns></returns>
		bool Add(Role role);

        /// <summary>
        /// 批量添加role
        /// </summary>
        /// <param name="models">role集合</param>
        /// <returns></returns>
        bool Add(List<Role> models);

        /// <summary>
        /// 编辑role
        /// </summary>
        /// <param name="role">实体</param>
        /// <returns></returns>
        bool Update(Role role);

        /// <summary>
        /// 批量更新role
        /// </summary>
        /// <param name="roles">role实体集合</param>
        /// <returns></returns>
        bool Update(IEnumerable<Role> roles);

        /// <summary>
        /// 删除role
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// 批量删除role
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        bool Delete(List<int> ids);

        /// <summary>
        ///  获取单条符合条件的 role 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        Role GetOne(int id);

        /// <summary>
        /// 查询符合调价的 role
        /// </summary>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        List<Role> Query<OrderKeyType>(Expression<Func<Role, bool>> exp, Expression<Func<Role, OrderKeyType>> orderExp, bool isDesc = true);

        
        /// <summary>
        /// ibatis查询
        /// </summary>
        /// <param name="queryBase"></param>
        /// <param name="orderBy"></param>
        /// <param name="orderDir"></param>
        /// <returns></returns>
        ResultModel<Role> GetWithPages(QueryBase queryBase, string orderBy, string orderDir = "desc");
    }
}
