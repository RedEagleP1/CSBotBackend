using MediatR;
using P1_Core;
using P1_Core.Entities;

namespace P1_Application.UseCases
{
    public class GetOneEntityUseCase<T> : IRequestHandler<GetOneEntityRequest<T>, GetOneEntityResponse<T>> where T : BaseEntity
    {
        protected readonly IRepository<T> _repository;

        public GetOneEntityUseCase(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<GetOneEntityResponse<T>> Handle(GetOneEntityRequest<T> request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            return new GetOneEntityResponse<T>(entity);
        }
    }

    public class GetOneEntityResponse<T> : IRequest where T : BaseEntity
    {
        public GetOneEntityResponse(T entity)
        {
            Entity = entity;
        }

        public T Entity { get; }
    }

    public class GetOneEntityRequest<T> : IRequest<GetOneEntityResponse<T>> where T : BaseEntity
    {
        public int Id { get; }

        public GetOneEntityRequest(int id)
        {
            Id = id;
        }
    }
}