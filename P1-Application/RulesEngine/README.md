# Rules Engine System Documentation

## Overview

The rules engine provides a flexible system for defining and executing business rules with triggers, conditions, and results.

## Core Components

### 1. Rule Structure

```csharp
var rule = new Rule<Trigger, Context, Response> {
    Name = "Example Rule",
    Description = "Describes what the rule does",
    Trigger = trigger,    // When should this rule run?
    Condition = condition, // What conditions need to be met?
    Result = result      // What happens when conditions are met?
};
```

### 2. Creating Rule Components

```csharp
// 1. Define a Trigger
public class MessageTrigger : ITrigger<DiscordMessage> {
    public bool Check(DiscordMessage message) => 
        message.Content.StartsWith("!command");
}

// 2. Define a Condition
public class UserLevelCondition : ICondition<UserContext> {
    private readonly int _requiredLevel;
    public UserLevelCondition(int level) => _requiredLevel = level;
    public bool Evaluate(UserContext context) => 
        context.UserLevel >= _requiredLevel;
}

// 3. Define a Result
public class RewardResult : IResult<string> {
    private readonly int _rewardAmount;
    public RewardResult(int amount) => _rewardAmount = amount;
    public string Execute() => 
        $"Awarded {_rewardAmount} coins!";
}
```

### 3. Registering Components

```csharp
// Register trigger builders
triggerFactory.RegisterTriggerBuilder("MessageTrigger", 
    parameters => new MessageTrigger());

// Register condition builders
conditionFactory.RegisterTriggerBuilder("UserLevel", 
    parameters => new UserLevelCondition((int)parameters["level"]));

// Register result builders
resultFactory.RegisterResponseBuilder("Reward", 
    parameters => new RewardResult((int)parameters["amount"]));
```

### 4. Creating Rules from Records

```csharp
var ruleRecord = new RuleRecord {
    Id = 1,
    Name = "Reward Active Users",
    Description = "Gives coins to users above level 10",
    TriggerId = 1,
    ConditionId = 1,
    ResponseId = 1
};

var rule = await ruleFactory.CreateRuleAsync(ruleRecord);
```

### 5. Using the Rule Engine

```csharp
var engine = new RuleEngine<DiscordMessage, UserContext, string>();
engine.AddRule(rule);

// Process an event
var message = new DiscordMessage();
var context = new UserContext();
var results = engine.ProcessEvent(message, context);
```

## Database Records

```csharp
// Trigger Record
var trigger = new TriggerRecord {
    Id = 1,
    Type = "MessageTrigger",
    Parameters = new Dictionary<string, object>()
};

// Condition Record
var condition = new ConditionRecord {
    Id = 1,
    Type = "UserLevel",
    Parameters = new Dictionary<string, object> {
        { "level", 10 }
    }
};

// Result Record
var result = new ResultRecord {
    Id = 1,
    Type = "Reward",
    Parameters = new Dictionary<string, object> {
        { "amount", 100 }
    }
};
```

## Best Practices

1. Keep triggers, conditions, and results focused and single-purpose
2. Use meaningful names for rule components
3. Store configuration in Parameters dictionary
4. Handle rule creation exceptions
5. Use async operations where appropriate
6. Document complex rule logic
7. Use proper dependency injection

## Error Handling

```csharp
try {
    var rule = await ruleFactory.CreateRuleAsync(ruleRecord);
    engine.AddRule(rule);
} catch (InvalidOperationException ex) {
    // Handle missing builder registration
} catch (Exception ex) {
    // Handle other errors
}
```