using Newtonsoft.Json.Linq;

namespace Peco.FluentParser.JTokenParsers
{
    public delegate bool TryParse<T>(string s, out T value);

    public abstract class JTokenValue<T>
    {
        protected readonly JToken Token;
        private readonly TryParse<T> _parser;

        protected JTokenValue(TryParse<T> parser, JToken token)
        {
            _parser = parser;
            Token = token;
        }

        public T OrDefault(T defaultValue = default(T))
        {
            string value;
            if (!TryGetValue(out value))
            {
                return defaultValue;
            }

            T result;
            return _parser(value, out result) ? result : defaultValue;
        }

        public bool HasValue()
        {
            string value;
            return TryGetValue(out value);
        }

        private bool TryGetValue(out string value)
        {
            if (Token == null)
            {
                value = null;
                return false;
            }

            if (Token is JObject)
            {
                value = null;
                return false;
            }

            value = Token.Value<string>();
            return !string.IsNullOrEmpty(value);
        }

        public static implicit operator T(JTokenValue<T> value)
        {
            return value.Value();
        }

        protected abstract T Value();
    }
}
