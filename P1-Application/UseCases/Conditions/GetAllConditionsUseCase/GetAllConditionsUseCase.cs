using MediatR;
using P1_Core;
using P1_Core.Entities;

namespace P1_Application.UseCases.Conditions.GetAllConditions
{

    public class GetAllConditionsUseCase : IRequestHandler<GetAllConditionsQuery, GetAllConditionsResponse>
    {
        private readonly IRepository<Condition> _conditionRepository;
        private readonly IMediator _mediator;

        public GetAllConditionsUseCase(IMediator mediator, IRepository<Condition> conditionRepository)
        {
            _conditionRepository = conditionRepository;
            _mediator = mediator;
        }

        public async Task<GetAllConditionsResponse> Handle(GetAllConditionsQuery request, CancellationToken cancellationToken)
        {
            List<Condition> getAllConditions = (List<Condition>)await _conditionRepository.GetAllAsync();
            await _mediator.Send(getAllConditions, cancellationToken);
            return new GetAllConditionsResponse(getAllConditions);
        }
    }



}