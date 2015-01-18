using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverydayToolkit.Localization
{
    public interface ILanguage
    {
        string Name { get; }
        string Url { get; }
        string Code { get; }
    }
}
