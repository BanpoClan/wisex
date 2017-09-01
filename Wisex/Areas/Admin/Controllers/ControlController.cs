using System.Web.Mvc;
using Wisex.Core.StructureMapWapperUtils;
using Wisex.Service.SystemControl;

namespace Wisex.Areas.Admin.Controllers
{
    public class ControlController : AdminBaseController
    {

        public IRoleMenuService roleMenuService { get; set; }

        public IUserRoleService userRoleService { get; set; }

        public ControlController()
        {
            roleMenuService = StructureMapWapper.GetInstance<IRoleMenuService>();
            userRoleService = StructureMapWapper.GetInstance<IUserRoleService>();
        }

        // GET: Adm/Control
        public ActionResult Index()
        {
            if (IsLogined)
            {
                //获取拥有的角色
                var userid = CurrentUser.Id;
                
                ViewBag.MyMenus = userService.GetMyMenus(userid);
            }
            return View();
        }

        /// <summary>
        /// Welcome
        /// </summary>
        /// <returns></returns>
        public ActionResult Welcome()
        {
            return View();
        }
    }
}