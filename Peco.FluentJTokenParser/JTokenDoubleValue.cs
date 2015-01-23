using System.Globalization;
using Newtonsoft.Json.Linq;

namespace Peco.FluentJTokenParser
{
    public class JTokenDoubleValue : JTokenValue<double>
    {
        public JTokenDoubleValue(JToken token)
            : base(TryParseInvariantCulture, token)
        {
        }

        private static bool TryParseInvariantCulture(string s, out double value)
        {
            if (s == null)
            {
                value = 0;
                return false;
            }

            return double.TryParse(s.Replace(',', '.'), NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out value);
        }

        protected override double Value()
        {
            return Token.Value<double>();
        }
    }
}