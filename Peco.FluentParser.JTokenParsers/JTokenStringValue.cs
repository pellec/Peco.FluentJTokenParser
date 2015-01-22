using Newtonsoft.Json.Linq;

namespace Peco.FluentParser.JTokenParsers
{
    public class JTokenStringValue : JTokenValue<string>
    {
        public JTokenStringValue(JToken token)
            : base(Parser, token)
        {
        }

        private static bool Parser(string s, out string value)
        {
            value = s;
            return true;
        }

        protected override string Value()
        {
            return Token.Value<string>();
        }
    }
}