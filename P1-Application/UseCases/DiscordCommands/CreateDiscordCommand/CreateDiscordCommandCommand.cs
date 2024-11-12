using MediatR;

namespace P1_Application.UseCases.DiscordCommands.CreateDiscordCommand
{
    public class CreateDiscordCommandCommand : IRequest
    {
        public string Name { get; set; }
    }
}