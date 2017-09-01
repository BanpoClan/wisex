using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wisex.Entity.Models;

namespace Wisex.Dao.SystemControl
{
    public interface IRoleMenuDao
    {
        List<RoleMenu> Query(string exp, string orderExp, bool isDesc = true);
    }
}
