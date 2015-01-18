using System.Collections.Generic;

namespace EverydayToolkit.Localization
{
    public interface ILanguageSource
    {
        ILanguage DefaultLanguage { get; }
        IEnumerable<ILanguage> GetAllLanguages();
    }
}