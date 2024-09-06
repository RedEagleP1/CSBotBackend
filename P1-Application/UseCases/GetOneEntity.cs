using MediatR;
using P1_Core;

namespace P1_Application.UseCases
{
    public class GetOneEntity<T> : IRequestHandler<GetOneEntityRequest<T>, GetOneEntityResponse<T>> where T : class
    {
        protected readonly IAsyncRepository<T> _repository;

        public GetOneEntity(IAsyncRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<GetOneEntityResponse<T>> Handle(GetOneEntityRequest<T> request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetById(request.Id);
            return new GetOneEntityResponse<T>(entity);
        }
    }

    public class GetOneEntityResponse<T> where T : class
    {
        public GetOneEntityResponse(T entity)
        {
            Entity = entity;
        }

        public T Entity { get; }
    }

    public class GetOneEntityRequest<T> : IRequest<GetOneEntityResponse<T>> where T : class
    {
        public int Id { get; }

        public GetOneEntityRequest(int id)
        {
            Id = id;
        }
    }
}