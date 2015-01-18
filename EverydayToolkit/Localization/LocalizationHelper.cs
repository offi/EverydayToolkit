using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace EverydayToolkit.Localization
{
    public static class LocalizationHelper
    {
        private static readonly Lazy<ILocalizationSourceManager> sourceManager;
        private static ILanguageSource languageSource;

        static LocalizationHelper()
        {
            sourceManager = new Lazy<ILocalizationSourceManager>(() => new LocalizationSourceManager());
        }

        #region # Sources and translations

        public static string GetTranslation(string source, string keyword)
        {
            return sourceManager.Value.GetSource(source).GetTranslation(keyword);
        }

        public static string GetTranslation(string source, string keyword, CultureInfo culture)
        {
            return sourceManager.Value.GetSource(source).GetTranslation(keyword, culture);
        }

        public static IEnumerable<ILocalizationSource> GetAllSources()
        {
            return sourceManager.Value.GetAllSources();
        }

        public static void RegisterLocalizationSource<T>() where T : ILocalizationSource
        {
            sourceManager.Value.RegisterSource<T>();
        }

        #endregion

        #region # Languages

        public static ILanguage DefaultLanguage
        {
            get { return languageSource.DefaultLanguage; }
        }

        public static IEnumerable<ILanguage> GetAllLanguages()
        {
            return languageSource.GetAllLanguages();
        }

        public static ILanguage GetLanguageByUrl(string url)
        {
            return languageSource.GetAllLanguages().FirstOrDefault(q => q.Url == url);
        }

        public static ILanguage GetLanguageByCode(string code)
        {
            return languageSource.GetAllLanguages().FirstOrDefault(q => q.Code == code);
        }

        public static bool SetThreadCulture(string code)
        {
            if (CultureInfoHelper.IsValidCultureCode(code))
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(code);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(code);
                HttpContext.Current.Session["LanguageCode"] = code;

                return true;
            }

            return false;
        }

        public static void RegisterLanguageSource<T>() where T : ILanguageSource
        {
            languageSource = Activator.CreateInstance<T>();
        }

        #endregion
    }
}