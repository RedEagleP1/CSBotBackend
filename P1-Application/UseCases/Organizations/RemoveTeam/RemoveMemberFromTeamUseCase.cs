using MediatR;
using Microsoft.EntityFrameworkCore;
using P1_Core;
using P1_Core.Interfaces;
using P1_Core.Services;
using P1_Application.Exceptions;
using AutoMapper;

using ILogger = Serilog.ILogger;
using P1_Core.Entities.JoinTables;

namespace P1_Application.UseCases.Teams.RemoveMemberFromOrganization
{
    public class RemoveTeamFromOrganizationUseCase : IRequestHandler<RemoveTeamFromOrganizationCommand>
    {
        private readonly IRepository<TeamOrganization> _TeamDiscordUserRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper; 

        public RemoveTeamFromOrganizationUseCase(IRepository<TeamOrganization> teamDiscordUserRepository, ILogger logger, IMapper mapper)
        {
            _TeamDiscordUserRepository = teamDiscordUserRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task Handle(RemoveTeamFromOrganizationCommand request, CancellationToken cancellationToken)
        {
            var mappedValue = _mapper.Map<>();
            await _TeamDiscordUserRepository.DeleteAsync(mappedValue);
        }
    }
}