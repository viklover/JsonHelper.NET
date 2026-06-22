# JsonHelper.Net
[![Nuget](https://badge.fury.io/nu/JsonHelper.Net.svg)](https://badge.fury.io/nu/JsonHelper.Net)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/viklover/JsonHelper.Net/blob/master/LICENSE.txt)
![Linter workflow](https://github.com/viklover/JsonHelper.Net/actions/workflows/lint.yml/badge.svg)
![Unit tests workflow](https://github.com/viklover/JsonHelper.Net/actions/workflows/unit-tests.yml/badge.svg)

**JsonHelper.Net** provides typed, null-safe JSONPath querying for Newtonsoft.Json. Eliminate repetitive null checks and type validation when extracting values from `JToken` objects.

## Features

- **Typed selectors** — Extract `string`, `bool`, `int`, `float`, `DateTime`, `Guid`, `List<T>`, or raw `JToken` directly.
- **Two usage styles** — Use `JsonHelper.SelectString(json, path)` as a static helper or `jtoken.SelectString(path)` as a fluent extension method.
- **Nullable vs. throwing** — Every type provides a nullable method (returns `null` on missing/wrong type) and an `OrThrow` variant (throws `JsonHelperException` for strict validation).
- **Custom date parsing** — `SelectDate(path, format)` parses date strings from arbitrary formats via `DateTime.ParseExact`.
- **Type-safe JToken access** — `SelectOrThrow(path, JTokenType.Array)` validates the JSON token type at runtime.
- **Built on Newtonsoft.Json 13.0.4** — Targets .NET 7 with nullable reference type annotations.

## Quick start

```csharp
using Newtonsoft.Json.Linq;
using NewtonsoftJsonHelper;

var json = JToken.Parse("""
{
    "name": "Alice",
    "age": 30,
    "active": true,
    "score": 98.5,
    "joined": "2024-01-15T00:00:00",
    "id": "a1b2c3d4-e5f6-7890-abcd-ef1234567890"
}
""");

// --- Nullable style (returns null on missing/null/wrong type) ---
string? maybe  = json.SelectString("$.name");          // "Alice"
int?    age    = JsonHelper.SelectInt(json, "$.age");  // 30
bool?   admin  = json.SelectBoolean("$.admin");         // null (missing path)

// --- Throwing style (throws JsonHelperException on failure) ---
string   name  = json.SelectStringOrThrow("$.name");    // "Alice"
float    score = json.SelectFloatOrThrow("$.score");     // 98.5
Guid     id    = json.SelectGuidOrThrow("$.id");         // Guid
DateTime dt    = JsonHelper.SelectDateOrThrow(json, "$.joined"); // DateTime

// --- Without JsonHelper.Net (verbose boilerplate) ---
var nameToken = json.SelectToken("$.name");
var nameValue = nameToken?.ToObject<string>();
if (nameToken == null || nameValue == null)
    throw new Exception("Expected 'name' token");
```

## API Reference

All methods exist in two forms — static `JsonHelper` and fluent `JToken` extension methods:

| Category | Static (`JsonHelper`) | Extension (`JTokenExtensions`) |
|---|---|---|
| String | `SelectString(json, path)` / `SelectStringOrThrow(json, path)` | `SelectString(path)` / `SelectStringOrThrow(path)` |
| Boolean | `SelectBoolean(json, path)` / `SelectBooleanOrThrow(json, path)` | `SelectBoolean(path)` / `SelectBooleanOrThrow(path)` |
| Integer | `SelectInt(json, path)` / `SelectIntOrThrow(json, path)` | `SelectInt(path)` / `SelectIntOrThrow(path)` |
| Float | `SelectFloat(json, path)` / `SelectFloatOrThrow(json, path)` | `SelectFloat(path)` / `SelectFloatOrThrow(path)` |
| DateTime | `SelectDate(json, path)` / `SelectDateOrThrow(json, path)` | `SelectDate(path)` / `SelectDateOrThrow(path)` |
| DateTime (format) | `SelectDate(json, path, format)` / `SelectDateOrThrow(json, path, format)` | `SelectDate(path, format)` / `SelectDateOrThrow(path, format)` |
| Guid | `SelectGuid(json, path)` / `SelectGuidOrThrow(json, path)` | `SelectGuid(path)` / `SelectGuidOrThrow(path)` |
| List\<T\> | `SelectList\<T\>(json, path)` / `SelectListOrThrow\<T\>(json, path)` | `SelectList\<T\>(path)` / `SelectListOrThrow\<T\>(path)` |
| JToken | `Select(json, path, params JTokenType[])` / `SelectOrThrow(json, path, params JTokenType[])` | `Select(path, params JTokenType[])` / `SelectOrThrow(path, params JTokenType[])` |

- **Nullable methods** return `T?` and return `null` when the token is missing, null, or of the wrong type.
- **OrThrow methods** return `T` (non-nullable) and throw `JsonHelperException` when the token cannot be resolved.

## Advanced usage

### Date with custom format

```csharp
var json = JToken.Parse("""{"published": "12/25/2023"}""");

// Parse a string using DateTime.ParseExact
DateTime christmas = json.SelectDateOrThrow("$.published", "MM/dd/yyyy");
```

### List of values

```csharp
var json = JToken.Parse("""{"ratings": [4.5, 3.8, 5.0, 2.1]}""");
List<float> ratings = json.SelectListOrThrow<float>("$.ratings");
```

### Raw JToken with type validation

```csharp
var json = JToken.Parse("""{"metadata": {"key": "value"}}""");

// Validates the token is an object, returns the JToken
JToken meta = json.SelectOrThrow("$.metadata", JTokenType.Object);

// Works with multiple acceptable types
JToken field = json.Select("$.metadata", JTokenType.Object, JTokenType.String);
```

## Why JsonHelper.Net?

Without this library, extracting typed values from `JToken` requires manual null checks and type validation every time:

```csharp
// Manual checks every time
var token = json.SelectToken("$.some.path");
string? value = null;
if (token != null && token.Type == JTokenType.String)
    value = token.ToObject<string>();
if (value == null)
    throw new Exception("Expected string at $.some.path");
```

With JsonHelper.Net this becomes a single call:

```csharp
string value = json.SelectStringOrThrow("$.some.path");
```

The library handles:
- JSONPath resolution
- Null checks (`SelectToken` can return `null`)
- Type validation (checks the `JTokenType` before converting)
- Parsing conversions (Guid from string, DateTime from string with format)
- Clear exception messages on failure

## Installation
Nuget page is [here](https://www.nuget.org/packages/JsonHelper.Net)

## Contribution
Pull requests are welcome! I will gladly review any feature suggestions and consider them for inclusion in the library.
