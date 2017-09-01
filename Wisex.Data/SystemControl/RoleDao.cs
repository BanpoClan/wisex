using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wisex.Entity.CommonModel;
using Wisex.Entity.Models;

namespace Wisex.Dao.SystemControl
{
    public class RoleDao : BaseDao, IRoleDao
    {
        public void Add(Role role)
        {
            var fields = this.GetSystemObjectFields<Role>();
            base.CustomAdd<Role>(role, fields);
        }
        public bool Update(Role role)
        {
            var fields = this.GetSystemObjectFields<Role>();
            base.CustomUpdate<Role>(role, fields);
            return true;
        }
        public bool Delete(List<int> ids)
        {
            if (base.CustomDelete<Role>(ids) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Role GetOne(int id)
        {
            return base.GetOne<Role>(id);
        }

        public ResultModel<Role> GetWithPages(QueryBase queryBase, string orderBy, string orderDir = "desc")
        {
            return base.GetWithPages<Role>(queryBase, orderBy, orderDir);
        }

        public List<Role> Query(string exp, string orderExp, bool isDesc = true)
        {
            throw new NotImplementedException();
        }

        
    }
}
