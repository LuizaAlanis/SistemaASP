using System.Web.Mvc;

namespace RestauranteMexicano.Areas.SAC
{
    public class SACAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SAC";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SAC_default",
                "SAC/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}