using AutoMapper;
using MediatR;

namespace P1_Application.Boundaries
{
    public class MappingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly IMapper _mapper;

        public MappingBehavior(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var commandType = request.GetType()
            .GetInterfaces()
            .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>))
            .Select(i => i.GetGenericArguments()[0])
            .FirstOrDefault();

            if (commandType != null)
            {
                // Map request to command
                var command = _mapper.Map(request, request.GetType(), commandType);
                // Update request with mapped command
                request = (TRequest)command;
            }
            

            return await next();
        }
    }

    internal interface IMapFrom<T>
    {
        void Mapping(Profile profile);
    }
}