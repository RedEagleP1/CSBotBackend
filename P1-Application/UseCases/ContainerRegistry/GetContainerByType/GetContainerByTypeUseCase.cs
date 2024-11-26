using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using P1_Application.Exceptions;
using P1_Core.Entities;
using P1_Core.Interfaces;

namespace P1_Application.UseCases.ContainerRegistry.GetContainerByType
{
    public class GetContainerByTypeUseCase : IRequestHandler<ContainerQuery, ContainerQueryResponse>
    {
        readonly IRepository<Container> _repository;
        readonly IMapper _mapper;
        readonly ILogger _logger;
        public GetContainerByTypeUseCase(IRepository<Container> repository, IMapper mapper, ILogger logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<ContainerQueryResponse> Handle(ContainerQuery request, CancellationToken cancellationToken)
        {
            // Get container by its type and check in repository for that container
            var container = _repository.Query().Where(x => x.Type == request.Type).Include<Container>("Children").FirstOrDefault();
            if (container != null) {
                // var response = await _repository.GetByIdAsync(container.Id);
                return _mapper.Map<ContainerQueryResponse>(container);
            }
            else {
                throw new P1Exception(_logger, "Container could not found");
            }
        }
    }

}