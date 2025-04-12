var builder = DistributedApplication.CreateBuilder(args);

// Backing Services : 
// Backing services are external resources or services that your application depends on, such as databases, caches, and message brokers. 
// They are essential for the application's functionality and are typically managed separately from the application code itself.

var postgres = builder
    .AddPostgres("postgres")  // Add PostgreSQL as a backing service
    .WithPgAdmin()            // Include pgAdmin for database management
    .WithDataVolume()       // Attach a data volume to persist PostgreSQL data
    .WithLifetime(ContainerLifetime.Persistent);  // Set the container lifetime as persistent

var catalogDb = postgres.AddDatabase("catalogdb");  // Create a new database within the PostgreSQL service


var cache = builder
    .AddRedis("cache")  // Add Redis as a backing service
    .WithRedisInsight()  // Include RedisInsight for monitoring Redis
    .WithDataVolume()   // Attach a data volume to persist Redis data
    .WithLifetime(ContainerLifetime.Persistent);

var rabbitmq = builder
    .AddRabbitMQ("rabbitmq")  // Add RabbitMQ as a backing service
    .WithManagementPlugin()  // Include the RabbitMQ management plugin for monitoring ( Web UI )
    .WithDataVolume()
    .WithLifetime(ContainerLifetime.Persistent);

var keycloak = builder
    .AddKeycloak("keycloak", 8080)  // Add Keycloak as a backing service
    .WithDataVolume()         // Attach a data volume to persist Keycloak data
    .WithLifetime(ContainerLifetime.Persistent);


// Projects

// Catalog projesini environment variableslarda ConnectionString olarak inject ettiğimiz kısım. ( with reference )

var catalog = builder
    .AddProject<Projects.Catalog>("catalog") // Add a project named 'catalog'
    .WithReference(catalogDb)                // Reference the 'catalogdb' database in the project
    .WithReference(rabbitmq)                 // Reference the RabbitMQ service in the project
    .WaitFor(catalogDb)                      // Ensure the project waits for the database to be ready before starting
    .WaitFor(rabbitmq);                      // Ensure the project waits for RabbitMQ to be ready before starting

var basket = builder
    .AddProject<Projects.Basket>("basket")  // Add a project named 'basket'
    .WithReference(cache)                   // Reference the Redis cache in the project
    .WithReference(catalog)
    .WithReference(rabbitmq)
    .WithReference(keycloak)
    .WaitFor(cache)
    .WaitFor(rabbitmq)
    .WaitFor(keycloak);                        // Ensure the project waits for the cache to be ready before starting


builder.Build().Run();