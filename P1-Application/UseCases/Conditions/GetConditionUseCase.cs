using MediatR;
using P1_Core;
using P1_Core.Entities;

namespace P1_Application.UseCases.GetCondition
{

    public class GetConditionUseCase : IRequestHandler<GetConditionRequest, Condition>
    {
        private readonly IRepository<Condition> _conditionRepository;
        private readonly IMediator _mediator;

        public GetConditionUseCase(IMediator mediator, IRepository<Condition> conditionRepository)
        {
            _conditionRepository = conditionRepository;
            _mediator = mediator;
        }

        public async Task<Condition> Handle(GetConditionRequest request, CancellationToken cancellationToken)
        {
            Condition getCondition = await _conditionRepository.GetByIdAsync(request.Id);
            await _mediator.Send(getCondition, cancellationToken);
            return getCondition;
        }
    }

    public class GetConditionRequest : IRequest<Condition>
    {
        public int Id { get; set; }
    }
}