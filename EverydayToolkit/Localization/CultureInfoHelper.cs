using System.Globalization;

namespace EverydayToolkit.Localization
{
    internal static class CultureInfoHelper
    {
        public static bool IsValidCultureCode(string cultureCode)
        {
            try
            {
                CultureInfo.GetCultureInfo(cultureCode);
                return true;
            }
            catch (CultureNotFoundException)
            {
                return false;
            }
        }
    }
}