using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wisex.Entity.CommonModel;
using Wisex.Entity.Models;

namespace Wisex.Dao.SystemControl
{
    public class LoginLogDao : BaseDao, ILoginLogDao
    {
        public bool Add(List<LoginLog> models)
        {
            throw new NotImplementedException();
        }

        public bool Add(LoginLog loginlog)
        {
            base.Add("CreateLoginLog", loginlog);
            return true;
        }

        public bool Delete(LoginLog exp)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public LoginLog GetOne(LoginLog exp)
        {
            throw new NotImplementedException();
        }

        public ResultModel<LoginLog> GetWithPages(QueryBase queryBase, LoginLog exp, string orderBy, string orderDir = "desc")
        {
            throw new NotImplementedException();
        }

        public ResultModel<LoginLog> GetWithPages<OrderKeyType>(QueryBase queryBase, LoginLog exp, LoginLog orderExp, bool isDesc = true)
        {
            throw new NotImplementedException();
        }

        public List<LoginLog> Query<OrderKeyType>(LoginLog exp, LoginLog orderExp, bool isDesc = true)
        {
            throw new NotImplementedException();
        }

        public bool Update(IEnumerable<LoginLog> loginlogs)
        {
            throw new NotImplementedException();
        }

        public bool Update(LoginLog loginlog)
        {
            throw new NotImplementedException();
        }
    }
}
