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
    public interface IMenuService
    {
        /// <summary>
		/// 添加menu
		/// </summary>
		/// <param name="menu">menu实体</param>
		/// <returns></returns>
		bool Add(Menu menu);

        /// <summary>
        /// 批量添加menu
        /// </summary>
        /// <param name="models">menu集合</param>
        /// <returns></returns>
        bool Add(List<Menu> models);

        /// <summary>
        /// 编辑menu
        /// </summary>
        /// <param name="menu">实体</param>
        /// <returns></returns>
        bool Update(Menu menu);

        /// <summary>
        /// 批量更新menu
        /// </summary>
        /// <param name="menus">menu实体集合</param>
        /// <returns></returns>
        bool Update(IEnumerable<Menu> menus);

        /// <summary>
        /// 删除menu
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// 批量删除menu
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        bool Delete(List<int> ids);

        /// <summary>
        /// 通过字典参数查询
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        Menu GetOne(Hashtable param);

        /// <summary>
        /// 通过ibatis查询数据
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="orderExp"></param>
        /// <param name="isDesc"></param>
        /// <returns></returns>
        List<Menu> Query(string exp, string orderExp, bool isDesc = true);


        /// <summary>
        /// ibatis查询
        /// </summary>
        /// <param name="queryBase"></param>
        /// <param name="orderBy"></param>
        /// <param name="orderDir"></param>
        /// <returns></returns>
        ResultModel<Menu> GetWithPages(QueryBase queryBase, string orderBy, string orderDir = "desc");
    }
}
