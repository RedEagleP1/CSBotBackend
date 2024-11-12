using MediatR;

namespace P1_Application.UseCases.DiscordCommands.CreateDiscordCommand
{
    public class CreateDiscordCommandUseCase : IRequestHandler<CreateDiscordCommandCommand>
    {
        public Task Handle(CreateDiscordCommandCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}