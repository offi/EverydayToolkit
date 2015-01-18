using System.Globalization;
using System.Web.Mvc;
using EverydayToolkit.Localization;

namespace EverydayToolkit.Views
{
    public abstract class EverydayView<TModel> : WebViewPage<TModel>
    {
        protected virtual ILanguage CurrentLanguage
        {
            get { return LocalizationHelper.GetLanguageByCode(Session["LanguageCode"] as string) ?? LocalizationHelper.DefaultLanguage; }
        }

        protected virtual string TranslationSourceName
        {
            get { return "Null"; }
        }

        protected virtual string T(string keyword)
        {
            return LocalizationHelper.GetTranslation(TranslationSourceName, keyword);
        }

        protected virtual string T(string keyword, CultureInfo culture)
        {
            return LocalizationHelper.GetTranslation(TranslationSourceName, keyword, culture);
        }
    }
}
