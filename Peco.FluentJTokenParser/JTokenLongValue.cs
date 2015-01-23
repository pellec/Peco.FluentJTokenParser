using Newtonsoft.Json.Linq;

namespace Peco.FluentJTokenParser
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