using MediatR;
using P1_Core;
using P1_Core.Entities;

namespace P1_Application.UseCases.Conditions.GetCondition
{

    public class GetConditionUseCase : IRequestHandler<GetConditionQuery, GetConditionResponse>
    {
        private readonly IRepository<Condition> _conditionRepository;

        public GetConditionUseCase(IRepository<Condition> conditionRepository)
        {
            _conditionRepository = conditionRepository;
        }

        public async Task<GetConditionResponse> Handle(GetConditionQuery request, CancellationToken cancellationToken)
        {
            var getCondition = await _conditionRepository.GetByIdAsync(request.Id);
            return new GetConditionResponse
            {
                Id = getCondition.Id,
                Name = getCondition.Name,
                Description = getCondition.Description
            };
        }

    }
}