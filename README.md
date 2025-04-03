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

### Installation

1. Add a reference to the `Aspire.ServiceDefaults` project in your service project.
2. Configure your service to use the default services provided by this project.

### Usage

To use the default services provided by this project, call the `AddServiceDefaults` method in your service's startup configuration:

