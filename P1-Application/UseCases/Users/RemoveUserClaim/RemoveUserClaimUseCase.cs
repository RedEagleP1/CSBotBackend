using MediatR;

namespace P1_Application.UseCases.Users.RemoveUserClaim
{
    public class RemoveUserClaimUseCase : IRequestHandler<RemoveUserClaimCommand>
    {
        public async Task Handle(RemoveUserClaimCommand request, CancellationToken cancellationToken)
        {
            
        }
    }


    public class RemoveUserClaimCommand : IRequest
    {
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
