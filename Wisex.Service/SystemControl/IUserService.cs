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
    public interface IUserService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Result<UserModel> Login(UserModel dto);

        /// <summary>
        /// 用户退出
        /// </summary>
        void Logout();

        /// <summary>
        /// 获取我的菜单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<Menu> GetMyMenus(int userId);

        /// <summary>
        /// 获取我的角色
        /// </summary>
        /// <param name="query"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        ResultModel<Role> GetMyRoles(QueryBase query, int userId);

        /// <summary>
        /// 获取我尚未拥有的权限
        /// </summary>
        /// <param name="query"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        ResultModel<Role> GetNotMyRoles(QueryBase query, int userId);


        /// <summary>
		/// 添加user
		/// </summary>
		/// <param name="user">user实体</param>
		/// <returns></returns>
		bool Add(UserModel user);

        /// <summary>
        /// 批量添加user
        /// </summary>
        /// <param name="models">user集合</param>
        /// <returns></returns>
        bool Add(List<UserModel> models);

        /// <summary>
        /// 编辑user
        /// </summary>
        /// <param name="user">实体</param>
        /// <returns></returns>
        bool Update(UserModel user);

        /// <summary>
        /// 批量更新user
        /// </summary>
        /// <param name="users">user实体集合</param>
        /// <returns></returns>
        bool Update(IEnumerable<UserModel> users);

        /// <summary>
        /// 删除user
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        bool Delete(List<int> ids);

        /// <summary>
        /// 批量删除user
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        bool Delete(Expression<Func<UserModel, bool>> exp);

        /// <summary>
        ///  获取单条符合条件的 user 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        UserModel GetOne(Hashtable param);

        /// <summary>
        /// 查询符合调价的 user
        /// </summary>
        /// <param name="exp">过滤条件</param>
        /// <param name="orderExp">排序条件</param>
        /// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        ResultModel<UserModel> GetWithPages(QueryBase queryBase, string orderBy, string orderDir = "desc");

   }
}
