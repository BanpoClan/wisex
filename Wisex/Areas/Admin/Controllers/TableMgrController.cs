using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wisex.Core.Extentions;
using Wisex.Core.StructureMapWapperUtils;
using Wisex.Entity.CommonModel;
using Wisex.Entity.Models;
using Wisex.Service.Services;

namespace Wisex.Areas.Admin.Controllers
{
    public class TableMgrController : AdminBaseController
    {
        public IBaseService baseService { get; set; }

        public TableMgrController()
        {
            baseService = StructureMapWapper.GetInstance<IBaseService>();
        }

        #region Page
        // GET: Adm/Menu
        public ActionResult Index(int moudleId, int menuId, int btnId)
        {
            GetButtons(menuId);
            return View();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public ActionResult Add(int moudleId, int menuId, int btnId)
        {
            return View();
        }

        public ActionResult Edit(int moudleId, int menuId, int btnId, int id)
        {
            var model = baseService.GetOne<SystemObjectSummary>(id);
            return View(model);
        }

        #endregion

        #region Ajax
        //public ActionResult Add(FormCollection fc)
       
        [HttpPost]
        public ActionResult Add(string moudleId, string menuId, string btnId, SystemObjectSummary dto)
        {
            baseService.Add(dto);
            return RedirectToAction("Index", RouteData.Values);
        }


        [HttpPost]
        public ActionResult Edit(string moudleId, string menuId, string btnId, SystemObjectSummary dto)
        {
            baseService.Update(dto);
            return RedirectToAction("Index", RouteData.Values);
        }


        [HttpPost]
        public JsonResult Delete(string moudleId, string menuId, string btnId, List<int> ids)
        {
            var res = new Result<string>();

            if (ids != null && ids.Any())
                res.flag = baseService.Delete<SystemObjectSummary>(ids);

            return Json(res, JsonRequestBehavior.AllowGet);
        }



        [HttpGet]
        public JsonResult GetList(string moudleId, string menuId, string btnId, string id)
        {
            var queryBase = new QueryBase
            {
                StartIndex = Request["start"].ToInt(),
                PageSize = Request["length"].ToInt(),
                Draw = Request["draw"].ToInt(),
                Keywords = Request["keywords"]
            };
            var dto = baseService.GetWithPages<string,SystemObjectSummary>(queryBase, Request["orderBy"], Request["orderDir"]);
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

       

        #endregion
    }
}