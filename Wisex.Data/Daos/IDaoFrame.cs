using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wisex.Entity.CommonModel;

namespace Wisex.Dao.Daos
{
    public interface IDaoFrame
    {
        bool Add<T>(T t) ;
        bool Update<T>(T t) ;
        bool Delete<T>(int id);
        bool Delete<T>(List<int> ids);
        T GetOne<T>(int id);
        List<T> GetList<T>();
        ResultModel<K> GetWithPages<K>(QueryBase queryBase, string orderBy, string orderDir = "desc") ;
    }
}
