using System.Collections.Generic;

namespace EverydayToolkit.Localization
{
    public interface ILocalizationSourceManager
    {
        ILocalizationSource GetSource(string name);
        IEnumerable<ILocalizationSource> GetAllSources();
        void RegisterSource<T>() where T : ILocalizationSource;
        void RegisterSource(ILocalizationSource source);
    }
}