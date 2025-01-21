using Newtonsoft.Json.Linq;

namespace NewtonsoftJsonHelper;
/// <summary>
///     <see cref="JToken"/> extension methods
/// </summary>
public static class JTokenExtensions {
    /// <summary>
    ///     Read json token by expected <paramref name="tokenType"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <param name="tokenType">Expected json type</param>
    /// <returns>Resolved token or null</returns>
    /// <exception cref="JsonHelperException">Unexpected <paramref name="tokenType"/></exception>
    public static JToken? Select(this JToken json, string path, JTokenType tokenType) {
        return JsonHelper.Select(json, path, tokenType);
    }
    /// <summary>
    ///     Read json token by expected <paramref name="tokenType"/> or throw <see cref="JsonHelperException"/>
    /// </summary>
    /// <param name="json">Initial json token</param>
    /// <param name="path">JSON path</param>
    /// <param name="tokenType">Expected json type</param>
    /// <returns>Resolved token</returns>
    /// <exception cref="JsonHelperException">Unexpected <paramref name="tokenType"/></exception>
    public static JToken SelectOrThrow(this JToken json, string path, JTokenType tokenType) {
        var token = Select(json, path, tokenType);
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
