
using MediatR;
using P1_Core;

namespace P1_Application.UseCases
{

    public class UpdateEntityUseCase<T> : IRequestHandler<UpdateOneEntityRequest<T>> where T : class
    {
        protected readonly IAsyncRepository<T> _repository;

        public UpdateEntityUseCase(IAsyncRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOneEntityRequest<T> request, CancellationToken cancellationToken)
        {
            var entity = request.Entity;
            await _repository.Update(entity);
        }
    }

    public class UpdateOneEntityRequest<T> : IRequest where T : class
    {
        public UpdateOneEntityRequest(T entity)
        {
            Entity = entity;
        }
        public T Entity { get; }
    }
}