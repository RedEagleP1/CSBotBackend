using MediatR;
using Microsoft.Extensions.Logging;
using P1_Core.Entities;
using P1_Core.Interfaces;

namespace P1_Application.UseCases.BaseUseCases
{
    public abstract class BaseUseCase<TEntity, TCommand> : IRequestHandler<TCommand>
        where TCommand : IRequest
        where TEntity : BaseEntity
    {
        protected readonly IRepository<TEntity> Repository;
        protected readonly ILogger Logger;

        protected BaseUseCase(IRepository<TEntity> repository, ILogger logger)
        {
            Repository = repository;
            Logger = logger;
        }

        public abstract Task Handle(TCommand request, CancellationToken cancellationToken);
    }
}