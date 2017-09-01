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
    public interface IUserDao
    {
        List<Menu> GetMenu(int userId);

        UserModel GetOne(string loginName);
        UserModel GetOne(Hashtable param);
        ResultModel<UserModel> GetWithPages(QueryBase queryBase, string orderBy, string orderDir = "desc");
        bool Add(UserModel user);
        bool Delete(List<int> ids);
        bool Update(UserModel user);
    }


}
