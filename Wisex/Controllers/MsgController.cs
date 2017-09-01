using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wisex.Controllers
{
    public class MsgController : Controller
    {
        // GET: Msg
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendMessage()
        {
            return View();
        }

        public ActionResult ReceiveMessage()
        {
            return View();
        }

        [HttpPost]
        public JsonResult MsgCount()
        {
            var count = "返回值----" + Guid.NewGuid();
            return Json(new { count = count }, JsonRequestBehavior.AllowGet);
        }
    }
}