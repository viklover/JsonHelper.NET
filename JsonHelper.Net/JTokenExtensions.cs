using Newtonsoft.Json.Linq;

namespace NewtonsoftJsonHelper;
/// <summary>
///     <see cref="JToken"/> extension methods
/// </summary>
public static class JTokenExtensions {
    /// <summary>
    ///     Read json token by expected <paramref name="tokenTypes"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <param name="tokenTypes">Expected json types</param>
    /// <returns>Resolved token or null</returns>
    /// <exception cref="JsonHelperException">Type mismatch</exception>
    public static JToken? Select(this JToken json, string path, params JTokenType[] tokenTypes) {
        return JsonHelper.Select(json, path, tokenTypes);
    }
    /// <summary>
    ///     Read json token by expected <paramref name="tokenTypes"/> or throw <see cref="JsonHelperException"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <param name="tokenTypes">Expected json types</param>
    /// <returns>Resolved token</returns>
    /// <exception cref="JsonHelperException">Unexpected token type</exception>
    public static JToken SelectOrThrow(this JToken json, string path, params JTokenType[] tokenTypes) {
        var token = Select(json, path, tokenTypes);
        if (token == null) {
            throw new JsonHelperException("Failed to select JToken: token is null");
        }
        return token;
    }
    /// <summary>
    ///     Select <see cref="string"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <returns>String value</returns>
    public static string? SelectString(this JToken json, string path) {
        return JsonHelper.SelectString(json, path);
    }
    /// <summary>
    ///     Select <see cref="string"/> or throw <see cref="JsonHelperException"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <returns>String value</returns>
    public static string SelectStringOrThrow(this JToken json, string path) {
        var token = SelectString(json, path);
        if (token == null) {
            throw new JsonHelperException("Failed to select JToken: token is null");
        }
        return token;
    }
    /// <summary>
    ///     Select <see cref="bool"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <returns>Boolean value</returns>
    public static bool? SelectBoolean(this JToken json, string path) {
        return JsonHelper.SelectBoolean(json, path);
    }
    /// <summary>
    ///     Select <see cref="bool"/> or throw <see cref="JsonHelperException"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <returns>Boolean value</returns>
    public static bool SelectBooleanOrThrow(this JToken json, string path) {
        var token = SelectBoolean(json, path);
        if (token == null) {
            throw new JsonHelperException("Failed to select JToken: token is null");
        }
        return token.Value;
    }
    /// <summary>
    ///     Select <see cref="int"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <returns>Integer value</returns>
    public static int? SelectInt(this JToken json, string path) {
        return JsonHelper.SelectInt(json, path);
    }
    /// <summary>
    ///     Select <see cref="int"/> or throw <see cref="JsonHelperException"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <returns>Integer value</returns>
    public static int SelectIntOrThrow(this JToken json, string path) {
        var token = SelectInt(json, path);
        if (token == null) {
            throw new JsonHelperException("Failed to select JToken: token is null");
        }
        return token.Value;
    }
    /// <summary>
    ///     Select <see cref="float"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <returns>Float value</returns>
    public static float? SelectFloat(this JToken json, string path) {
        return JsonHelper.SelectFloat(json, path);
    }
    /// <summary>
    ///     Select <see cref="int"/> or throw <see cref="JsonHelperException"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <returns>Float value</returns>
    public static float SelectFloatOrThrow(this JToken json, string path) {
        var token = SelectFloat(json, path);
        if (token == null) {
            throw new JsonHelperException("Failed to select JToken: token is null");
        }
        return token.Value;
    }
    /// <summary>
    ///     Select <see cref="List{T}"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <returns>Resolved <see cref="List{T}"/></returns>
    public static List<T>? SelectList<T>(this JToken json, string path) {
        return JsonHelper.SelectList<T>(json, path);
    }
    /// <summary>
    ///     Select <see cref="List{T}"/> or throw <see cref="JsonHelperException"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <returns>Resolved <see cref="List{T}"/></returns>
    public static List<T> SelectListOrThrow<T>(this JToken json, string path) {
        var token = SelectList<T>(json, path);
        if (token == null) {
            throw new JsonHelperException("Failed to select JToken: token is null");
        }
        return token;
    }
    /// <summary>
    ///     Select <see cref="T[]"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <returns>Resolved <see cref="T[]"/></returns>
    public static T[]? SelectArray<T>(this JToken json, string path) {
        return JsonHelper.SelectArray<T>(json, path);
    }
    /// <summary>
    ///     Select <see cref="T[]"/> or throw <see cref="JsonHelperException"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <returns>Resolved <see cref="T[]"/></returns>
    public static T[] SelectArrayOrThrow<T>(this JToken json, string path) {
        var token = SelectArray<T>(json, path);
        if (token == null) {
            throw new JsonHelperException("Failed to select JToken: token is null");
        }
        return token;
    }
    /// <summary>
    ///     Select <see cref="DateTime"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <returns>Resolved <see cref="DateTime"/></returns>
    public static DateTime? SelectDate(this JToken json, string path) {
        return JsonHelper.SelectDate(json, path);
    }
    /// <summary>
    ///     Select <see cref="DateTime"/> or throw <see cref="JsonHelperException"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <returns>Resolved <see cref="DateTime"/></returns>
    public static DateTime SelectDateOrThrow(this JToken json, string path) {
        var token = SelectDate(json, path);
        if (token == null) {
            throw new JsonHelperException("Failed to select JToken: token is null");
        }
        return token.Value;
    }
    /// <summary>
    ///     Select <see cref="DateTime"/> from string by format
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON Path</param>
    /// <param name="format">Date format</param>
    /// <returns>Date and time</returns>
    public static DateTime? SelectDate(this JToken json, string path, string format) {
        return JsonHelper.SelectDate(json, path, format);
    }
    /// <summary>
    ///     Select <see cref="DateTime"/> from string by format or throw <see cref="JsonHelperException"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON Path</param>
    /// <param name="format">Date format</param>
    /// <returns>Date and time</returns>
    public static DateTime SelectDateOrThrow(this JToken json, string path, string format) {
        var result = SelectDate(json, path, format);
        if (result == null) {
            throw new JsonHelperException($"Failed to select a datetime at {path} by format = '{format}'");
        }
        return result.Value;
    }
    /// <summary>
    ///     Select <see cref="Guid"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <returns>Resolved <see cref="Guid"/></returns>
    public static Guid? SelectGuid(this JToken json, string path) {
        return JsonHelper.SelectGuid(json, path);
    }
    /// <summary>
    ///     Select <see cref="Guid"/> or throw <see cref="JsonHelperException"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <returns>Resolved <see cref="Guid"/></returns>
    public static Guid SelectGuidOrThrow(this JToken json, string path) {
        var token = SelectGuid(json, path);
        if (token == null) {
            throw new JsonHelperException("Failed to select JToken: token is null");
        }
        return token.Value;
    }
}
