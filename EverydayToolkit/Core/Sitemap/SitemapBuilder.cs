using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace EverydayToolkit.Core.Sitemap
{
    public class SitemapBuilder
    {
        public static readonly XNamespace Sitemap = "http://www.sitemaps.org/schemas/sitemap/0.9";
        private readonly List<SiteUrl> urlset = new List<SiteUrl>();

        public void Add(SiteUrl url)
        {
            urlset.Add(url);
        }

        public XDocument Build()
        {
            return new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement(Sitemap + "urlset", urlset.Select(x => x.Serialize())));
        }
    }
}