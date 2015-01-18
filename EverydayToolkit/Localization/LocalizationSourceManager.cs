using System;
using System.Collections.Generic;
using System.Linq;

namespace EverydayToolkit.Localization
{
    internal class LocalizationSourceManager : ILocalizationSourceManager
    {
        private readonly IDictionary<string, ILocalizationSource> sources;

        public LocalizationSourceManager()
        {
            sources = new Dictionary<string, ILocalizationSource>();
        }

        public ILocalizationSource GetSource(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            ILocalizationSource source;
            if (!sources.TryGetValue(name, out source))
            {
                throw new Exception("Can not find a source with name: " + name);
            }

            return source;
        }

        public IEnumerable<ILocalizationSource> GetAllSources()
        {
            return sources.Select(pair => pair.Value);
        }

        public void RegisterSource<T>() where T : ILocalizationSource
        {
            var source = (ILocalizationSource) Activator.CreateInstance<T>();
            SetLocalizationSource(source);
        }
        
        public void RegisterSource(ILocalizationSource source)
        {
            SetLocalizationSource(source);
        }

        private void SetLocalizationSource(ILocalizationSource source)
        {
            if (sources.ContainsKey(source.Name))
            {
                throw new Exception("There is already a source with name: " + source.Name);
            }

            sources[source.Name] = source;
            source.Initialize();
        }
    }
}