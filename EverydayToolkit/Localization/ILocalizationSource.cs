using System.Globalization;

namespace EverydayToolkit.Localization
{
    public interface ILocalizationSource
    {
        string Name { get; }
        void Initialize();
        string GetTranslation(string keyword);
        string GetTranslation(string keyword, CultureInfo culture);
    }
}