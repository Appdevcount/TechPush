using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TechPush.Areas.CMS.Controllers
{
    public class AdminController : Controller
    {
        // GET: CMS/Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}