using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Peco.FluentJTokenParser.Tests
{
    [TestFixture]
    public class JTokenIntValueTests
    {
        [Test]
        public void ShouldReturnDefaultValueIfTheWantedValueDoesNotExist()
        {
            var jObject = JObject.Parse("{ \"value\": \"\" }");

            int value = jObject["value"].AsInt().OrDefault(5);

            Assert.AreEqual(value, 5);
        }

        [Test]
        public void ShouldReturnDefaultValueIfTheWantedValueIsInvalid()
        {
            var jObject = JObject.Parse("{ \"value\": \"invalidint\" }");

            int value = jObject["value"].AsInt().OrDefault(5);

            Assert.AreEqual(value, 5);
        }

        [Test]
        public void ShouldReturnDefaultValueIfTheJsonPropertyDoesNotExist()
        {
            JObject jObject = JObject.Parse("{ }");

            int value = jObject["value"].AsInt().OrDefault(5);

            Assert.AreEqual(value, 5);
        }

        [Test]
        public void ShouldReturnTheRealValueIfTheWantedValueExist()
        {
            JObject jObject = JObject.Parse("{ \"value\": \"10\" }");

            int value = jObject["value"].AsInt().OrDefault(5);

            Assert.AreEqual(value, 10);
        }

        [Test]
        public void ShouldReturnCorrectValueWhenConversionIsImplicit()
        {
            JObject jObject = JObject.Parse("{ \"value\": \"10\" }");

            int value = jObject["value"].AsInt();

            Assert.AreEqual(value, 10);
        }
    }
}
