using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using Wisex.Core.Extentions;
using Wisex.Entity.CommonModel;
using Wisex.Entity.Models;
using Wisex.Service.SystemControl;

namespace Wisex.Areas.Admin.Controllers
{
    public class LoginlogController : AdminBaseController
    {
        public ILoginLogService loginLogService { set; get; }

        #region Page

        // GET: Adm/LoginLog
        public ActionResult Index(string moudleId, string menuId, string btnId)
        {
            return View();
        }

        #endregion

        #region Ajax

        public JsonResult GetList(string moudleId, string menuId, string btnId)
        {
            var queryBase = new QueryBase
            {
                StartIndex = Request["start"].ToInt(),
                PageSize = Request["length"].ToInt(),
                Draw = Request["draw"].ToInt(),
                Keywords = Request["keywords"]
            };
            Expression<Func<LoginLog, bool>> exp = item => !item.IsDeleted;
            if (!queryBase.Keywords.IsBlank())
                exp = exp.And(item => item.LoginName.Contains(queryBase.Keywords));

            var dto = new ResultModel<UserModel>(); //loginLogService.GetWithPages(queryBase, exp, Request["orderBy"], Request["orderDir"]);
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}