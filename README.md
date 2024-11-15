
<!--TODO this needs to be cleaned up for readability -->

```mermaid
graph TB
    subgraph P1-Api
        API[API Controllers]
        Auto[AutoMapper]
    end

    subgraph P1-Application
        UC[Use Cases]
        MED[MediatR]
        SVC[Services]
        BND[Boundaries]
    end

    subgraph P1-Core
        ENT[Entities]
        EVT[Events]
    end

    subgraph P1-Infrastructure
        DB[(MySQL Database)]
        CTX[DbContext]
        IDEN[Identity]
        REPO[Repositories]
    end

    API --> |Commands/Queries| MED
    MED --> |Handlers| UC
    UC --> |Uses| SVC
    UC --> |Data Access| REPO
    UC --> |Domain Model| ENT
    SVC --> |Domain Logic| ENT
    REPO --> |EF Core| CTX
    CTX --> |CRUD| DB
    IDEN --> |Auth| CTX
    API --> |Maps DTOs| Auto
    Auto --> |Entity Models| ENT
    BND --> |Interfaces| UC
```


Here's a diagram showing trunk-based development along with an explanation:

```mermaid
gitGraph
    commit
    commit
    branch feature1
    checkout feature1
    commit
    commit
    checkout main
    merge feature1
    branch feature2
    checkout feature2
    commit
    checkout main
    merge feature2
    commit
    branch feature3
    checkout feature3
    commit
    commit
    checkout main
    merge feature3
```

Trunk-Based Development (TBD) is a branching strategy where developers collaborate on code in a single branch called 'trunk' (usually 'main' or 'master'). Key characteristics:

1. Short-lived feature branches
   - Developers create branches for new work
   - Branches typically last 1-2 days
   - Merged back to trunk frequently

2. Continuous Integration
   - All developers merge to trunk at least once per day
   - Automated tests run on every merge
   - Keeps integration problems small and manageable

3. Small commits
   - Changes are broken into small, manageable pieces
   - Makes code review easier
   - Reduces merge conflicts

4. Release branches (optional) - not currently used
   - Created only when needed for releases
   - No development happens on release branches
   - Only hotfixes applied to release branches

This approach supports continuous integration and delivery by keeping the mainline stable and reducing merge conflicts through frequent integration.

```mermaid
journey
    section Discord
        User types command: 5: User
        Discord receives command: 5: Discord
        Bot parses command: 3: Bot
    section Backend
        API receives request: 3: API
        Command handler processes: 3: Handler
        Database operation: 3: Database
    section Response
        API sends response: 3: API
        Bot formats message: 4: Bot
        User sees result: 5: User
```


```mermaid
sequenceDiagram
    actor User
    participant Discord
    participant Bot
    participant API
    participant Handler
    participant DB

    User->>Discord: /command
    Discord->>Bot: Intercept command
    Bot->>API: HTTP POST /api/command
    API->>Handler: Command request
    Handler->>DB: Execute operation
    DB-->>Handler: Return result
    Handler-->>API: Process result
    API-->>Bot: HTTP Response
    Bot-->>Discord: Format response
    Discord-->>User: Display result
```