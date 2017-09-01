using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Wisex.Core.RedisUtils;
using Wisex.Core.StructureMapWapperUtils;
using Wisex.Dao.SystemControl;
using Wisex.Entity.CommonModel;
using Wisex.Entity.Models;

namespace Wisex.Service.SystemControl
{
    public class MenuService : IMenuService
    {
        private IMenuDao menuDao = null;

        public MenuService()
        {
            menuDao = StructureMapWapper.GetInstance<IMenuDao>();
        }

        public bool Add(List<Menu> models)
        {
            throw new NotImplementedException();
        }

        public bool Add(Menu menu)
        {
           
            menuDao.Add(menu);
            return true;
        }

        public bool Delete(List<int> ids)
        {
            return menuDao.Delete(ids);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        //public Menu GetOne(Expression<Func<Menu, bool>> exp)
        //{
        //    throw new NotImplementedException();
        //}

        public Menu GetOne(Hashtable param)
        {
            return menuDao.GetOne(param);
        }


        public ResultModel<Menu> GetWithPages(QueryBase queryBase, string orderBy, string orderDir = "desc")
        {
            return menuDao.GetWithPages(queryBase, orderBy, orderDir);
        }

        public ResultModel<Menu> GetWithPages(QueryBase queryBase, Expression<Func<Menu, bool>> exp, string orderBy, string orderDir = "desc")
        {
            throw new NotImplementedException();
        }

        public ResultModel<Menu> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<Menu, bool>> exp, Expression<Func<Menu, OrderKeyType>> orderExp, bool isDesc = true)
        {
            throw new NotImplementedException();
        }

        public List<Menu> Query(string exp, string orderExp, bool isDesc = true)
        {
            return menuDao.Query(exp, orderExp, isDesc = true);
        }

       

        public bool Update(IEnumerable<Menu> menus)
        {
            throw new NotImplementedException();
        }

        public bool Update(Menu menu)
        {
            return menuDao.Update(menu);
        }
    }
}
