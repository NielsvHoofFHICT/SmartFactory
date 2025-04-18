# Smart Factory API

A C# Web API application for tracking and managing machine activities, machines, and metrics in a smart factory environment.

## Features

- Track machine activities (production, maintenance, idle time)
- Manage machine inventory and status
- Track performance metrics
- Search activities by machine name
- Filter activities by date range
- RESTful API endpoints for CRUD operations
- SQLite database for data persistence
- Docker support for containerized deployment

## Architecture

The application follows SOLID principles and clean architecture:

- **Domain**: Contains business models, interfaces, and enums
  - Models: `MachineActivity`, `Machine`, `Metric`
  - Interfaces: `IMachineActivityRepository`, `IMachineRepository`, `IMetricRepository`
  - Enums: `MachineType`, `MachineStatus`
- **Infrastructure**: Implements data access and repository pattern
  - Repositories: `MachineActivityRepository`, `MachineRepository`, `MetricRepository`
  - Data: `FactoryDbContext`
- **API**: Provides REST endpoints and application configuration
  - Controllers: `MachineActivityController`, `MachineController`, `MetricController`
- **Tests**: Unit tests for controllers and repositories

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- Visual Studio 2022 or VS Code with C# extensions
- Docker (optional, for containerized deployment)

### Installation

1. Clone the repository
2. Open the solution in your IDE
3. Restore NuGet packages
4. Build the solution

### Running the Application

#### Local Development
1. Set the API project as the startup project
2. Run the application
3. access the API at your localhost address, depending on how you are running it (e.g., `http://localhost:5282/api`) 

#### Docker
1. Build the Docker image: `docker build -t smart-factory-api .`
2. Run the container: `docker run -p 5001:5001 smart-factory-api`

## API Endpoints

## Base URL: `http://localhost:5282/api`

### Machine Activities
- `GET /api/machineactivity`: Get all machine activities
- `GET /api/machineactivity/{id}`: Get activity by ID
- `POST /api/machineactivity`: Create new activity
- `PUT /api/machineactivity/{id}`: Update existing activity
- `DELETE /api/machineactivity/{id}`: Delete activity
- `GET /api/machineactivity/search?machineName={name}`: Search by machine name
- `GET /api/machineactivity/date-range?startDate={date}&endDate={date}`: Filter by date range

### Machines
- `GET /api/machine`: Get all machines
- `GET /api/machine/{id}`: Get machine by ID
- `GET /api/machine/name/{name}`: Get machine by name
- `GET /api/machine/type/{type}`: Get machine by type
- `GET /api/machine/status/{status}`: Get machine by status
- `GET /api/machine/location/{location}`: Get machine by location
- `GET /api/machine/manufacturer/{manufacturer}`: Get machine by manufacturer
- `GET /api/machine/model/{model}`: Get machine by model
- `POST /api/machine`: Create new machine
- `PUT /api/machine/{id}`: Update existing machine
- `DELETE /api/machine/{id}`: Delete machine

### Metrics
- `GET /api/metric`: Get all metrics
- `GET /api/metric/{id}`: Get metric by ID
- `POST /api/metric`: Create new metric
- `PUT /api/metric/{id}`: Update existing metric
- `DELETE /api/metric/{id}`: Delete metric
- `GET /api/metric/category/{category}`: Get metrics by category
- `GET /api/metric/name/{name}`: Get metrics by name

## Database

The application uses SQLite for data persistence. The database file (`SmartFactory.db`) is automatically created in the API project directory when the application first runs. The database schema includes tables for:

- MachineActivities
- Machines
- Metrics

## Testing

The project includes comprehensive unit tests for:
- Controllers: `MachineActivityController`, `MachineController`, `MetricController`
- Repositories: `MachineActivityRepository`, `MachineRepository`, `MetricRepository`

Tests cover:
- CRUD operations
- Search and filter functionality
- Error handling
- Data validation

## Future Improvements

1. Add authentication and authorization
2. Implement real-time monitoring with SignalR
3. Add machine performance analytics
4. Implement data export functionality
5. Add support for multiple factory locations
6. Implement machine health monitoring
7. Add support for scheduled maintenance
8. Implement automated reporting 