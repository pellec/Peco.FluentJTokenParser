using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Peco.FluentParser.JTokenParsers.Tests
{
    [TestFixture]
    public class JTokenBoolValueTests
    {
        [Test]
        public void ShouldReturnDefaultValueIfTheWantedValueDoesNotExist()
        {
            var jObject = JObject.Parse("{ \"value\": \"\" }");

            bool value = jObject["value"].AsBool().OrDefault(true);

            Assert.AreEqual(value, true);
        }

        [Test]
        public void ShouldReturnDefaultValueIfTheWantedValueIsInvalid()
        {
            var jObject = JObject.Parse("{ \"value\": \"invalidbool\" }");

            bool value = jObject["value"].AsBool().OrDefault(true);

            Assert.AreEqual(value, true);
        }

        [Test]
        public void ShouldReturnDefaultValueIfTheJsonPropertyDoesNotExist()
        {
            JObject jObject = JObject.Parse("{ }");

            bool value = jObject["value"].AsBool().OrDefault(true);

            Assert.AreEqual(value, true);
        }

        [Test]
        public void ShouldReturnTheRealValueIfTheWantedValueExist()
        {
            JObject jObject = JObject.Parse("{ \"value\": \"true\" }");

            bool value = jObject["value"].AsBool().OrDefault();

            Assert.AreEqual(value, true);
        }

        [Test]
        public void ShouldReturnCorrectValueWhenConversionIsImplicit()
        {
            JObject jObject = JObject.Parse("{ \"value\": \"true\" }");

            bool value = jObject["value"].AsBool();

            Assert.AreEqual(value, true);
        }
        
    }
}