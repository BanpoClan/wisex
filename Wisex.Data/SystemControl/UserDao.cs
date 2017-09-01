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
    public class UserDao : BaseDao, IUserDao
    {
        public bool Add(UserModel user)
        {
            user.UserGuid = Guid.NewGuid().ToString();
            var fields = this.GetSystemObjectFields<UserModel>();
            base.CustomAdd<UserModel>(user, fields);
            return true;
        }

        public bool Delete(List<int> ids)
        {
            if (base.CustomDelete<UserModel>(ids) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Menu> GetMenu(int userId)
        {
            var para = new Hashtable();
            para.Add("UserId", userId);
            return base.QueryForList<Menu>("GetMenus", para);
        }

        public UserModel GetOne(Hashtable param)
        {
            return base.QueryForObject<UserModel>("GetOneUser", param);
        }

        public UserModel GetOne(string loginName)
        {
            var para = new Hashtable();
            para.Add("loginName", loginName);
            return base.QueryForObject<UserModel>("Loginsys", para);
        }

        public ResultModel<UserModel> GetWithPages(QueryBase queryBase, string orderBy, string orderDir = "desc")
        {
            return base.GetWithPages<UserModel>(queryBase, orderBy, orderDir);
        }

        public bool Update(UserModel user)
        {
            var fields = this.GetSystemObjectFields<UserModel>();
            base.CustomUpdate<UserModel>(user, fields);
            return true;
        }
    }
}
