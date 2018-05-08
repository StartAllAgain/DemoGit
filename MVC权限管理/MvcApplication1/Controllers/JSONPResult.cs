﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class JSONPResult : JsonResult
    {
        public string Callback { get; set; }
        public JSONPResult()
        {
            JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            var httpContext = context.HttpContext;
            var callBack = Callback;
            if (string.IsNullOrWhiteSpace(callBack))
            {
                callBack = httpContext.Request["callback"]; //获得客户端提交的回调函数名称
            }
            // 返回客户端定义的回调函数
            httpContext.Response.Write(callBack + "(");
            httpContext.Response.Write(Data);          //Data 是服务器返回的数据        
            httpContext.Response.Write(");");            //将函数输出给客户端，由客户端执行
        }

    }
}