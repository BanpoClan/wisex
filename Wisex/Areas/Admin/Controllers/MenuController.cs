using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using Wisex.Common.Enums;
using Wisex.Core.Extentions;
using Wisex.Entity.CommonModel;
using Wisex.Entity.Models;

namespace Wisex.Areas.Admin.Controllers
{
    public class MenuController : AdminBaseController
    {

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
            ViewBag.ParentMenu = menuService.Query(" dbo.Menu.IsDeleted='false' AND Menu.[Type]<>3 "," order by id ",false);
            return View();
        }

        public ActionResult Edit(int moudleId, int menuId, int btnId, int id)
        {
            ViewBag.ParentMenu = menuService.Query(" dbo.Menu.IsDeleted='false' AND Menu.[Type]<>3 ", " order by id ",
               false);
            var param = new Hashtable();
            param.Add("Id", id);
            var model = menuService.GetOne(param);
            return View(model);
        }

        #endregion

        #region Ajax

        [HttpPost]
        public ActionResult Add(string moudleId, string menuId, string btnId, Menu dto)
        {
            SetMenuType(ref dto);
            menuService.Add(dto);
            return RedirectToAction("Index", RouteData.Values);
        }


        [HttpPost]
        public ActionResult Edit(string moudleId, string menuId, string btnId, Menu dto)
        {
            SetMenuType(ref dto);
            menuService.Update(dto);
            return RedirectToAction("Index", RouteData.Values);
        }


        [HttpPost]
        public JsonResult Delete(string moudleId, string menuId, string btnId, List<int> ids)
        {
            var res = new Result<string>();

            if (ids != null && ids.Any())
                res.flag = menuService.Delete(ids);

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        

        [HttpGet]
        public JsonResult GetList(string moudleId, string menuId, string btnId,string id)
        {
            //var parentId = id.ToInt();
            //var list = menuService.Query(item => !item.IsDeleted && item.ParentId == parentId, item => item.Id);
            //var dtos = new List<Menu>();
            //list.ForEach(item =>
            //{
            //    var dto = new Menu
            //    {
            //        id = item.Id.ToString(),
            //        name = item.Name,
            //        type = "folder",
            //        additionalParameters = new AdditionalParameters {id = item.Id.ToString()}
            //    };
            //    dtos.Add(dto);
            //});

            //return Json(dtos, JsonRequestBehavior.AllowGet);

            var queryBase = new QueryBase
            {
                StartIndex = Request["start"].ToInt(),
                PageSize = Request["length"].ToInt(),
                Draw = Request["draw"].ToInt(),
                Keywords = Request["keywords"]
            };
            Expression<Func<Menu, bool>> exp = item => !item.IsDeleted;
            if (!queryBase.Keywords.IsBlank())
                exp = exp.And(item => item.Name.Contains(queryBase.Keywords));
            
            var dto = menuService.GetWithPages(queryBase,  Request["orderBy"], Request["orderDir"]);
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        void SetMenuType(ref Menu dto)
        {
            var parentId = dto.ParentId;
            var param = new Hashtable();
            param.Add("Id", parentId);
            var parent = menuService.GetOne(param);
            if (parentId<=0|| parent==null)
                dto.Type = MenuType.模块;
            else
            {
                switch (parent.Type)
                {
                    case MenuType.模块:
                        dto.Type = MenuType.菜单;
                        break;
                    case MenuType.菜单:
                        dto.Type = MenuType.按钮;
                        break;
                }
            }
        }

        #endregion
    }

    //public class Menu
    //{
    //    public string id { get; set; }

    //    public string name { get; set; }

    //    public string type { get; set; }

    //    public AdditionalParameters additionalParameters { get; set; }
    //}

    //public class AdditionalParameters
    //{
    //    public string id { get; set; }

    //    public bool children { get; set; }

    //    public bool itemSelected { get; set; }
    //}
}