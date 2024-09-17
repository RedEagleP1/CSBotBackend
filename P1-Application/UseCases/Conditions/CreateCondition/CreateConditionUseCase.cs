using MediatR;
using P1_Application.UseCases.Conditions.CreateCondition;
using P1_Core;
using P1_Core.Entities;


namespace P1_Application.UseCases.Conditions.CreateCondition
{

    public class CreateConditionUseCase : IRequestHandler<CreateConditionCommand, CreateConditionResponse>
    {
        private readonly IRepository<Condition> _conditionRepository;

        public CreateConditionUseCase(IRepository<Condition> conditionRepository)
        {
            _conditionRepository = conditionRepository;
        }

        public async Task<CreateConditionResponse> Handle(CreateConditionCommand request, CancellationToken cancellationToken)
        {
            var addedEntityId = await _conditionRepository.AddAsync(new Condition
            {
                Name = request.Name,
                Description = request.Description
            });
            return new CreateConditionResponse(addedEntityId);
        }

    }
}