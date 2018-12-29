using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechPush.Core;

namespace TechPush.Areas.CMS.Controllers
{
    public class BlogController : Controller
    {
        // GET: CMS/Blog
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category Category)
        {
            return View();
        }
        public ActionResult AddTag()
        {
            return View();
        }
        public ActionResult AddPost()
        {
            return View();
        }
    }
}