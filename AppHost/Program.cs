var builder = DistributedApplication.CreateBuilder(args);

// Backing Services

// Configure PostgreSQL service with the name 'postgres'
var postgres = builder
    .AddPostgres("postgres")  // Add PostgreSQL as a backing service
    .WithPgAdmin()            // Include pgAdmin for database management
    .WithDataVolume()         // Attach a data volume to persist database data
    .WithLifetime(ContainerLifetime.Persistent);  // Set the container lifetime as persistent

// Add a database named 'catalogdb' to the PostgreSQL service
var catalogDb = postgres.AddDatabase("catalogdb");  // Create a new database within the PostgreSQL service

// Projects

// Add the 'catalog' project, reference the 'catalogdb' database, and ensure it waits for the database to be ready
var catalog = builder
    .AddProject<Projects.Catalog>("catalog")  // Add a project named 'catalog'
    .WithReference(catalogDb)                 // Reference the 'catalogdb' database in the project
    .WaitFor(catalogDb);                      // Ensure the project waits for the database to be ready before starting

builder.Build().Run(); 