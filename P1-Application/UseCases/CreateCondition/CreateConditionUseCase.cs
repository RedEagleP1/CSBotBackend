using MediatR;
using P1_Core;
using P1_Core.Entities;


namespace P1_Application.UseCases.CreateCondition
{

    public class CreateConditionUseCase : IRequestHandler<CreateConditionRequest, int>
    {
        private readonly IRepository<Condition> _conditionRepository;
        private readonly IMediator _mediator;

        public CreateConditionUseCase(IMediator mediator, IRepository<Condition> conditionRepository)
        {
            _conditionRepository = conditionRepository;
            _mediator = mediator;
        }

        public async Task<int> Handle(CreateConditionRequest request, CancellationToken cancellationToken)
        {
            var addCondition = await _conditionRepository.AddAsync(request.Condition);
            await _mediator.Send(addCondition, cancellationToken);
            return addCondition;
        }
    }

    public class CreateConditionRequest : IRequest<int>
    {
        public Condition Condition { get; set; }
    }
}