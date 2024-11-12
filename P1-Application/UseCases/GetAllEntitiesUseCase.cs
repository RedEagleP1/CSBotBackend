using MediatR;
using P1_Core;
using P1_Core.Entities;

namespace P1_Application.UseCases
{
    public class GetAllEntitiesUseCase<T> : IRequestHandler<GetAllEntitiesRequest<T>, GetAllEntitiesResponse<T>> where T : BaseEntity
    {
        protected readonly IRepository<T> _repository;

        public GetAllEntitiesUseCase(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<GetAllEntitiesResponse<T>> Handle(GetAllEntitiesRequest<T> request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync();
            return new GetAllEntitiesResponse<T>(entities);
        }
    }

    public class GetAllEntitiesResponse<T> where T : BaseEntity
    {
        public IEnumerable<T> Entities { get; }

        public GetAllEntitiesResponse(IEnumerable<T> entities)
        {
            Entities = entities;
        }

    }

    public class GetAllEntitiesRequest<T> : IRequest<GetAllEntitiesResponse<T>> where T : BaseEntity
    {
    }
}