using System;
using System.Collections;
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
    public class RoleService : IRoleService
    {
        private IRoleDao roleDao = null;

        public RoleService()
        {
            roleDao = StructureMapWapper.GetInstance<IRoleDao>();
        }



        public bool Add(List<Role> models)
        {
            throw new NotImplementedException();
        }

        public bool Add(Role role)
        {
            roleDao.Add(role);
            return true;
        }

        public bool Delete(Expression<Func<Role, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public bool Delete(List<int> ids)
        {
            return roleDao.Delete(ids);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Role GetOne(int id)
        {
            return roleDao.GetOne(id);
        }

        public ResultModel<Role> GetWithPages(QueryBase queryBase, string orderBy, string orderDir = "desc")
        {
            return roleDao.GetWithPages(queryBase, orderBy, orderDir);
        }

        public List<Role> Query<OrderKeyType>(Expression<Func<Role, bool>> exp, Expression<Func<Role, OrderKeyType>> orderExp, bool isDesc = true)
        {
            throw new NotImplementedException();
        }

        public bool Update(IEnumerable<Role> roles)
        {
            throw new NotImplementedException();
        }

        public bool Update(Role role)
        {
            return roleDao.Update(role);
        }
    }
}
