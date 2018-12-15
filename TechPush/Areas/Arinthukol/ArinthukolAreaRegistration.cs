using System.Web.Mvc;

namespace TechPush.Areas.Arinthukol
{
    public class ArinthukolAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Arinthukol";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Arinthukol_default",
                "Arinthukol/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}