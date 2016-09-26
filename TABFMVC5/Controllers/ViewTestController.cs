using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TABFMVC5.Controllers
{
    public class ViewTestController : Controller
    {
        // GET: ViewTest
        public ActionResult Index()
        {
            return PartialView();
        }
    }
}