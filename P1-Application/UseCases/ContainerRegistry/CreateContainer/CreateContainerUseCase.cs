using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using P1_Application.UseCases.BaseUseCases;
using P1_Core.Entities;
using P1_Core.Interfaces;

namespace P1_Application.UseCases.ContainerRegistry.CreateContainer
{


    public class CreateContainerUseCase(IRepository<Container> repository, IMapper mapper, ILogger<CreateContainerUseCase> logger) : BaseUseCase<Container, ContainerRequestCommand>(repository, logger)
    {
        IMapper _mapper = mapper;

        public override async Task Handle(ContainerRequestCommand request, CancellationToken cancellationToken)
        {
            var mappedValue = _mapper.Map<Container>(request);
            await Repository.AddAsync(mappedValue);
        }
    }
}