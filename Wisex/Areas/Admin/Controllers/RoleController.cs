using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using Wisex.Core.Extentions;
using Wisex.Core.StructureMapWapperUtils;
using Wisex.Entity.CommonModel;
using Wisex.Entity.Models;
using Wisex.Models;
using Wisex.Service.SystemControl;

namespace Wisex.Areas.Admin.Controllers
{
    public class RoleController : AdminBaseController
    {
        public IRoleService roleService { set; get; }

        public IRoleMenuService roleMenuService { get; set; }

        public RoleController()
        {
            roleService=  StructureMapWapper.GetInstance<IRoleService>();
            roleMenuService = StructureMapWapper.GetInstance<IRoleMenuService>();
        }

        

        #region Page

        // GET: Adm/Role
        public ActionResult Index(int moudleId, int menuId, int btnId)
        {
            GetButtons(menuId);
            return View();
        }


        public ActionResult Add(string moudleId, string menuId, string btnId)
        {
            return View();
        }


        public ActionResult Edit(int moudleId, int menuId, int btnId, int id)
        {
            var model = roleService.GetOne(id);
            return View(model);
        }

        public ActionResult AuthMenus(int moudleId, int menuId, int btnId)
        {
            ViewBag.Menus = menuService.Query(" IsDeleted='false' ", " order by id ", false);
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
        
            var dto = roleService.GetWithPages(queryBase, Request["orderBy"], Request["orderDir"]);
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(int moudleId, int menuId, int btnId, Role dto)
        {
            roleService.Add(dto);
            return RedirectToAction("Index", RouteData.Values);
        }

        [HttpPost]
        public ActionResult Edit(int moudleId, int menuId, int btnId, Role dto)
        {
            roleService.Update(dto);
            return RedirectToAction("Index", RouteData.Values);
        }


        [HttpPost]
        public JsonResult Delete(int moudleId, int menuId, int btnId, List<int> ids)
        {
            var res = new Result<string>();

            if (ids != null && ids.Any())
                res.flag = roleService.Delete(ids);

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AuthMenus(int moudleId, int menuId, int btnId, AuthMenu dto)
        {
            var res = new Result<int>();

            foreach (var roleId in dto.RoleIds)
            {
                roleMenuService.Delete(item => item.RoleId == roleId);
                var newRoleMenus = dto.MenuIds.Select(item => new RoleMenu {RoleId = roleId, MenuId = item}).ToList();
                roleMenuService.Add(newRoleMenus);
            }

            res.flag = true;

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetRoleMenusByRoleId(int moudleId, int menuId, int btnId, int id)
        {
            var list = roleMenuService.Query(" roleid= "+ id, " otder by id  ", false);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}