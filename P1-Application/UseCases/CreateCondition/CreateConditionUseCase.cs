using MediatR;
using P1_Core.Entities;

namespace P1_Application.UseCases.CreateCondition {

    public class CreateConditionUseCase : IRequestHandler<CreateConditionRequest, int>
    {

        private readonly IMediator _mediator;
        public CreateConditionUseCase(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<int> Handle(CreateConditionRequest request, CancellationToken cancellationToken)
        {
            var addEntity = new AddOneEntityRequest<Condition>(request.condition);
            var result = await _mediator.Send(addEntity);
            return result.Id;
        }
    }

    public class CreateConditionRequest:IRequest<int>
    {
        public Condition condition { get; set;}
    }
}