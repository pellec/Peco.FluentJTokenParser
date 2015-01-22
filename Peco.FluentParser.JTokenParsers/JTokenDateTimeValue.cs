using System;
using System.Globalization;
using Newtonsoft.Json.Linq;

namespace Peco.FluentParser.JTokenParsers
{
    public class JTokenDateTimeValue : JTokenValue<DateTime>
    {
        private static string _format;

        public JTokenDateTimeValue(string format, JToken token)
            : base(Parser, token)
        {
            _format = format;
        }

        private static bool Parser(string s, out DateTime value)
        {
            return DateTime.TryParseExact(s, _format, CultureInfo.InvariantCulture, DateTimeStyles.None, out value);
        }

        protected override DateTime Value()
        {
            return DateTime.Parse(Token.Value<string>());
        }
    }
}