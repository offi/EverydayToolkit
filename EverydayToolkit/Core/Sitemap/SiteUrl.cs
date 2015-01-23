using System;
using System.Xml.Linq;

namespace EverydayToolkit.Core.Sitemap
{
    public class SiteUrl
    {
        private float? priority;

        public SiteUrl(Uri location)
        {
            Location = location;
        }

        public Uri Location { get; private set; }
        public DateTimeOffset? LastModified { get; set; }
        public ChangeFrequency? ChangeFrequency { get; set; }

        public float? Priority
        {
            get { return priority; }
            set
            {
                if (value < 0 || value > 1)
                {
                    throw new NotSupportedException("Priority must be between 0 and 1");
                }
                priority = value;
            }
        }

        public virtual XElement Serialize()
        {
            return new XElement(SitemapBuilder.Sitemap + "url",
                new XElement(SitemapBuilder.Sitemap + "loc", Location),
                LastModified.HasValue
                    ? new XElement(SitemapBuilder.Sitemap + "lastmod",
                        LastModified.Value.ToString("yyyy-MM-ddTHH:mm:ss%K"))
                    : null,
                ChangeFrequency.HasValue
                    ? new XElement(SitemapBuilder.Sitemap + "changefreq",
                        ChangeFrequency.Value.ToString().ToLower())
                    : null,
                Priority.HasValue
                    ? new XElement(SitemapBuilder.Sitemap + "priority",
                        Priority.Value)
                    : null);
        }
    }
}