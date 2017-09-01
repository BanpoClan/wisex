using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wisex.Core.Extentions;
using Wisex.Core.StructureMapWapperUtils;
using Wisex.Entity.CommonModel;
using Wisex.Service.Services;

namespace Wisex.Areas.Admin.Controllers.CustomizeFunc
{
    public class CustomizeController : AdminBaseController
    {
        public IBaseService baseService { get; set; }

        public CustomizeController()
        {
            baseService = StructureMapWapper.GetInstance<IBaseService>();
        }
        // GET: Admin/Customize
        public ActionResult Index()
        {
            //列头
            ViewBag.HeaderTh = new List<string>();
            ViewBag.HeaderTh.Add("测试1");
            ViewBag.HeaderTh.Add("测试2");
            ViewBag.HeaderTh.Add("测试3");
            ViewBag.HeaderTh.Add("测试4");

            ViewBag.Cols = new List<string>();
            ViewBag.Cols.Add("测试1");
            ViewBag.Cols.Add("测试2");
            ViewBag.Cols.Add("测试3");
            ViewBag.Cols.Add("测试4");
            return View();
        }


        [HttpGet]
        public JsonResult GetList(string moudleId, string menuId, string btnId, string id)
        {
            var queryBase = new QueryBase
            {
                MenuId= menuId,
                StartIndex = Request["start"].ToInt(),
                PageSize = Request["length"].ToInt(),
                Draw = Request["draw"].ToInt(),
                Keywords = Request["keywords"]
            };
           

            var dto = baseService.GetWithPages<string,Hashtable>(queryBase, Request["orderBy"], Request["orderDir"]);
            return Json(dto, JsonRequestBehavior.AllowGet);
        }
    }
}