using System;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Peco.FluentJTokenParser.Tests
{
    [TestFixture]
    public class JTokenGuidValueTests
    {
        [Test]
        public void ShouldReturnTheRealValueIfTheWantedValueExist()
        {
            JObject jObject = JObject.Parse("{ \"value\": \"cceae5b2-ae34-47b6-81ca-db447691aabb\" }");

            Guid value = jObject["value"].AsGuid();

            Assert.AreEqual(value, Guid.Parse("cceae5b2-ae34-47b6-81ca-db447691aabb"));
        }

        [Test]
        public void ShouldReturnDefaultValueIfTheWantedIsInvalid()
        {
            JObject jObject = JObject.Parse("{ \"value\": \"notavalidguid\" }");

            Guid value = jObject["value"].AsGuid().OrDefault(Guid.Parse("cceae5b2-ae34-47b6-81ca-db447691aabb"));

            Assert.AreEqual(value, Guid.Parse("cceae5b2-ae34-47b6-81ca-db447691aabb"));
        }
    }
}