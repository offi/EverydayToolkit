using System.Collections.Generic;
using System.Linq;
using EverydayToolkit.Localization.Languages;

namespace EverydayToolkit.Localization.LanguageSources
{
    public class RussianLanguageSource : ILanguageSource
    {
        private readonly HashSet<ILanguage> languages = new HashSet<ILanguage>();

        public RussianLanguageSource()
        {
            languages.Add(new RussianLanguage());
        }

        public ILanguage DefaultLanguage
        {
            get { return languages.First(); }
        }

        public IEnumerable<ILanguage> GetAllLanguages()
        {
            return languages.ToList();
        }
    }
}