
using System.Web.Mvc;
using System.Web.Security;

namespace Wisex.Web
{
    /// <summary>
    /// 身份认证过滤器
    /// </summary>
    public class AuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool isAnoy = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) ||
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);

            var identity = filterContext.HttpContext.User.Identity;

            if (!isAnoy && !identity.IsAuthenticated)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    var result = new
                    {
                        flag = false,
                        data = string.Empty,
                        msg = "请登录"
                    };
                    filterContext.Result = new JsonResult
                    {
                        Data = result,
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else
                {
                    //string returnUrl = filterContext.HttpContext.Request.Url.AbsolutePath;
                    FormsAuthentication.RedirectToLoginPage();
                }
            }
        }
    }
}
