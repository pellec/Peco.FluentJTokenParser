using Newtonsoft.Json.Linq;

namespace Peco.FluentParser.JTokenParsers
{
    public static class JTokenExtensions
    {
        public static JTokenIntValue AsInt(this JToken token)
        {
            return new JTokenIntValue(token);
        }

        public static JTokenLongValue AsLong(this JToken token)
        {
            return new JTokenLongValue(token);
        }

        public static JTokenDoubleValue AsDouble(this JToken token)
        {
            return new JTokenDoubleValue(token);
        }

        public static JTokenGuidValue AsGuid(this JToken token)
        {
            return new JTokenGuidValue(token);
        }

        public static JTokenBoolValue AsBool(this JToken token)
        {
            return new JTokenBoolValue(token);
        }

        public static JTokenStringValue AsString(this JToken token)
        {
            return new JTokenStringValue(token);
        }

        public static JTokenDateTimeValue AsDateTime(this JToken token, string format)
        {
            return new JTokenDateTimeValue(format, token);
        }
    }
}