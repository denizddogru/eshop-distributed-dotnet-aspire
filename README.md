# Aspire Microservices Learning Project

This simple learning project provides common .NET Aspire services such as service discovery, resilience, health checks, and OpenTelemetry. It is designed to be referenced by each service project in your solution to ensure consistent configuration and behavior across all services.


## What is .NET Aspire?

.NET Aspire is Microsoft's cloud-native application stack for building distributed applications. It simplifies the development of microservices by providing:

- **Component orchestration** - Manages service dependencies and startup order
- **Service discovery** - Automatic service registration and lookup
- **Local development dashboard** - Visual monitoring of all services
- **Infrastructure integration** - Built-in support for databases, caches, and message brokers
- **Observability** - Integrated logging, metrics, and distributed tracing

Aspire reduces the complexity of microservices development by handling much of the infrastructure plumbing, allowing developers to focus on business logic rather than service connectivity.

## Learning Goals & Objectives

1. **Cloud-Native Distributed Architecture**  
   Building scalable systems with multiple independent services that can be deployed and managed separately.

2. **.NET Aspire for Microservices**  
   Exploring Microsoft's new stack for cloud-native apps with built-in service discovery and orchestration capabilities.

3. **Catalog Microservice with PostgreSQL**  
   Creating a product catalog service with reliable data persistence using PostgreSQL for storing product information.

4. **Basket Microservice with Redis Cache**  
   Implementing a shopping cart service utilizing Redis for high-performance in-memory data storage.

5. **Service Communication Patterns**  
   Implementing direct synchronous communication between services using HTTP/gRPC and leveraging Aspire's service discovery.

6. **Message-Based Communication**  
   Setting up event-driven architecture with RabbitMQ and MassTransit for reliable asynchronous operations between services.
7. **Security with Keycloak**  
   Securing microservices using Keycloak for authentication and authorization, ensuring only authorized users can access sensitive endpoints.

8. **Frontend Development with Blazor**  
   Building a user-friendly web application using Blazor to interact with the microservices, providing a seamless user experience.

9. **Deploy Project to Azure Container Apps**  
   Deploying the entire microservices architecture to Azure Container Apps, showcasing the scalability and reliability of cloud-native applications.

## Getting Started

### Prerequisites
- .NET 9
- Visual Studio 2022
- Docker Desktop 

### Technologies Used
- .NET 9
- PostgreSQL (Using migrations and EF Core)
- RabbitMQ
- Docker Desktop (You need Docker Desktop started before running the application)
- Redis

### Running the Application
1. Select AppHost as your startup project, then run the application.
2. As for migrations they are automatically applied on startup, so you don't need to run them manually.

### Dependencies
- `Aspire.AppHost.Sdk` (v9.1.0)
- `Aspire.Hosting.AppHost` (v9.1.0)
- `Aspire.Hosting.PostgreSQL` (v9.1.0)
- `Aspire.StackExchange.Redis.DistributedCaching` (v9.1.0)

### Step By Step Development Plan
1. **Setting Up Core Microservices**: Catalog and Basket Microservices Deployment w/ Backing Services
2. **Microservices Communications with .NET Aspire**: Synchronous and asynchronous messaging between Catalog & Basket using RabbitMQ Message Broker
3. **Authentication & Security**: Secure Basket Endpoints w/ Keycloak using OpenID Connect Jwt Tokens
4. **Frontend Development**: Blazor WebApp Products page development

