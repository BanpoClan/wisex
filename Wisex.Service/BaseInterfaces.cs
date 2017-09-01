using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wisex.Entity.CommonModel;

namespace Wisex.Service
{
    public interface BaseInterfaces
    {
        bool Add<T>(T t) ;
        bool Update<T>(T t);
        bool Delete<T>(int id);
        bool Delete<T>(List<int> ids);
        T GetOne<T>(int id);
        List<T> GetList<T>();
        /// <summary>
        /// K 是参数  T是返回值
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryBase"></param>
        /// <param name="orderBy"></param>
        /// <param name="orderDir"></param>
        /// <returns></returns>
        ResultModel<T> GetWithPages<K, T>(QueryBase queryBase, string orderBy, string orderDir = "desc") ;
    }
}
