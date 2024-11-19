using P1_Core.Interfaces;

namespace P1_Application.RulesEngine
{

    public class ResultFactory<TResult>
    {
        private readonly Dictionary<string, Func<Dictionary<string, object>, IResult<TResult>>> _responseBuilders = new();

        public void RegisterResponseBuilder(string type, Func<Dictionary<string, object>, IResult<TResult>> builder)
        {
            _responseBuilders[type] = builder;
        }

        public IResult<TResult> CreateResponseFromRecord(ResultRecord record)
        {
            if (!_responseBuilders.TryGetValue(record.Type, out var builder))
            {
                throw new InvalidOperationException($"No builder registered for response type: {record.Type}");
            }
            return builder(record.Parameters);
        }
    }
}
