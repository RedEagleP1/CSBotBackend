using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using P1_Core;
using P1_Core.Interfaces;

namespace P1_Application.UseCases
{
    public class DeleteEntityUseCase<T> : IRequestHandler<DeleteOneEntityRequest<T>> where T : BaseEntity
    {
        protected readonly IRepository<T> _repository;

        public DeleteEntityUseCase(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteOneEntityRequest<T> request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
        }
    }

    public class DeleteOneEntityRequest<T> : IRequest where T : BaseEntity
    {
        public int Id { get; set; }
        public DeleteOneEntityRequest(int id)
        {
            Id = id;
        }
    }
}