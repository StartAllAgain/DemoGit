﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcApplication1.Controllers
{
    public class AuthAttribute : ActionFilterAttribute
    {
        public string Code { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 验证权限（action执行前会先执行这里）
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //如果存在身份信息
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                ContentResult Content = new ContentResult();
                Content.Content = string.Format("<script type='text/javascript'>alert('请先登录！');window.location.href='{0}';</script>", FormsAuthentication.LoginUrl);
                filterContext.Result = Content;
            }
            else
            {
                string[] Role = new string[] { "1", "3", "4" };//获取所有角色
                if (!Role.Contains(Code))//验证权限
                {
                    //验证不通过
                    ContentResult Content = new ContentResult();
                    Content.Content = "<script type='text/javascript'>alert('权限验证不通过！');history.go(-1);</script>";
                    filterContext.Result = Content;
                }
            }
        }
    }
}