using MediatR;
using P1_Core;
using P1_Core.Entities;

namespace P1_Application.UseCases
{
    public class GetOneEntity<T> : IRequestHandler<GetOneEntityRequest<T>, GetOneEntityResponse<T>> where T : BaseEntity
    {
        protected readonly IRepository<T> _repository;

        public GetOneEntity(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<GetOneEntityResponse<T>> Handle(GetOneEntityRequest<T> request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            return new GetOneEntityResponse<T>(entity.Id);
        }
    }

    public class GetOneEntityResponse<T> where T : class
    {
        public GetOneEntityResponse(int id)
        {
            Id = id;
        }

        public int Id { get; }
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