using System;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Peco.FluentJTokenParser.Tests
{
    [TestFixture]
    public class JTokenDateTimeTests
    {
        [Test]
        public void ShouldReturnTheParsedValue1()
        {
            JObject jObject = JObject.Parse("{\"value\": \"00:01\"}");

            DateTime value = jObject["value"].AsDateTime("HH:mm").OrDefault(DateTime.Now);

            Assert.AreEqual(value.TimeOfDay, new TimeSpan(0, 1, 0));
        }

        [Test]
        public void ShouldReturnTheParsedValue2()
        {
            JObject jObject = JObject.Parse("{ \"value\": \"23:00\" }");

            DateTime value = jObject["value"].AsDateTime("HH:mm").OrDefault(DateTime.Now);

            Assert.AreEqual(value.TimeOfDay, new TimeSpan(23, 0, 0));
        }

        [Test]
        public void ShouldReturnTheParsedValue3()
        {
            JObject jObject = JObject.Parse("{\"value\": \"2000 10 20 10:20\"}");

            DateTime value = jObject["value"].AsDateTime("yyyy MM dd HH:mm").OrDefault(DateTime.Now);

            Assert.AreEqual(value.Year, 2000);
            Assert.AreEqual(value.Month, 10);
            Assert.AreEqual(value.Day, 20);
            Assert.AreEqual(value.Hour, 10);
            Assert.AreEqual(value.Minute, 20);
        }

        [Test]
        public void ShouldReturnDefaultValue()
        {
            JObject jObject = JObject.Parse("{ \"value\": \"\" }");

            var now = DateTime.Now;
            DateTime value = jObject["value"].AsDateTime("HH:mm").OrDefault(now);

            Assert.AreEqual(value.TimeOfDay, now.TimeOfDay);
        }
    }
}