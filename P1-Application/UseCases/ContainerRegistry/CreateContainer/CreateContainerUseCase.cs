using AutoMapper;
using MediatR;
using P1_Core.Entities;
using P1_Core.Interfaces;

namespace P1_Application.UseCases.ContainerRegistry.CreateContainer
{


    public class CreateContainerUseCase : IRequestHandler<ContainerRequestCommand>
    {
        IRepository<Container> _repository;
        IMapper _mapper;

        public CreateContainerUseCase(IRepository<Container> repository, IMapper mapper){
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(ContainerRequestCommand request, CancellationToken cancellationToken)
        {
            var mappedValue = _mapper.Map<Container>(request);
            await _repository.AddAsync(mappedValue);
        }
    }
}