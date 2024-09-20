using MediatR;
using P1_Core;
using P1_Core.Entities;

namespace P1_Application.UseCases.Conditions.UpdateCondition
{

    public class UpdateConditionUseCase : IRequestHandler<UpdateConditionCommand, UpdateConditionResponse>
    {
        private readonly IRepository<Condition> _conditionRepository;

        public UpdateConditionUseCase(IMediator mediator, IRepository<Condition> conditionRepository)
        {
            _conditionRepository = conditionRepository;
        }

        public async Task<UpdateConditionResponse> Handle(UpdateConditionCommand request, CancellationToken cancellationToken)
        {
            await _conditionRepository.UpdateAsync(request.Condition);

            return new UpdateConditionResponse(request.Condition);
        }
    }


}