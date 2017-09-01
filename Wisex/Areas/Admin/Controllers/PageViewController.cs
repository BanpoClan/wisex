using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using Wisex.Core.Extentions;
using Wisex.Entity.CommonModel;
using Wisex.Entity.Models;

namespace Wisex.Areas.Admin.Controllers
{
    public class PageViewController : AdminBaseController
    {

        #region Page

        // GET: Adm/PageView
        public ActionResult Index(int moudleId, int menuId, int btnId)
        {
            return View();
        }

        #endregion

        #region Ajax

        public JsonResult GetList(int moudleId, int menuId, int btnId)
        {
            var queryBase = new QueryBase
            {
                StartIndex = Request["start"].ToInt(),
                PageSize = Request["length"].ToInt(),
                Draw = Request["draw"].ToInt(),
                Keywords = Request["keywords"]
            };
            Expression<Func<PageView, bool>> exp = item => !item.IsDeleted;
            if (!queryBase.Keywords.IsBlank())
                exp = exp.And(item => item.LoginName.Contains(queryBase.Keywords));

            var dto = pageViewService.GetWithPages(queryBase, exp, Request["orderBy"], Request["orderDir"]);
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}