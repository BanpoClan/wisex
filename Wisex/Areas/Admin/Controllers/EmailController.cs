using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using Wisex.Common.Enums;
using Wisex.Core.Extentions;
using Wisex.Entity.CommonModel;
using Wisex.Entity.Models;
using Wisex.Service.SystemControl;

namespace Wisex.Areas.Admin.Controllers
{
    public class EmailController : AdminBaseController
    {
        public IEmailPoolService emailPoolService { get; set; }

        public IEmailReceiverService emailReceService { get; set; }

        #region Page

        // GET: Adm/Email
        public ActionResult Index(int moudleId, int menuId, int btnId)
        {
            GetButtons(menuId);
            return View();
        }

        // GET: Adm/Email/Add
        public ActionResult Add(int moudleId, int menuId, int btnId)
        {
            return View();
        }

        #endregion

        #region Ajax


        [HttpPost]
        public ActionResult Add(int moudleId, int menuId, int btnId, EmailPool dto)
        {
            if (dto != null && !dto.ReceiverEmails.IsBlank())
            {
                dto.Status = EmailStatus.等待发送;
                var res = emailPoolService.Add(dto);
                if (res)
                {
                    var list = new List<EmailReceiver>();
                    dto.ReceiverEmails.Split(new []{';',','}, StringSplitOptions.RemoveEmptyEntries).ToList()
                        .ForEach(email =>
                    {
                        if (email.IsValidEmail())
                        {
                            list.Add(new EmailReceiver
                            {
                                EmailId = dto.Id,
                                Email = email,
                                Type = EmailReceiverType.收件人
                            });
                        }
                    });
                    emailReceService.Add(list);
                }
            }
            return RedirectToAction("Index", RouteData.Values);
        }

        public JsonResult GetList(int moudleId, int menuId, int btnId)
        {
            var queryBase = new QueryBase
            {
                StartIndex = Request["start"].ToInt(),
                PageSize = Request["length"].ToInt(),
                Draw = Request["draw"].ToInt(),
                Keywords = Request["keywords"]
            };
            Expression<Func<EmailPool, bool>> exp = item => !item.IsDeleted;
            if (!queryBase.Keywords.IsBlank())
                exp = exp.And(item => item.Title.Contains(queryBase.Keywords));

            var dto = emailPoolService.GetWithPages(queryBase, exp, Request["orderBy"], Request["orderDir"]);
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}