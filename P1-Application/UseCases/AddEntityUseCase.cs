using MediatR;
using P1_Core;

namespace P1_Application.UseCases
{
    public class AddEntityUseCase<T> : IRequestHandler<AddOneEntityRequest<T>, AddOneEntityResponse> where T : class
    {
        protected readonly IAsyncRepository<T> _repository;

        public AddEntityUseCase(IAsyncRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<AddOneEntityResponse> Handle(AddOneEntityRequest<T> request, CancellationToken cancellationToken)
        {
            var entity = request.Entity;
            var result = await _repository.Add(entity);
            return new AddOneEntityResponse(result);
        }
    }

    public class AddOneEntityResponse
    {
        public int Id { get; }
        public AddOneEntityResponse(int id)
        {
            Id = id;
        }
    }

    public class AddOneEntityRequest<T>: IRequest<AddOneEntityResponse> where T : class
    {
        public T Entity { get; }
        public AddOneEntityRequest(T entity)
        {
            Entity = entity;
        }
    }
}