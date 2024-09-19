using MediatR;
using P1_Core;
using P1_Core.Entities;

namespace P1_Application.UseCases
{
    public class GetAllEntitiesUseCase<T> : IRequestHandler<GetOneEntityRequest<T>, GetOneEntityResponse<T>> where T : BaseEntity
    {
        protected readonly IRepository<T> _repository;

        public GetAllEntitiesUseCase(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<GetOneEntityResponse<T>> Handle(GetOneEntityRequest<T> request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            return new GetOneEntityResponse<T>(entity);
        }
    }

    public class GetAllEntitiesResponse<T> where T : class
    {
        public T Entity { get; }

        public GetAllEntitiesResponse(T entity)
        {
            Entity = entity;
        }

    }

    public class GetAllEntitiesRequest<T> : IRequest<GetOneEntityResponse<T>> where T : class
    {
        public GetAllEntitiesRequest()
        {
        }
    }
}