using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class UserController : ApiController
    {
        [System.Web.Http.ActionName("add")]
        [System.Web.Http.HttpGet]
        public bool add()
        {
            string d = HttpContext.Current.Request.QueryString["a"];
            return true;
        }
        [System.Web.Http.ActionName("add1")]
        [System.Web.Http.HttpGet]
        public string add1()
        {
            return "1";
        }
        //[System.Web.Http.ActionName("getAdmin")]
        [System.Web.Http.HttpGet]
        public List<UserModel> getAdmin()
        {
            string d = HttpContext.Current.Request.QueryString["a"];

            return new List<UserModel>() { new UserModel() { UserID = "1", UserName = "李志高" }, 
                                           new UserModel() { UserID = "1", UserName = "Admin" },  
                                           new UserModel() { UserID = "1", UserName = "张三" } };
            //return 1;
        }

    }
}
