using MediatR;
using P1_Core;
using P1_Core.Entities;

namespace P1_Application.UseCases.Conditions.DeleteCondition
{
    public class DeleteConditionUseCase : IRequestHandler<DeleteConditionCommand, DeleteConditionResponse>
    {
        private readonly IRepository<Condition> _conditionRepository;

        public DeleteConditionUseCase(IRepository<Condition> conditionRepository)
        {
            _conditionRepository = conditionRepository;
        }

        public async Task<DeleteConditionResponse> Handle(DeleteConditionCommand request, CancellationToken cancellationToken)
        {
            DeleteOneEntityRequest<Condition> deleteRequest = new DeleteOneEntityRequest<Condition>(new Condition
            {
                Id = request.Id,
            });

            DeleteOneEntityResponse<Condition> response = new DeleteEntityUseCase<Condition>(_conditionRepository).Handle(deleteRequest, cancellationToken).Result;

            return new DeleteConditionResponse(deleteRequest.Entity);
        }

    }


}