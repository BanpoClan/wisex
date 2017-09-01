using System.Web;
using System.Web.Mvc;
using Wisex.Web;

namespace Wisex
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new CommonExceptionFilter());
            filters.Add(new AuthFilter());
        }
    }
}
