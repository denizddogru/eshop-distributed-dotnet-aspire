# Aspire Service Defaults

This project provides common .NET Aspire services such as service discovery, resilience, health checks, and OpenTelemetry. It is designed to be referenced by each service project in your solution to ensure consistent configuration and behavior across all services.

## Features

- **Service Discovery**: Automatically discover and connect to other services in your environment.
- **Resilience**: Built-in resilience mechanisms to handle transient faults and ensure high availability.
- **Health Checks**: Standardized health checks to monitor the health and readiness of your services.
- **OpenTelemetry**: Integrated OpenTelemetry for distributed tracing and metrics collection.

## Getting Started

### Prerequisites

- .NET 9
- Visual Studio 2022

### Technologies Used

- .NET 9
- PostgreSQL
- RabbitMQ


### Installation

1. Add a reference to the `Aspire.ServiceDefaults` project in your service project.
2. Configure your service to use the default services provided by this project.

### Usage

To use the default services provided by this project, call the `AddServiceDefaults` method in your service's startup configuration:


### Step By Step Development Plan

- **Setting Up Core Microservices**: Catalog and Basket Microservices Deployment w/ Backing Services
- **Microservices Communications with .NET Aspire**: Synchronous and asyncronous messaging between Catalog&Basket using RabbitMQ Message Broker
- **Authentication & Security**: Securet Basket Endpoints w/ Keycloak using OpenID Connect Jwt Tokens
- **Frontend Development**: Blazor WebApp Products page development