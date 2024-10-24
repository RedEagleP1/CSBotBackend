using MediatR;
using Microsoft.AspNetCore.Identity;
using P1_Application.Boundaries;

namespace P1_Application.UseCases.Users.AddUserClaim
{
    public class AddUserClaimUseCase : IRequestHandler<AddUserClaimCommand>
    {
        private readonly IUserClaimsService _userClaimsService;
        public AddUserClaimUseCase(IUserClaimsService userClaimsService)
        {
            _userClaimsService = userClaimsService;
        }
        
        public async Task Handle(AddUserClaimCommand request, CancellationToken cancellationToken)
        {
            await _userClaimsService.AddClaimToUser(request.UserId, request.ClaimType, request.ClaimValue);
        }
    }

    public class AddUserClaimCommand : IRequest
    {
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }

}
