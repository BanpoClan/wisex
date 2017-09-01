using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wisex.Entity.CommonModel;
using Wisex.Entity.Models;

namespace Wisex.Service.SystemControl
{
    public interface ILoginLogService
    {
        ResultModel<UserModel> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<UserModel, bool>> exp, Expression<Func<UserModel, OrderKeyType>> orderExp, bool isDesc = true);
    }
}
