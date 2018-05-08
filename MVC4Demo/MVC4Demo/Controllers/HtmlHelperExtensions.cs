using MVC4Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC4Demo.Controllers
{
    public static class HtmlHelperExtensions
    {
        public static ListGroup ListGroup(this HtmlHelper htmlHelper)
        {

            return new ListGroup();

        }
    }

}