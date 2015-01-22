# FluentParser.JTokenParsers

Parse JToken values fluently and fallback to default values easily. 

## How-to

There are extensions methods for common types like int, long, double, guid, datetime, bool and string which you can use for specifying how to parse a JToken value.
For example:

		int value = JObject.Parse("{ \"value\": \"10\" }")["value"].AsInt(); // value is now 10
		int value = JObject.Parse("{ \"value\": \"not a number\" }")["value"].AsInt().OrDefault(10); // value is now also 10

		Guid value = JObject.Parse("{ \"value\": \"cceae5b2-ae34-47b6-81ca-db447691aabb\" }")["value"].AsGuid(); // value is now cceae5b2-ae34-47b6-81ca-db447691aabb
		Guid value = JObject.Parse("{ \"value\": \"not a guid \" }")["value"].AsGuid().OrDefault(Guid.Parse("cceae5b2-ae34-47b6-81ca-db447691aabb")); // value is now cceae5b2-ae34-47b6-81ca-db447691aabb

		DateTime value = JObject.Parse("{\"value\": \"2000 10 20 10:20\"}")["value"].AsDateTime("yyyy MM dd HH:mm"); // value is now 2000-10-20 10:20
		DateTime value = JObject.Parse("{\"value\": \"not a date\"}")["value"].AsDateTime("yyyy MM dd HH:mm").OrDefault(DateTime.Now); // value is now DateTime.Now

		double value = JObject.Parse("{\"value\" : \"3286.83333333335\"}")["value"].AsDouble(); // value is now 3286.83333333335
		double value = JObject.Parse("{\"value\" : \"not a double\"}")["value"].AsDouble().OrDefault(3286); // value is now 3286

Check out the test assembly for more examples.

Have fun!
