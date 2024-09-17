
using MediatR;
using P1_Core;
using P1_Core.Entities;

namespace P1_Application.UseCases
{

    public class UpdateEntityUseCase<T> : IRequestHandler<UpdateOneEntityRequest<T>> where T : BaseEntity
    {
        protected readonly IRepository<T> _repository;

        public UpdateEntityUseCase(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOneEntityRequest<T> request, CancellationToken cancellationToken)
        {
            var entity = request.Entity;
            await _repository.UpdateAsync(entity);
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