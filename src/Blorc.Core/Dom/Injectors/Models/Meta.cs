namespace Blorc.Dom.Injectors
{
    using System.Collections.Generic;

    public class Meta : InjectorBase
    {
        public Meta()
        {
            Charset = string.Empty;
            Content = string.Empty;
            HttpEquiv = string.Empty;
            Name = string.Empty;
        }

        public string Charset { get; set; }

        public string Content { get; set; }

        public string HttpEquiv { get; set; }

        public string Name { get; set; }

        protected override string ElementName => "meta";

        protected override Dictionary<string, string> GetAttributes()
        {
            var attributes = new Dictionary<string, string>();

            attributes["charset"] = Charset;
            attributes["content"] = Content;
            attributes["http-equiv"] = HttpEquiv;
            attributes["name"] = Name;

            return attributes;
        }
    }
}
