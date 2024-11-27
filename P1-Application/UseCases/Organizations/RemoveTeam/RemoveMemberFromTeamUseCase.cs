using MediatR;
using P1_Core.Interfaces;
using AutoMapper;
using P1_Core.Entities.JoinTables;
using Microsoft.Extensions.Logging;

namespace P1_Application.UseCases.Teams.RemoveMemberFromOrganization
{
    public class RemoveTeamFromOrganizationUseCase : IRequestHandler<RemoveTeamFromOrganizationCommand>
    {
        private readonly IRepository<TeamOrganization> _TeamDiscordUserRepository;
        private readonly IMapper _mapper; 

        public RemoveTeamFromOrganizationUseCase(IRepository<TeamOrganization> teamDiscordUserRepository, IMapper mapper)
        {
            _TeamDiscordUserRepository = teamDiscordUserRepository;
            _mapper = mapper;
        }

        public async Task Handle(RemoveTeamFromOrganizationCommand request, CancellationToken cancellationToken)
        {
            //var mappedValue = _mapper.Map<>();
            //await _TeamDiscordUserRepository.DeleteAsync(mappedValue);
        }
    }
}