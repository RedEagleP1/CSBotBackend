using MediatR;
using P1_Core;
using P1_Core.Entities;

namespace P1_Application.UseCases.DeleteCondition
{
    public class DeleteConditionUseCase
    {
        private readonly IRepository<Condition> _conditionRepository;
        private readonly IMediator _mediator;

        public DeleteConditionUseCase(IMediator mediator, IRepository<Condition> conditionRepository)
        {
            _conditionRepository = conditionRepository;
            _mediator = mediator;
        }

        public async Task<int> Handle(DeleteConditionRequest request, CancellationToken cancellationToken)
        {
            var deleteCondition = _conditionRepository.DeleteAsync(request.Id);
            return deleteCondition.Id;
        }

    }


    public class DeleteConditionRequest : IRequest<int>
    {
        public int Id { get; set; }
    }
}