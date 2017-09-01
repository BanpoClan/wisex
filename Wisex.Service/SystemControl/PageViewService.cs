using System;
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
    public class PageViewService : IPageViewService
    {
        private IPageViewDao pageViewDao = null;
        public PageViewService()
        {
            pageViewDao = StructureMapWapper.GetInstance<IPageViewDao>();
        }


        public bool Add(List<PageView> models)
        {
            throw new NotImplementedException();
        }

        public bool Add(PageView pageview)
        {
            return pageViewDao.Add(pageview);
        }

        public bool Delete(Expression<Func<PageView, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PageView GetOne(Expression<Func<PageView, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public ResultModel<PageView> GetWithPages(QueryBase queryBase, Expression<Func<PageView, bool>> exp, string orderBy, string orderDir = "desc")
        {
            throw new NotImplementedException();
        }

        public ResultModel<PageView> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<PageView, bool>> exp, Expression<Func<PageView, OrderKeyType>> orderExp, bool isDesc = true)
        {
            throw new NotImplementedException();
        }

        public List<PageView> Query<OrderKeyType>(Expression<Func<PageView, bool>> exp, Expression<Func<PageView, OrderKeyType>> orderExp, bool isDesc = true)
        {
            throw new NotImplementedException();
        }

        public bool Update(IEnumerable<PageView> pageviews)
        {
            throw new NotImplementedException();
        }

        public bool Update(PageView pageview)
        {
            throw new NotImplementedException();
        }
    }
}
