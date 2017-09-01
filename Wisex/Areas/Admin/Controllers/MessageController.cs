using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wisex.Areas.Admin.Controllers
{
    public class MessageController : Controller
    {
        // GET: Admin/Message
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetList()
        {
            //var dto = menuService.GetWithPages(queryBase, Request["orderBy"], Request["orderDir"]);
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}