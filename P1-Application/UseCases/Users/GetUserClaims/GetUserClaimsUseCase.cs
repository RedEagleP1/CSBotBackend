using MediatR;

namespace P1_Application.UseCases.Users.GetUserClaims 
{
    public class GetUserResponse {}
    public class GetUserQuery : IRequest<GetUserResponse> {

    }

    public class GetUserClaimsUseCase: IRequestHandler<GetUserQuery, GetUserResponse>
    {

        
        // private readonly UserManager<IApplicationUser> _userManager;
        public async Task<GetUserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken){
            return new GetUserResponse();
        }
    }

}