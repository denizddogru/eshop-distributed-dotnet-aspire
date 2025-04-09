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

            config.UsingRabbitMq((context, configurator) =>
            {
                var configuration = context.GetRequiredService<IConfiguration>();

                // Get the connection string from configuration
                var connectionString = configuration.GetConnectionString("rabbitmq")
                    ?? "amqp://guest:fcz5xyypP1G3gjsTpS8BmF@localhost:5672";

                configurator.Host(new Uri(connectionString));
                configurator.ConfigureEndpoints(context);
            });
        });

        return services;

    }
}
