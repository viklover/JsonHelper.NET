# Newtonsoft.Json helper
[![Nuget](https://badge.fury.io/nu/JsonHelper.Net.svg)](https://badge.fury.io/nu/JsonHelper.Net)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/viklover/JsonHelper.Net/blob/master/LICENSE.txt)
![Linter workflow](https://github.com/viklover/JsonHelper.Net/actions/workflows/lint.yml/badge.svg)
![Unit tests workflow](https://github.com/viklover/JsonHelper.Net/actions/workflows/unit-tests.yml/badge.svg)

Extension methods for Newtonsoft.Json library.

Now you can select JSON tokens by [paths](https://en.wikipedia.org/wiki/JSONPath) without nullability checks:
```csharp
var json = JToken.Parse("{\"hello\":\"world\"}");

// Newtonsoft.Json approach
var worldToken = json.SelectToken("$.world");
var worldTokenValue = worldToken?.ToObject<string>();
if (worldToken == null || worldTokenValue == null) {
    throw Exception("Expected 'world' token");
}

// JsonHelper.Net approach
var world = json.SelectStringOrThrow("$.world");
```
You can also select .NET native types like `Guid` or `DateTime`:

```csharp
// {"guid":"b3f3f9bc-8b7d-4199-971b-6c35152412da","date":"2024-01-05T00:00:00.0000000"}

Guid guid = json.SelectGuid("$.guid")
DateTime date = json.SelectDate("$.date");

// use `SelectGuidOrThrow` or 'SelectDateOrThrow' if expected non-nullable value
```

If you need to select raw complex JToken objects, the helper provides some useful methods:
```csharp
// {"dict":{"body":["a","b","c",{"foo":"bar"}]}}

JToken body = json.SelectOrThrow("$.dict.body", JTokenType.Array);
```

Selecting `List<T>`:

```csharp
// {"list":[1, -0.92, 3.47, 4]}
var list = json.SelectListOrThrow<float>("$.list");
```

## Installation
```bash
dotnet add package JsonHelper.Net --version 1.0.4
```
Nuget page is [here](https://www.nuget.org/packages/JsonHelper.Net)

## Contribution
Pull requests are welcome! I will gladly review any feature suggestions and consider them for inclusion in the library.
