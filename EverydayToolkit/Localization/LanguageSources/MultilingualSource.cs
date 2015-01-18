using System.Collections.Generic;
using System.Linq;
using EverydayToolkit.Localization.Languages;

namespace EverydayToolkit.Localization.LanguageSources
{
    public class MultilingualSource : ILanguageSource
    {
        private readonly bool isEnglishDefault;
        private readonly HashSet<ILanguage> languages = new HashSet<ILanguage>();

        public MultilingualSource(bool isEnglishDefault = true)
        {
            this.isEnglishDefault = isEnglishDefault;

            languages.Add(new RussianLanguage());
            languages.Add(new EnglishLanguage());
        }

        public ILanguage DefaultLanguage
        {
            get { return languages.First(q => q.Code == (isEnglishDefault ? "en" : "ru")); }
        }

        public IEnumerable<ILanguage> GetAllLanguages()
        {
            return languages;
        }
    }
}