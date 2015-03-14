namespace EverydayToolkit.Localization.Languages
{
    public class RussianLanguage : ILanguage
    {
        public virtual string Name
        {
            get { return "Русский"; }
        }

        public virtual string Url
        {
            get { return "ru"; }
        }

        public virtual string Code
        {
            get { return "ru"; }
        }

        public virtual int Position
        {
            get { return 0; }
        }
    }
}
