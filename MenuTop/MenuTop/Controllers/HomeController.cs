using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MenuTop.Models;

namespace MenuTop.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            string name = "a";  //Request.Form["name"];
            string Pass = "b";  //Request.Form["pass"];

            User ModelUser = new User() { ID = 1, Name = name, UserName = name, PassWord = Pass, Roles = "A1" };//用户实体
            return View();
        }
        [Authorize(Users = "A0")]
        public ActionResult Index1()
        {
            ViewData["a"] = "1";
            return View();
        }
        [Authorize(Roles = "A1")]
        public ActionResult Index2()
        {
            ViewData["a"] = "2";
            return View();
        }


    }
}
