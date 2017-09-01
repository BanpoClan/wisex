using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wisex.Core.StructureMapWapperUtils;
using Wisex.Dao.SystemControl;
using Wisex.Entity.CommonModel;
using Wisex.Entity.Models;

namespace Wisex.Service.SystemControl
{
    public class RoleMenuService : IRoleMenuService
    {
        private IRoleMenuDao roleMenuDao = null;

        public RoleMenuService()
        {
            roleMenuDao = StructureMapWapper.GetInstance<IRoleMenuDao>();
        }

        public bool Add(List<RoleMenu> models)
        {
            throw new NotImplementedException();
        }

        public bool Add(RoleMenu rolemenu)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Expression<Func<RoleMenu, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public RoleMenu GetOne(Expression<Func<RoleMenu, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public ResultModel<RoleMenu> GetWithPages(QueryBase queryBase, Expression<Func<RoleMenu, bool>> exp, string orderBy, string orderDir = "desc")
        {
            throw new NotImplementedException();
        }

        public ResultModel<RoleMenu> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<RoleMenu, bool>> exp, Expression<Func<RoleMenu, OrderKeyType>> orderExp, bool isDesc = true)
        {
            throw new NotImplementedException();
        }

        public List<RoleMenu> Query(string exp, string orderExp, bool isDesc = true)
        {
            return roleMenuDao.Query( exp,  orderExp,  isDesc = true);
        }

        public bool Update(IEnumerable<RoleMenu> rolemenus)
        {
            throw new NotImplementedException();
        }

        public bool Update(RoleMenu rolemenu)
        {
            throw new NotImplementedException();
        }
    }
}
