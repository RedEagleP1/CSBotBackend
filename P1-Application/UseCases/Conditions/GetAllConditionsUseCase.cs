using MediatR;
using P1_Core;
using P1_Core.Entities;

namespace P1_Application.UseCases.Conditions
{

    public class GetAllConditionsUseCase : IRequestHandler<GetAllConditionsRequest, List<Condition>>
    {
        private readonly IRepository<Condition> _conditionRepository;
        private readonly IMediator _mediator;

        public GetAllConditionsUseCase(IMediator mediator, IRepository<Condition> conditionRepository)
        {
            _conditionRepository = conditionRepository;
            _mediator = mediator;
        }

        public async Task<List<Condition>> Handle(GetAllConditionsRequest request, CancellationToken cancellationToken)
        {
            List<Condition> getAllConditions = (List<Condition>)await _conditionRepository.GetAllAsync();
            await _mediator.Send(getAllConditions, cancellationToken);
            return getAllConditions;
        }
    }

    public class GetAllConditionsRequest : IRequest<List<Condition>>
    {

    }
}