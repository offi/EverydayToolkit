using System.Globalization;
using System.Threading;

namespace EverydayToolkit.Localization.LocalizationSources
{
    public class NullLocalizationSource : ILocalizationSource
    {
        public string Name
        {
            get { return "Null"; }
        }

        public void Initialize()
        {
        }

        public string GetTranslation(string keyword)
        {
            return GetTranslation(keyword, Thread.CurrentThread.CurrentCulture);
        }

        public string GetTranslation(string keyword, CultureInfo culture)
        {
            return string.Format("[{0}:{1}]", keyword, culture.Name);
        }
    }
}