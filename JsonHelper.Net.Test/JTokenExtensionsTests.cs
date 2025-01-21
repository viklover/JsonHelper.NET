using Newtonsoft.Json.Linq;

namespace NewtonsoftJsonHelper.Test;

public class JTokenExtensionsTests {
    /// <summary>
    ///     String selection test
    /// </summary>
    [TestCase("{\"field\":\"hello\"}", "$.field", "hello")]
    [TestCase("{\"field\": true}", "$.field", null)]
    public async Task SelectStringTest(string json, string path, string? expected) {
        await Console.Out.WriteLineAsync(json);
        await Console.Out.WriteLineAsync(path);
        await Console.Out.WriteLineAsync(expected);
        var jtoken = JToken.Parse(json);
        if (expected != null) {
            var result = jtoken.SelectStringOrThrow(path);
            await Console.Out.WriteLineAsync(result);
            Assert.That(result, Is.EqualTo(expected));
        } else {
            Assert.Throws<JsonHelperException>(() => jtoken.SelectStringOrThrow(path));
        }
    }
    /// <summary>
    ///     Boolean selection test
    /// </summary>
    [TestCase("{\"field\": true}", "$.field", true)]
    [TestCase("{\"field\":\"hello\"}", "$.field", null)]
    public async Task SelectBooleanTest(string json, string path, bool? expected) {
        await Console.Out.WriteLineAsync(json);
        await Console.Out.WriteLineAsync(path);
        await Console.Out.WriteLineAsync(expected.ToString());
        var jtoken = JToken.Parse(json);
        if (expected != null) {
            var result = jtoken.SelectBooleanOrThrow(path);
            await Console.Out.WriteLineAsync(result.ToString());
            Assert.That(result, Is.EqualTo(expected.Value));
        } else {
            Assert.Throws<JsonHelperException>(() => jtoken.SelectBooleanOrThrow(path));
        }
    }
    /// <summary>
    ///     Integer selection test
    /// </summary>
    [TestCase("{\"field\": 12}", "$.field", 12)]
    [TestCase("{\"field\":\"hello\"}", "$.field", null)]
    public async Task SelectIntegerTest(string json, string path, int? expected) {
        await Console.Out.WriteLineAsync(json);
        await Console.Out.WriteLineAsync(path);
        await Console.Out.WriteLineAsync(expected.ToString());
        var jtoken = JToken.Parse(json);
        if (expected != null) {
            var result = jtoken.SelectIntOrThrow(path);
            await Console.Out.WriteLineAsync(result.ToString());
            Assert.That(result, Is.EqualTo(expected.Value));
        } else {
            Assert.Throws<JsonHelperException>(() => jtoken.SelectIntOrThrow(path));
        }
    }
    /// <summary>
    ///     Float selection test
    /// </summary>
    [TestCase("{\"field\": -127.0}", "$.field", -127f)]
    [TestCase("{\"field\":\"hello\"}", "$.field", null)]
    public async Task SelectFloatTest(string json, string path, float? expected) {
        await Console.Out.WriteLineAsync(json);
        await Console.Out.WriteLineAsync(path);
        await Console.Out.WriteLineAsync(expected.ToString());
        var jtoken = JToken.Parse(json);
        if (expected != null) {
            var result = jtoken.SelectFloatOrThrow(path);
            await Console.Out.WriteLineAsync(result.ToString());
            Assert.That(result, Is.EqualTo(expected.Value));
        } else {
            Assert.Throws<JsonHelperException>(() => jtoken.SelectFloatOrThrow(path));
        }
    }
    /// <summary>
    ///     List selection test
    /// </summary>
    [TestCase("{\"field\": [\"a\",\"b\",\"c\"]}", "$.field", "a", "b", "c")]
    public async Task SelectListWithStringsTest(string json, string path, params string[] items) {
        await Console.Out.WriteLineAsync(json);
        await Console.Out.WriteLineAsync(path);
        await Console.Out.WriteLineAsync(items.Length.ToString());
        foreach (var item in items) {
            await Console.Out.WriteLineAsync(item);
        }
        var jtoken = JToken.Parse(json);
        var result = jtoken.SelectList<string>(path);
        Assert.That(result, Is.Not.Null);
        foreach (var item in result!) {
            await Console.Out.WriteLineAsync(item);
        }
        Assert.That(result, Is.EquivalentTo(items));
    }
    /// <summary>
    ///     Date selection test
    /// </summary>
    [TestCase("{\"field\": \"2024-01-05T00:00:00\"}", "$.field", "2024-01-05T00:00:00.0000000")]
    [TestCase("{\"field\":\"hello\"}", "$.field", null)]
    public async Task SelectDateTest(string json, string path, string? expected) {
        await Console.Out.WriteLineAsync(json);
        await Console.Out.WriteLineAsync(path);
        await Console.Out.WriteLineAsync(expected?.ToString());
        var jtoken = JToken.Parse(json);
        if (expected != null) {
            var date = jtoken.SelectDateOrThrow(path);
            var dateISO = date.ToString("O");
            await Console.Out.WriteLineAsync(dateISO);
            Assert.That(dateISO, Is.EqualTo(expected));
        } else {
            Assert.Throws<JsonHelperException>(() => jtoken.SelectDateOrThrow(path));
        }
    }
    /// <summary>
    ///     Guid selection test
    /// </summary>
    [TestCase("{\"field\": \"8c69a274-e68b-4b5e-bc1b-a465d234c2c0\"}", "$.field", "8c69a274-e68b-4b5e-bc1b-a465d234c2c0")]
    [TestCase("{\"field\":\"LLLLLLLL-e68b-4b5e-bc1b-a465d234c20\"}", "$.field", null)]
    [TestCase("{\"field\":\"hello\"}", "$.field", null)]
    public async Task SelectGuidTest(string json, string path, string? expected) {
        await Console.Out.WriteLineAsync(json);
        await Console.Out.WriteLineAsync(path);
        await Console.Out.WriteLineAsync(expected?.ToString());
        var jtoken = JToken.Parse(json);
        if (expected != null) {
            var guid = jtoken.SelectGuidOrThrow(path);
            var guidString = guid.ToString();
            await Console.Out.WriteLineAsync(guidString);
            Assert.That(guidString, Is.EqualTo(expected));
        } else {
            Assert.Throws<JsonHelperException>(() => jtoken.SelectGuidOrThrow(path));
        }
    }
    /// <summary>
    ///     Json token selection test
    /// </summary>
    [TestCase("{\"field\":{\"hello\":1,\"world\":2}}", "$.field", false)]
    [TestCase("{}", "$.field", true)]
    public async Task SelectObjectTest(string json, string path, bool expectedNull) {
        await Console.Out.WriteLineAsync(json);
        await Console.Out.WriteLineAsync(path);
        await Console.Out.WriteLineAsync(expectedNull.ToString());
        var jtoken = JToken.Parse(json);
        if (expectedNull == false) {
            jtoken.SelectOrThrow(path, JTokenType.Object);
        } else {
            Assert.Throws<JsonHelperException>(() => jtoken.SelectOrThrow(path, JTokenType.Object));
        }
    }
}
