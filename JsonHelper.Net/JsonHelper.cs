using Newtonsoft.Json.Linq;

namespace JsonHelper.Net;
/// <summary>
///     Newtonsoft.Json helper
/// </summary>
public static class JsonHelper {
    /// <summary>
    ///     Read json token by expected <paramref name="tokenType"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <param name="tokenType">Expected json type</param>
    /// <returns>Resolved token or null</returns>
    /// <exception cref="JsonHelperException">Unexpected <paramref name="tokenType"/></exception>
    public static JToken? Select(JToken json, string path, JTokenType tokenType) {
        var token = json.SelectToken(path);
        if (token == null || token.Type == JTokenType.Null) {
            return null;
        }
        if (token.Type != tokenType) {
            throw new JsonHelperException($"Unexpected jTokenType: {token.Type} (instead of {tokenType})");
        }
        return token;
    }
    /// <summary>
    ///     Read json token by expected <paramref name="tokenType"/> or throw <see cref="JsonHelperException"/>
    /// </summary>
     /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <param name="tokenType">Expected json type</param>
    /// <returns>Resolved token</returns>
    /// <exception cref="JsonHelperException">Unexpected <paramref name="tokenType"/></exception>
    public static JToken SelectOrThrow(JToken json, string path, JTokenType tokenType) {
        var token = Select(json, path, tokenType);
        if (token == null) {
            throw new JsonHelperException($"Failed to select JToken: token is null");
        }
        return token;
    }
    /// <summary>
    ///     Select <see cref="string"/> 
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <returns>String value</returns>
    public static string? SelectString(JToken json, string path) {
        var token = Select(json, path, JTokenType.String);
        if (token == null) {
            return null;
        }
        return token.ToObject<string>();
    }
    /// <summary>
    ///     Select <see cref="string"/> or throw <see cref="JsonHelperException"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <returns>String value</returns>
    public static string SelectStringOrThrow(JToken json, string path) {
        var value = SelectString(json, path);
        if (value == null) {
            throw new JsonHelperException($"Failed to select a string at {path}");
        }
        return value;
    }
    /// <summary>
    ///     Select <see cref="bool"/> 
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <returns>Boolean value</returns>
    public static bool? SelectBoolean(JToken json, string path) {
        var token = Select(json, path, JTokenType.Boolean);
        if (token == null) {
            return null;
        }
        return token.ToObject<bool>();
    }
    /// <summary>
    ///     Select <see cref="bool"/> or throw <see cref="JsonHelperException"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <returns>Boolean value</returns>
    public static bool SelectBooleanOrThrow(JToken json, string path) {
        var value = SelectBoolean(json, path);
        if (value == null) {
            throw new JsonHelperException($"Failed to select a boolean at {path}");
        }
        return value.Value;
    }
    /// <summary>
    ///     Select <see cref="int"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <returns>Integer value</returns>
    public static int? SelectInt(JToken json, string path) {
        var token = Select(json, path, JTokenType.Integer);
        if (token == null) {
            return null;
        }
        return token.ToObject<int>();
    }
    /// <summary>
    ///     Select <see cref="int"/> or throw <see cref="JsonHelperException"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <returns>Integer value</returns>
    public static int? SelectIntOrThrow(JToken json, string path) {
        var value = SelectInt(json, path);
        if (value == null) {
            throw new JsonHelperException($"Failed to select a integer at {path}");
        }
        return value.Value;
    }
    /// <summary>
    ///     Select <see cref="float"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <returns>Float value</returns>
    public static float? SelectFloat(JToken json, string path) {
        var token = Select(json, path, JTokenType.Float);
        if (token == null) {
            return null;
        }
        return token.ToObject<float>();
    }
    /// <summary>
    ///     Select <see cref="int"/> or throw <see cref="JsonHelperException"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <returns>Float value</returns>
    public static float SelectFloatOrThrow(JToken json, string path) {
        var value = SelectFloat(json, path);
        if (value == null) {
            throw new JsonHelperException($"Failed to select a float at {path}");
        }
        return value.Value;
    }
    /// <summary>
    ///     Select <see cref="List{T}"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <returns>Resolved <see cref="List{T}"/></returns>
    public static List<T>? SelectList<T>(JToken json, string path) {
        var token = Select(json, path, JTokenType.Array);
        if (token == null) {
            return null;
        }
        return token.ToObject<List<T>>();
    }
    /// <summary>
    ///     Select <see cref="List{T}"/> or throw <see cref="JsonHelperException"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <returns>Resolved <see cref="List{T}"/></returns>
    public static List<T> SelectListOrThrow<T>(JToken json, string path) {
        var value = SelectList<T>(json, path);
        if (value == null) {
            throw new JsonHelperException($"Failed to select a list at {path}");
        }
        return value;
    }
    /// <summary>
    ///     Select <see cref="DateTime"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <returns>Resolved <see cref="DateTime"/></returns>
    public static DateTime? SelectDate(JToken json, string path) {
        var token = Select(json, path, JTokenType.Date);
        if (token == null) {
            return null;
        }
        return token.ToObject<DateTime>();
    }
    /// <summary>
    ///     Select <see cref="DateTime"/> or throw <see cref="JsonHelperException"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <returns>Resolved <see cref="DateTime"/></returns>
    public static DateTime SelectDateOrThrow(JToken json, string path) {
        var value = SelectDate(json, path);
        if (value == null) {
            throw new JsonHelperException($"Failed to select a datetime at {path}");
        }
        return value.Value;
    }
    /// <summary>
    ///     Select <see cref="Guid"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <returns>Resolved <see cref="Guid"/></returns>
    public static Guid? SelectGuid(JToken json, string path) {
        var guidRaw = SelectString(json, path);
        if (guidRaw == null) {
            return null;
        }
        try {
            return Guid.Parse(guidRaw);
        } catch (FormatException exception) {
            throw new JsonHelperException($"Failed to resolve a guid at {path}", exception);
        }
    }
    /// <summary>
    ///     Select <see cref="Guid"/> or throw <see cref="JsonHelperException"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <returns>Resolved <see cref="Guid"/></returns>
    public static Guid SelectGuidOrThrow(JToken json, string path) {
        var value = SelectGuid(json, path);
        if (value == null) {
            throw new JsonHelperException($"Failed to select a guid at {path}");
        }
        return value.Value;
    }
}