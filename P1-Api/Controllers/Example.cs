// namespace P1_Api {
//     public interface ICondition
//     {
//         bool Evaluate(User user);
//     }

//     public class AgeCondition : ICondition
//     {
//         private readonly int _minAge;

//         public AgeCondition(int minAge)
//         {
//             _minAge = minAge;
//         }

//         public bool Evaluate(User user)
//         {
//             return user.Age >= _minAge;
//         }
//     }

//     public class AgeCondition : ICondition
//     {
//         private readonly int _minAge;

//         public AgeCondition(int minAge)
//         {
//             _minAge = minAge;
//         }

//         public bool Evaluate(User user)
//         {
//             return user.Age >= _minAge;
//         }
//     }

//     public class EvaluateRuleUseCase : IRequestHandler<EvaluateRuleCommand>
//     {
//         private readonly IRepository<Rule> _RuleRepository;
//         private readonly ConditionService _ConditionService;
//         private readonly IRepository<User> _UserRepository;

//         public EvaluateRuleUseCase(IRepository<Rule> ruleRepository, ConditionService conditionService, IRepository<User> userRepository)
//         {
//             _RuleRepository = ruleRepository;
//             _ConditionService = conditionService;
//             _UserRepository = userRepository;
//         }

//         public async Task Handle(EvaluateRuleCommand request, CancellationToken cancellationToken)
//         {
//             // Find the rule.
//             var rules = GetRules(request.RuleId);
//             if (rules.Count == 0) throw new P1Exception("Rule not found");

//             // Evaluate the rule
//             var user = await _UserRepository.GetByIdAsync(request.UserId);
//             foreach (var rule in rules)
//             {
//                 foreach (var condition in rule.Conditions)
//                 {
//                     if (!condition.Evaluate(user))
//                     {
//                         throw new P1Exception("Condition not met");
//                     }
//                 }
//             }

//             // Apply rewards
//             await ApplyRewards(user, rules);

//             await _UserRepository.UpdateAsync(user);
//         }

//         private async Task ApplyRewards(User user, IList<Rule> rules)
//         {
//             // Implementation for applying rewards
//         }

//         private IList<Rule> GetRules(IEnumerable<int> ruleIds)
//         {
//             return _RuleRepository.Query()
//                 .Include(r => r.Conditions)
//                 .Where(r => ruleIds.Contains(r.Id))
//                 .ToList();
//         }
//     }


// }