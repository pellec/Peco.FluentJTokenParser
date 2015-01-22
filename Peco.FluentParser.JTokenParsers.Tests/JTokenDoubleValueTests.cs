using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Peco.FluentParser.JTokenParsers.Tests
{
    [TestFixture]
    public class JTokenDoubleValueTests
    {
        [TestCase("3286.83333333335", Result = 3286.83333333335)]
        [TestCase("3286,8", Result = 3286.8)]
        [TestCase("3286", Result = 3286)]
        public double ShouldParseStringValueToDouble(string number)
        {
            var jObject = JObject.Parse("{\"value\" : \"" + number + "\"}");

            return jObject["value"].AsDouble().OrDefault();
        }

        [TestCase("3286.83333333335", Result = 3286.83333333335)]
        [TestCase("3286.8", Result = 3286.8)]
        [TestCase("3286", Result = 3286)]
        public double ShouldParseValueToDouble(string number)
        {
            var jObject = JObject.Parse("{\"value\" : " + number + "}");

            return jObject["value"].AsDouble().OrDefault();
        }
    }
}