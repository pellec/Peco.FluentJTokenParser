using Newtonsoft.Json.Linq;

namespace Peco.FluentJTokenParser
{
    public class JTokenIntValue : JTokenValue<int>
    {
        public JTokenIntValue(JToken token)
            : base(int.TryParse, token)
        {
        }

        protected override int Value()
        {
            return Token.Value<int>();
        }
    }
}