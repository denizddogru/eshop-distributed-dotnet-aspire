using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ServiceDefaults;
public static class MassTransitExtensions
{
    public static IServiceCollection AddMassTransitWithAssemblies
        (this IServiceCollection services, params Assembly[] assemblies)
    {

        // Saga: A design pattern used to manage long-running transactions and complex workflows.
        // It consists of a series of steps, each of which can be completed independently.
        // Each step can be a local transaction or a message sent to another service.

        services.AddMassTransit(config =>
        {
            config.SetKebabCaseEndpointNameFormatter(); // Kebab case sample: product-price-change-consumer
            config.SetInMemorySagaRepositoryProvider();

            config.AddConsumers(assemblies);
            config.AddSagaStateMachines(assemblies);
            config.AddSagas(assemblies);
            config.AddActivities(assemblies);

            config.UsingRabbitMq((context, cfg) =>
            {
                var config = context.GetRequiredService<IConfiguration>();
                var connectionString = config.GetConnectionString("rabbitmq");

                cfg.Host(connectionString);
                cfg.ConfigureEndpoints(context);

            });
        });

        return services;

    }
}
