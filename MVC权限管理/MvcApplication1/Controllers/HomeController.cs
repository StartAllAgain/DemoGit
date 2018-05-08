using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        User ModelUser = null;
        //
        // GET: /Index/
        public ActionResult Index()
        {
            //   getType();
            // Logic();
            return View();
        }
        //public void Logic()
        //{
        //    string name = Request.Form["name"];
        //    string Pass = Request.Form["pass"];

        //    ModelUser = new User() { ID = 1, Name = name, UserName = name, PassWord = Pass, Roles = "admin" };//用户实体
        //}
        [AuthAttribute(Code = "1", Name = "d")]
        public ActionResult MainPage()
        {
            return RedirectToAction("Home", "Home");
        }

        public ActionResult Home()
        {
            return View();
        }
        public void getType()
        {
            Type type = typeof(User);
            Assembly assembly = type.Assembly;
            Type[] typeArray = assembly.GetTypes();
            foreach (Type item in typeArray)
            {
                ConstructorInfo[] constructs = item.GetConstructors();

                FieldInfo[] FieldArray = item.GetFields();
                int a1 = 1;
                MethodInfo[] methods = item.GetMethods();

                PropertyInfo[] propertys = item.GetProperties();
                int a3 = 1;
                foreach (PropertyInfo pro in propertys)
                {
                    Response.Write((a3++).ToString() + " " + pro.PropertyType.Name + " " + pro.Name + "{");
                    if (pro.CanRead)
                        Response.Write("get;");
                    if (pro.CanWrite)
                        Response.Write("set;");
                    Response.Write("}<br/>");
                }
                foreach (FieldInfo field in FieldArray)
                {
                    Response.Write((a1++).ToString() + ". " + field.Name + "<br/>");
                }
            }
        }

        public ActionResult Logic()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Logic(FormCollection form)
        {
            string Name = form["Name"];
            string Pwd = form["Paw"];
            if (string.IsNullOrWhiteSpace(Name) && string.IsNullOrWhiteSpace(Pwd))
            {
                HttpContext.Response.Write("<script>alert('帐号密码为空！')</script>");
                //Content("<script>alert('帐号密码为空！')</script>");
                return View();
            }

            ModelUser = new User() { ID = 1, Name = Name, UserName = Pwd, PassWord = Pwd, Roles = "admin" };
            HttpCookie cookie = new HttpCookie("Logic");
            cookie.Expires = DateTime.MinValue;
            System.Web.Security.FormsAuthentication.RedirectFromLoginPage(ModelUser.ID.ToString(),true, "Logic");
            return RedirectToAction("MainPage");
        }

        public ActionResult Edit()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Logic");
        }
        [HttpPost]
        public ActionResult Index2()
        {
            var str = "{ID :'123', Name : 'asdsa' }";

            return new JSONPResult { Data = str };
        }

    }
}
