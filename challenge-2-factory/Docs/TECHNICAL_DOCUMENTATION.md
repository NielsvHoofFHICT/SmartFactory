# Technical Documentation: Smart Factory API

## 1. Architecture Overview

The Smart Factory API follows a clean architecture pattern with clear separation of concerns. The application is
structured into four main layers:

### 1.1 Architecture Layers

```
Smart Factory API
├── Domain (Core Business Logic)
│   ├── Models
│   ├── Interfaces
│   └── Enums
├── Infrastructure (Data Access)
│   ├── Repositories
│   └── Data
├── API (Presentation)
│   ├── Controllers
│   └── Program.cs
└── Tests (Testing)
    └── Controllers
```

### 1.2 Layer Responsibilities

- **Domain Layer**
    - Contains core business models and interfaces
    - Defines the business rules and entities
    - Independent of external frameworks
    - Includes enums for machine types and statuses

- **Infrastructure Layer**
    - Implements data access and persistence
    - Contains repository implementations
    - Handles database context and migrations
    - Implements interfaces defined in Domain layer

- **API Layer**
    - Provides REST endpoints
    - Handles HTTP requests and responses
    - Configures dependency injection
    - Sets up middleware and services

- **Tests Layer**
    - Contains unit tests for controllers
    - Tests repository implementations
    - Uses Moq for mocking dependencies

## 2. Conceptual Model

### 2.1 Core Entities

The system is built around three main entities:

1. **Machine**
    - Represents physical machines in the factory
    - Tracks machine specifications and status
    - Has a one-to-many relationship with MachineActivity

2. **MachineActivity**
    - Records activities performed by machines
    - Tracks start and end times of activities
    - Links to specific machines

3. **Metric**
    - Stores performance measurements
    - Can be associated with machines or activities
    - Tracks various types of measurements

### 2.2 Class Diagram

