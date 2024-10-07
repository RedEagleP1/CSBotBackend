public class ResponseFactory<TResponse>
{
    private readonly Dictionary<string, Func<Dictionary<string, object>, IResponse<TResponse>>> _responseBuilders = new();

    public void RegisterResponseBuilder(string type, Func<Dictionary<string, object>, IResponse<TResponse>> builder)
    {
        _responseBuilders[type] = builder;
    }

    public IResponse<TResponse> CreateResponseFromRecord(ResponseRecord record)
    {
        if (!_responseBuilders.TryGetValue(record.Type, out var builder))
        {
            throw new InvalidOperationException($"No builder registered for response type: {record.Type}");
        }
        return builder(record.Parameters);
    }
}
