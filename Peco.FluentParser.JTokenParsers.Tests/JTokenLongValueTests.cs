using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Peco.FluentParser.JTokenParsers.Tests
{
    [TestFixture]
    public class JTokenLongValueTests
    {
        [Test]
        public void ShouldReturnDefaultValueIfTheWantedValueDoesNotExist()
        {
            var jObject = JObject.Parse("{ \"value\": \"\" }");

            const long defaultValue = 9223372036854775807;
            long value = jObject["value"].AsLong().OrDefault(defaultValue);

            Assert.AreEqual(value, defaultValue);
        }

        [Test]
        public void ShouldReturnCorrectValueWhenConversionIsImplicit()
        {
            JObject jObject = JObject.Parse("{ \"value\": \"9223372036854775807\" }");

            long value = jObject["value"].AsLong();

            Assert.AreEqual(value, 9223372036854775807);
        }
    }
}