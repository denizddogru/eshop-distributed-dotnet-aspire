# Aspire Service Defaults

This project provides common .NET Aspire services such as service discovery, resilience, health checks, and OpenTelemetry. It is designed to be referenced by each service project in your solution to ensure consistent configuration and behavior across all services.

## Features

- **Service Discovery**: Automatically discover and connect to other services in your environment.
- **Resilience**: Built-in resilience mechanisms to handle transient faults and ensure high availability.
- **Health Checks**: Standardized health checks to monitor the health and readiness of your services.
- **OpenTelemetry**: Integrated OpenTelemetry for distributed tracing and metrics collection.
- **Product Management**: Create, read, update, and delete products.
- **Database Integration**: Uses PostgreSQL for data storage.
- **Dependency Injection**: Services are registered and injected using .NET's built-in dependency injection.
- **HTTPS Redirection**: Ensures all HTTP requests are redirected to HTTPS.
- **Automatic Migrations**: Applies database migrations automatically on startup.

## Getting Started

### Prerequisites

- .NET 9
- Visual Studio 2022
- Docker Desktop 

### Technologies Used

- .NET 9
- PostgreSQL ( Using migrations and EF Core )
- RabbitMQ
- Docker Desktop ( You need Docker Desktop started before running the application )


### Running the Application

1. Select AppHost as your startup project, then run the application.
2. As for migrations they are automatically applied on startup, so you don't need to run them manually.

### Dependencies

- `Aspire.AppHost.Sdk` (v9.1.0)
- `Aspire.Hosting.AppHost` (v9.1.0)
- `Aspire.Hosting.PostgreSQL` (v9.1.0)

### Step By Step Development Plan

- **Setting Up Core Microservices**: Catalog and Basket Microservices Deployment w/ Backing Services
- **Microservices Communications with .NET Aspire**: Synchronous and asynchronous messaging between Catalog & Basket using RabbitMQ Message Broker
- **Authentication & Security**: Secure Basket Endpoints w/ Keycloak using OpenID Connect Jwt Tokens
- **Frontend Development**: Blazor WebApp Products page development


   
   
