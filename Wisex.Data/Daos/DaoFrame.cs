using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wisex.Entity.CommonModel;

namespace Wisex.Dao.Daos
{
    public class DaoFrame : BaseDao, IDaoFrame
    {
        public bool Add<T>(T t) 
        {
            var fields = this.GetSystemObjectFields<T>();
            base.CustomAdd<T>(t, fields);
            return true;
        }

        public bool Delete<T>(List<int> ids)
        {
            base.CustomDelete<T>(ids);
            return true;
        }

        public bool Delete<T>(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetList<T>()
        {
            throw new NotImplementedException();
        }

        public bool Update<T>(T t) 
        {
            var fields = this.GetSystemObjectFields<T>();
            base.CustomUpdate<T>(t, fields);
            return true;
        }
    }
}
