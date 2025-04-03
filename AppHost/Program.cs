var builder = DistributedApplication.CreateBuilder(args);

// add projects and cloud native backing services here

builder.AddProject<Projects.Catalog>("catalog");


builder.Build().Run();
