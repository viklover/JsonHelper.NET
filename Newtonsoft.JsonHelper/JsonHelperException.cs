namespace NewtonsoftJsonHelper;
/// <summary>
///     Json helper exception
/// </summary>
public class JsonHelperException : Exception {
    /// <summary>
    ///     Constructor of json helper exception
    /// </summary>
    public JsonHelperException() : base() {}
    /// <summary>
    ///     Constructor of json helper exception
    /// </summary>
    /// <param name="message">Message</param>
    public JsonHelperException(string message) : base(message) {}
    /// <summary>
    ///     Constructor of json helper exception
    /// </summary>
    /// <param name="message">Message</param>
    /// <param name="innerException">Inner exception</param>
    public JsonHelperException(string message, Exception innerException) : base(message, innerException) {}
}