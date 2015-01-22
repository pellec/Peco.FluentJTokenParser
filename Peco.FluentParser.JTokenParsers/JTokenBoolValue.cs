using Newtonsoft.Json.Linq;

namespace Peco.FluentParser.JTokenParsers
{
    public class JTokenBoolValue : JTokenValue<bool>
    {
        public JTokenBoolValue(JToken token)
            : base(bool.TryParse, token)
        {
        }

        protected override bool Value()
        {
            return Token.Value<bool>();
        }
    }
}