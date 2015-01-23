using System;
using Newtonsoft.Json.Linq;

namespace Peco.FluentJTokenParser
{
    public class JTokenGuidValue : JTokenValue<Guid>
    {
        public JTokenGuidValue(JToken token)
            : base(Guid.TryParse, token)
        {
        }

        protected override Guid Value()
        {
            return Guid.Parse(Token.Value<string>());
        }
    }
}