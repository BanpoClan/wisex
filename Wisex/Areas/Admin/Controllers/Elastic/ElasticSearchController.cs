using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wisex.Core.StructureMapWapperUtils;
using Wisex.Service.ESServices;

namespace Wisex.Areas.Admin.Controllers.Elastic
{
    public class ElasticSearchController : Controller
    {
        public IESService esService { get; set; }

        public ElasticSearchController()
        {
            esService = StructureMapWapper.GetInstance<IESService>();
        }
        // GET: Admin/ElasticSearch
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetList()
        {
            var query = string.IsNullOrEmpty(Request["keywords"])? "教育咨询": Request["keywords"];

            var data = esService.Query(query);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}