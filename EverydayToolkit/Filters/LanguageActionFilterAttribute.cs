using System.Web;
using System.Web.Mvc;
using EverydayToolkit.Localization;

namespace EverydayToolkit.Filters
{
    public class LanguageActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var language = LocalizationHelper.GetLanguageByUrl(filterContext.RouteData.Values["language"] as string);

            if (language != null)
            {
                LocalizationHelper.SetThreadCulture(language.Code);
                return;
            }

            LocalizationHelper.SetThreadCulture(LocalizationHelper.DefaultLanguage.Code);

            filterContext.Result = new HttpNotFoundResult();
            throw new HttpException(404, "Page not found");
        }
    }
}