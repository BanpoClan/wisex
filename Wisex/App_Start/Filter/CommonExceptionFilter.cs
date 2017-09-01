﻿using System;
using System.Text;
using System.Web.Mvc;
using System.Data.SqlClient;
using Wisex.Core;
using Wisex.Common.LogUtils;

namespace Wisex.Web
{
    /// <summary>
    /// 通用日志处理器
    /// </summary>
    public class CommonExceptionFilter : HandleErrorAttribute
    {

        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.IsChildAction)
            {
                return;
            }


            StringBuilder error = new StringBuilder();
            var enter = Environment.NewLine;
            error.Append(enter);
            error.Append("发生时间:" + DateTime.Now);
            error.Append(enter);

            error.Append("用户IP:" + WebHelper.GetClientIP());
            error.Append(enter);

            error.Append("发生异常页: " + filterContext.HttpContext.Request.Url);
            error.Append(enter);

            error.Append("控制器: " + filterContext.RouteData.Values["controller"]);
            error.Append(enter);

            error.Append("Action: " + filterContext.RouteData.Values["action"]);
            error.Append(enter);

            
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                var data = new
                {
                    flag = false,
                    data = string.Empty,
                    msg = filterContext.Exception.Message
                };
                filterContext.Result = new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else
            {
                var errorMsg = typeof (SqlException) == ExceptionType ? "数据库异常" : filterContext.Exception.Message;
                LogHelper.Instance.Error(errorMsg);
                var view = new ViewResult
                {
                    ViewName = "~/Views/Shared/Error.cshtml",
                    ViewData = { ["Error"] = errorMsg }
                };
                filterContext.Result = view;
            }

            filterContext.ExceptionHandled = true;
        }
    }
}