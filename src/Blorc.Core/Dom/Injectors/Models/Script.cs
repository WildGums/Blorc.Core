namespace Blorc.Dom.Injectors
{
    using System.Collections.Generic;

    public class Script : InjectorBase
    {
        private readonly string _src;
        private readonly string _type;

        public Script(string src, string type = "text/javascript")
        {
            _src = src;
            _type = type;
        }

        protected override string ElementName => "script";

        protected override Dictionary<string, string> GetAttributes()
        {
            return new Dictionary<string, string>()
            {
                { "src", _src },
                {"type", _type }
            };
        }
    }
}
