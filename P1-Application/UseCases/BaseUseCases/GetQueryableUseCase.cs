using MediatR;
using P1_Core;
using P1_Core.Entities;
using P1_Core.Interfaces;

namespace P1_Application.UseCases
{
    public class GetQueryableUseCase<T> : IRequestHandler<GetQueryableRequest<T>, GetQueryableResponse<T>> where T : BaseEntity
    {
        protected readonly IRepository<T> _repository;

        public GetQueryableUseCase(IRepository<T> repository)
        {
            _repository = repository;
        }

        public Task<GetQueryableResponse<T>> Handle(GetQueryableRequest<T> request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetQueryableResponse<T> { Queryable = _repository.Query() });
        }

        public IQueryable<T> Query()
        {
            return _repository.Query();
        }
    }

    public class GetQueryableRequest<T> : IRequest<GetQueryableResponse<T>> where T : class
    {
    }

    public class GetQueryableResponse<T> where T : class
    {
        public IQueryable<T> Queryable { get; set; }
    }
}