[![](https://mermaid.ink/img/pako:eNqdU01v2zAM_SsCj6tbNP5IXV-Got1hQDMMaLfD4AsrM44wWzIkapgX5L9PTpwicLyimA4S9R5JkU_SFqSpCAqQDTr3oLC22JZahLFHxArlRmkS2wM4jAulWXyuTgDHVulafMGWTtAx9LnvSAzTOfXEyN6Jw3Ke79FIZGX0ObNC7dco2VuyM2xoqTmBH5DpWbUkvnorN-hoAOb4R3S8wtAeadRy6nbs0jCNxe5KPaPVnWT1S3H_Ls3GmIl0I3nMNFHvtd4gnOXBmiE_ik-6mnBj2n_p_UZnFDzk_zyCyviXhsR3bPxMJd-04rnGhskxtt1M8SZc4kyq-xBbG9u_r63jsy5hUYK4vAzGh2BMb7AQHdm1sa17O-wgTyFq0mRDIQ4iaMm2qKrwt_aylcAbCtJAEcwK7c8SSr0LfujZPPVaQsHWUwTW-HoDxRobF3a-q0K-8WMeXTrUP4x53VKl2NjV-JGHJYLaDkePGUlXZO-N1wxFtg-HYgu_oYjT66t8mcXXWR6naZJnSQR98Flc3cTLJI4XSZIv8mW6i-DP_sDBPb-NkyxN8zy5ifPdX7d1SJU?type=png)](https://mermaid.live/edit#pako:eNqdU01v2zAM_SsCj6tbNP5IXV-Got1hQDMMaLfD4AsrM44wWzIkapgX5L9PTpwicLyimA4S9R5JkU_SFqSpCAqQDTr3oLC22JZahLFHxArlRmkS2wM4jAulWXyuTgDHVulafMGWTtAx9LnvSAzTOfXEyN6Jw3Ke79FIZGX0ObNC7dco2VuyM2xoqTmBH5DpWbUkvnorN-hoAOb4R3S8wtAeadRy6nbs0jCNxe5KPaPVnWT1S3H_Ls3GmIl0I3nMNFHvtd4gnOXBmiE_ik-6mnBj2n_p_UZnFDzk_zyCyviXhsR3bPxMJd-04rnGhskxtt1M8SZc4kyq-xBbG9u_r63jsy5hUYK4vAzGh2BMb7AQHdm1sa17O-wgTyFq0mRDIQ4iaMm2qKrwt_aylcAbCtJAEcwK7c8SSr0LfujZPPVaQsHWUwTW-HoDxRobF3a-q0K-8WMeXTrUP4x53VKl2NjV-JGHJYLaDkePGUlXZO-N1wxFtg-HYgu_oYjT66t8mcXXWR6naZJnSQR98Flc3cTLJI4XSZIv8mW6i-DP_sDBPb-NkyxN8zy5ifPdX7d1SJU)

## 3. Database Design

# Technical Documentation: Smart Factory API

### 3.1 Entity Relationship Diagram (ERD)

[![](https://mermaid.ink/img/pako:eNqdU2Fr2zAQ_SviPrulke1U87eSFRZGx9jCYMVgNPvqiFmSkU9lXpr_PjlJ27UyY5s-GOvd0-ndO90OatsgFIDurZKtk7o0LKybq9W79Ydrtjtup6UMMdWwj--foYGcMi0zUmME0tjH4ECS_BDBna0lKWuigJbG38mavEMXB4Py7hltJCEpjaz3rt7KAasJmYl3cqBKy1APGmnq17zHoizhSem-NC9cqa5Wm_WX9ebr39mjZb1VBqtZm0Jx6l7RWL3060lscMxRNf3OBNE0r0J_9nm2puvNp_XqfxrdWP-tQ3YvOx8r8EbRjOLpE8TpPpZsQ9viPOFhYGvd-C_9YQ8PZ2d2F7erYCWEl1HCPP3oxG8kSECjC0-lCRNycKgE2mIwASZWI933ibYPPOnJfh5NDQU5jwk469stFHeyG8LO95MDpwl7Qntpbq3Vj0ewUWTdzXEeD2OZQOumu08pQ7vRraw3BMWCZ4cEUOzgBxQ8uzgXy5xf5IJnWSryNIERinxxfsmXKeeLNBULscz2Cfw8XDnRxRue5lkmRHrJxf4X7wE5QQ?type=png)](https://mermaid.live/edit#pako:eNqdU2Fr2zAQ_SviPrulke1U87eSFRZGx9jCYMVgNPvqiFmSkU9lXpr_PjlJ27UyY5s-GOvd0-ndO90OatsgFIDurZKtk7o0LKybq9W79Ydrtjtup6UMMdWwj--foYGcMi0zUmME0tjH4ECS_BDBna0lKWuigJbG38mavEMXB4Py7hltJCEpjaz3rt7KAasJmYl3cqBKy1APGmnq17zHoizhSem-NC9cqa5Wm_WX9ebr39mjZb1VBqtZm0Jx6l7RWL3060lscMxRNf3OBNE0r0J_9nm2puvNp_XqfxrdWP-tQ3YvOx8r8EbRjOLpE8TpPpZsQ9viPOFhYGvd-C_9YQ8PZ2d2F7erYCWEl1HCPP3oxG8kSECjC0-lCRNycKgE2mIwASZWI933ibYPPOnJfh5NDQU5jwk469stFHeyG8LO95MDpwl7Qntpbq3Vj0ewUWTdzXEeD2OZQOumu08pQ7vRraw3BMWCZ4cEUOzgBxQ8uzgXy5xf5IJnWSryNIERinxxfsmXKeeLNBULscz2Cfw8XDnRxRue5lkmRHrJxf4X7wE5QQ)

#### Relationship Types Explained:

1. **Machine to MachineActivity (One-to-Many)**
    - One machine can have many activities
    - Symbol: `||--o{`
    - Left side (`||`): One machine (mandatory)
    - Right side (`o{`): Many activities (optional)
    - Example: A CNC machine can have multiple production activities

2. **Machine to Metric (One-to-Many)**
    - One machine can have many metrics
    - Symbol: `||--o{`
    - Left side (`||`): One machine (mandatory)
    - Right side (`o{`): Many metrics (optional)
    - Example: A lathe machine can have multiple performance metrics

### 3.2 Database Tables

#### Machine Table

```sql
CREATE TABLE Machine
(
    Id                  INTEGER PRIMARY KEY AUTOINCREMENT,
    Name                NVARCHAR(100) NOT NULL,
    Type                INTEGER  NOT NULL,
    Status              INTEGER  NOT NULL,
    Location            NVARCHAR(100) NOT NULL,
    Manufacturer        NVARCHAR(100) NOT NULL,
    Model               NVARCHAR(100) NOT NULL,
    PurchaseDate        DATETIME NOT NULL,
    LastMaintenanceDate DATETIME NOT NULL,
    Notes               NVARCHAR(500)
);
```

#### MachineActivity Table

```sql
CREATE TABLE MachineActivity
(
    Id           INTEGER PRIMARY KEY AUTOINCREMENT,
    MachineName  NVARCHAR(100) NOT NULL,
    ActivityType NVARCHAR(50) NOT NULL,
    StartTime    DATETIME NOT NULL,
    EndTime      DATETIME,
    Status       NVARCHAR(50) NOT NULL,
    Notes        NVARCHAR(500)
);
```

#### Metric Table

```sql
CREATE TABLE Metric
(
    Id        INTEGER PRIMARY KEY AUTOINCREMENT,
    Name      NVARCHAR(100) NOT NULL,
    Value     REAL     NOT NULL,
    Unit      NVARCHAR(50) NOT NULL,
    Timestamp DATETIME NOT NULL,
    Source    NVARCHAR(100) NOT NULL,
    Category  NVARCHAR(50) NOT NULL,
    Notes     NVARCHAR(500)
);
```

### 3.3 CRUD Operations

#### Machine Operations

- **Create**: `POST /api/machine`
- **Read**:
    - `GET /api/machine` (all)
    - `GET /api/machine/{id}` (by ID)
    - `GET /api/machine/name/{name}` (by name)
    - `GET /api/machine/type/{type}` (by type)
    - `GET /api/machine/status/{status}` (by status)
- **Update**: `PUT /api/machine/{id}`
- **Delete**: `DELETE /api/machine/{id}`

#### MachineActivity Operations

- **Create**: `POST /api/machineactivity`
- **Read**:
    - `GET /api/machineactivity` (all)
    - `GET /api/machineactivity/{id}` (by ID)
    - `GET /api/machineactivity/search?machineName={name}` (by machine name)
    - `GET /api/machineactivity/date-range?startDate={date}&endDate={date}` (by date range)
- **Update**: `PUT /api/machineactivity/{id}`
- **Delete**: `DELETE /api/machineactivity/{id}`

#### Metric Operations

- **Create**: `POST /api/metric`
- **Read**:
    - `GET /api/metric` (all)
    - `GET /api/metric/{id}` (by ID)
    - `GET /api/metric/category/{category}` (by category)
    - `GET /api/metric/name/{name}` (by name)
- **Update**: `PUT /api/metric/{id}`
- **Delete**: `DELETE /api/metric/{id}`

## 4. Data Access Pattern

The application uses the Repository pattern for data access:

1. **Repository Interfaces** (in Domain layer)
    - Define contract for data operations
    - Independent of implementation details
    - Support dependency injection

2. **Repository Implementations** (in Infrastructure layer)
    - Implement repository interfaces
    - Use Entity Framework Core
    - Handle database operations
    - Manage transactions

3. **Dependency Injection**
    - Configured in Program.cs
    - Uses scoped lifetime for repositories
    - Enables unit testing with mock repositories

## 5. Testing Strategy

The application uses a comprehensive testing approach:

1. **Unit Tests**
    - Test controllers in isolation
    - Mock repository dependencies
    - Verify HTTP responses
    - Test business logic

2. **Test Coverage**
    - CRUD operations
    - Search and filter functionality
    - Error handling
    - Edge cases

3. **Test Organization**
    - Separate test classes per controller
    - Clear test naming conventions
    - Arrange-Act-Assert pattern
    - Mock objects for dependencies 