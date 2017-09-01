using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Wisex.Common.Enums;
using Wisex.Core;
using Wisex.Core.StructureMapWapperUtils;
using Wisex.Entity.Models;
using Wisex.Service.SystemControl;

namespace Wisex.Areas.Admin.Controllers
{
    /// <summary>
    /// AdmBase
    /// </summary>
    public class AdminBaseController : Controller
    {
        public IPageViewService pageViewService { get; set; }

        public IMenuService menuService { get; set; }

        public IUserService userService { get; set; }

        /// <summary>
        /// 当前登录用户
        /// </summary>
        protected UserModel CurrentUser { get; private set; }

        /// <summary>
        /// 是否登录
        /// </summary>
        protected bool IsLogined { get; set; }

        public AdminBaseController()
        {
            userService = StructureMapWapper.GetInstance<IUserService>();
            pageViewService = StructureMapWapper.GetInstance<IPageViewService>();
            menuService = StructureMapWapper.GetInstance<IMenuService>();
        }



        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="requestContext"></param>
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            // TODO
            //用户信息处理
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity as FormsIdentity;
                CurrentUser = new UserModel
                {
                    Id = Convert.ToInt32(user.Ticket.UserData),
                    LoginName = User.Identity.Name
                };
            }

            IsLogined = CurrentUser != null && CurrentUser.Id > 0;

            ViewRecord(requestContext);
        }

        /// <summary>
        /// 访问记录
        /// </summary>
        /// <param name="_context"></param>
        void ViewRecord(RequestContext _context)
        {
            try
            {
                var dto = new PageView
                {
                    UserId = IsLogined ? CurrentUser.Id : 0,
                    LoginName = IsLogined ? CurrentUser.LoginName : string.Empty,
                    Url = _context.HttpContext.Request.Url.PathAndQuery.ToLower(),
                    IP = WebHelper.GetClientIP()
                };
                pageViewService.Add(dto);
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 获取指定菜单下的按钮
        /// </summary>
        /// <param name="parentId"></param>
        protected virtual void GetButtons(int parentId)
        {
            //获取我的角色
            var userId = CurrentUser.Id;
            var myMenus = userService.GetMyMenus(userId);

            ViewBag.MyButtons = myMenus.Where(item => item.ParentId == parentId && item.Type == MenuType.按钮)
                .OrderBy(item => item.Id)
                .ToList();
        }
    }
}