namespace EverydayToolkit.Localization.Languages
{
    public class EnglishLanguage : ILanguage
    {
        public virtual string Name
        {
            get { return "English"; }
        }

        public virtual string Url
        {
            get { return "en"; }
        }

        public virtual string Code
        {
            get { return "en"; }
        }

        public virtual int Position
        {
            get { return 0; }
        }
    }
}