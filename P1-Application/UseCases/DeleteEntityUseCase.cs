using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using P1_Core;
using P1_Core.Entities;

namespace P1_Application.UseCases
{
    public class DeleteEntityUseCase<T> : IRequestHandler<DeleteOneEntityRequest<T>, DeleteOneEntityResponse<T>> where T : BaseEntity
    {
        protected readonly IRepository<T> _repository;

        public DeleteEntityUseCase(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<DeleteOneEntityResponse<T>> Handle(DeleteOneEntityRequest<T> request, CancellationToken cancellationToken)
        {
            var entity = request.Entity;
            await _repository.DeleteAsync(entity);
            return new DeleteOneEntityResponse<T>(entity);
        }
    }

    public class DeleteOneEntityResponse<T> where T : class
    {
        public T Entity { get; set; }

        public DeleteOneEntityResponse(T entity)
        {
            Entity = entity;
        }
    }

    public class DeleteOneEntityRequest<T> : IRequest<DeleteOneEntityResponse<T>> where T : class
    {
        public T Entity { get; }
        public DeleteOneEntityRequest(T entity)
        {
            Entity = entity;
        }
    }
}