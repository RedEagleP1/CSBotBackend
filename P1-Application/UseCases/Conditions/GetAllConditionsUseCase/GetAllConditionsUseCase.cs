using MediatR;
using P1_Core;
using P1_Core.Entities;

namespace P1_Application.UseCases.Conditions.GetAllConditions
{

    public class GetAllConditionsUseCase : IRequestHandler<GetAllConditionsQuery, GetAllConditionsResponse>
    {
        private readonly IRepository<Condition> _conditionRepository;

        public GetAllConditionsUseCase(IRepository<Condition> conditionRepository)
        {
            _conditionRepository = conditionRepository;
        }

        public async Task<GetAllConditionsResponse> Handle(GetAllConditionsQuery request, CancellationToken cancellationToken)
        {
            List<Condition> getAllConditions = (List<Condition>) await _conditionRepository.GetAllAsync();
            return new GetAllConditionsResponse(getAllConditions);
        }
    }



}