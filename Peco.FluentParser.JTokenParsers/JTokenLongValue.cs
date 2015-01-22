using Newtonsoft.Json.Linq;

namespace Peco.FluentParser.JTokenParsers
{
    public class JTokenLongValue : JTokenValue<long>
    {
        public JTokenLongValue(JToken token)
            : base(long.TryParse, token)
        {
        }

        protected override long Value()
        {
            return Token.Value<long>();
        }
    }
}