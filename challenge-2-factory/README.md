# Smart Factory API

A C# Web API application for tracking and managing machine activities in a smart factory environment.

## Features

- Track machine activities (production, maintenance, idle time)
- Search activities by machine name
- Filter activities by date range
- RESTful API endpoints for CRUD operations
- SQLite database for data persistence

## Architecture

The application follows SOLID principles and clean architecture:

- **Domain**: Contains business models and interfaces
- **Infrastructure**: Implements data access and repository pattern
- **API**: Provides REST endpoints and application configuration

### Key Components

- `MachineActivity`: Core domain model for tracking machine operations
- `IMachineActivityRepository`: Interface defining data access operations
- `MachineActivityRepository`: SQLite implementation of the repository
- `MachineActivityController`: REST API endpoints for machine activities

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- Visual Studio 2022 or VS Code with C# extensions

### Installation

1. Clone the repository
2. Open the solution in your IDE
3. Restore NuGet packages
4. Build the solution

### Running the Application

1. Set the API project as the startup project
2. Run the application
3. Access the Swagger UI at `https://localhost:5001/swagger`

## API Endpoints

- `GET /api/machineactivity`: Get all machine activities
- `GET /api/machineactivity/{id}`: Get activity by ID
- `POST /api/machineactivity`: Create new activity
- `PUT /api/machineactivity/{id}`: Update existing activity
- `DELETE /api/machineactivity/{id}`: Delete activity
- `GET /api/machineactivity/search?machineName={name}`: Search by machine name
- `GET /api/machineactivity/date-range?startDate={date}&endDate={date}`: Filter by date range

## Database

The application uses SQLite for data persistence. The database file (`SmartFactory.db`) is automatically created in the API project directory when the application first runs.

## Testing



## Future Improvements

1. Add authentication and authorization
2. Implement real-time monitoring with SignalR
3. Add machine performance analytics
4. Implement data export functionality
5. Add support for multiple factory locations
6. Implement machine health monitoring
7. Add support for scheduled maintenance
8. Implement automated reporting 