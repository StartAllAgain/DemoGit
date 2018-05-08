using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using 设计模式;

namespace MVC4Demo.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            DateTime.ParseExact("20131001", "yyyyMMdd", null).ToString("yyyy-MM-dd");
            MVC4Demo.DataList b = new MVC4Demo.DataList()
            {
                SportProducts = new List<string>() { "a", "b", "c" },
                BookProducts = new List<string>() { "h", "i", "j" },
                FoodProducts = new List<string>() { "e", "f", "g" }
            };
            return View(b);
        }
        public FileResult ResultFile()
        {
            string path = Server.MapPath("~/Image/A.jpg");
            return File(path, ".jpg");
        }

        public ContentResult ResultContent()
        {
            return Content("Hello Word ");
        }
        public HttpNotFoundResult ResultFound()
        {
            return HttpNotFound();
        }

        public JsonResult ResultJson()
        {
            JsonResult json = new JsonResult();
            json.Data = "{'A':'a','B':'b'}";
            return Json(json.Data, JsonRequestBehavior.AllowGet);
        }

        public RedirectResult ResultRedirect()
        {
            return Redirect("http://www.baidu.com");
        }
        [HttpGet]
        public string resultJson()
        {
            StringBuilder d = new StringBuilder();
            普通类_1 sj = new 普通类_1();
            sj.Sum();
            d.Append(sj.add());
            return "{\"a\":\"b\",\"b\":\"c\"}";
        }
    }
}
