using MediatR;
using P1_Core;
using P1_Core.Entities;

namespace P1_Application.UseCases.UpdateCondition
{

    public class UpdateConditionUseCase : IRequestHandler<UpdateConditionRequest, int>
    {
        private readonly IRepository<Condition> _conditionRepository;
        private readonly IMediator _mediator;

        public UpdateConditionUseCase(IMediator mediator, IRepository<Condition> conditionRepository)
        {
            _conditionRepository = conditionRepository;
            _mediator = mediator;
        }

        public async Task<int> Handle(UpdateConditionRequest request, CancellationToken cancellationToken)
        {
            await _conditionRepository.UpdateAsync(request.Condition);
            //await _mediator.Send(updateEntity, cancellationToken);
            return request.Condition.Id;
        }
    }

    public class UpdateConditionRequest : IRequest<int>
    {
        public Condition Condition { get; set; }
    }
}