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
            GetOneEntityRequest<Condition> getRequest = new GetOneEntityRequest<Condition>(request.Id);

            GetOneEntityResponse<Condition> response = new GetOneEntityUseCase<Condition>(_conditionRepository).Handle(getRequest, cancellationToken).Result;

            return new GetConditionResponse(response.Entity);
        }

    }

}