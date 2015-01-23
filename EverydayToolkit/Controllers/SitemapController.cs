using System;
using System.IO;
using System.Text;
using System.Web.Mvc;
using EverydayToolkit.Core.Sitemap;

namespace EverydayToolkit.Controllers
{
    public abstract class SitemapController : Controller
    {
        private readonly SitemapBuilder builder = new SitemapBuilder();

        public ContentResult File()
        {
            GenerateUrls();

            var sitemapDocument = builder.Build();

            using (var ms = new MemoryStream())
            {
                using (var writer = new StreamWriter(ms, Encoding.UTF8))
                {
                    sitemapDocument.Save(writer);
                }

                return Content(Encoding.UTF8.GetString(ms.ToArray()), "text/xml", Encoding.UTF8);
            }
        }

        protected abstract void GenerateUrls();

        protected void AddUrl(string relativeUrl, DateTimeOffset? lastModified = null, ChangeFrequency? changeFrequency = null, float? priority = null)
        {
            var uri = new Uri(Request.Url, relativeUrl);
            var url = new SiteUrl(uri)
            {
                ChangeFrequency = changeFrequency,
                LastModified = lastModified,
                Priority = priority
            };
            builder.Add(url);
        }
    }
}