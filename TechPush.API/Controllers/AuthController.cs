using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TechPush.Common.APIConsumption;

namespace TechPush.API.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            APIDataAccess DA = new APIDataAccess();

            DA.GetGoogleRedirAPIURL();
            return View();
        }

        //public ActionResult GoogleAuth()
        //{

        //    return Redirect("/api/Account/ExternalLogin?provider=Google&response_type=token&client_id=self&redirect_uri="+http%3a%2f%2flocalhost%3a61358%2fLogin.html+"&state=GerGr5JlYx4t_KpsK57GFSxVueteyBunu02xJTak5m01");
        //}
        //public ActionResult FacebookAuth()
        //{
        //    Redirect("");
        //    //return View();
        //}

    }
}