using MediatR;
using P1_Core;
using P1_Core.Entities;

namespace P1_Application.UseCases.Conditions.UpdateCondition
{

    public class UpdateConditionUseCase : IRequestHandler<UpdateConditionCommand, UpdateConditionResponse>
    {
        private readonly IRepository<Condition> _conditionRepository;
        private readonly IMediator _mediator;

        public UpdateConditionUseCase(IMediator mediator, IRepository<Condition> conditionRepository)
        {
            _conditionRepository = conditionRepository;
            _mediator = mediator;
        }

        public async Task<UpdateConditionResponse> Handle(UpdateConditionCommand request, CancellationToken cancellationToken)
        {
            await _conditionRepository.UpdateAsync(request.Condition);
            //await _mediator.Send(updateEntity, cancellationToken);

            return new UpdateConditionResponse(request.Condition);
        }
    }


}