using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wisex.Entity.CommonModel;
using Wisex.Entity.Models;

namespace Wisex.Dao.SystemControl
{
    public interface ILoginLogDao
    {
        /// <summary>
		/// 添加loginlog
		/// </summary>
		/// <param name="loginlog">loginlog实体</param>
		/// <returns></returns>
		bool Add(LoginLog loginlog);

        /// <summary>
        /// 批量添加loginlog
        /// </summary>
        /// <param name="models">loginlog集合</param>
        /// <returns></returns>
        bool Add(List<LoginLog> models);

        /// <summary>
        /// 编辑loginlog
        /// </summary>
        /// <param name="loginlog">实体</param>
        /// <returns></returns>
        bool Update(LoginLog loginlog);

        /// <summary>
        /// 批量更新loginlog
        /// </summary>
        /// <param name="loginlogs">loginlog实体集合</param>
        /// <returns></returns>
        bool Update(IEnumerable<LoginLog> loginlogs);

        /// <summary>
        /// 删除loginlog
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// 批量删除loginlog
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        bool Delete(LoginLog exp);

        /// <summary>
        ///  获取单条符合条件的 loginlog 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        LoginLog GetOne(LoginLog exp);

        /// <summary>
        /// 查询符合调价的 loginlog
        /// </summary>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        List<LoginLog> Query<OrderKeyType>(LoginLog exp, LoginLog orderExp, bool isDesc = true);

        /// <summary>
        /// 分页获取loginlog
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        ResultModel<LoginLog> GetWithPages<OrderKeyType>(QueryBase queryBase, LoginLog exp, LoginLog orderExp, bool isDesc = true);

        /// <summary>
        /// 分页获取loginlog
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderBy">排序条件</param>
		/// <param name="orderDir">是否是降序排列</param>
        /// <returns></returns>
        ResultModel<LoginLog> GetWithPages(QueryBase queryBase, LoginLog exp, string orderBy, string orderDir = "desc");
    }
}
