using System.Reflection;
using Zero.Catalog.Core.Commands;
using Zero.Catalog.Core.Queries;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCore(this IServiceCollection services, params Assembly[] assemblies)
    {
        if (assemblies.Length > 0)
        {
            services.Scan(scan => scan
                .FromAssemblies(assemblies!)
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime()
            );

            services.Scan(scan => scan
                .FromAssemblies(assemblies!)
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandValidator<>)))
                .AsSelfWithInterfaces()
                .WithSingletonLifetime()
            );
        }

        if (assemblies.Length > 0)
        {
            services.Scan(scan => scan
                .FromAssemblies(assemblies!)
                .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime()
            );

            services.Scan(scan => scan
                .FromAssemblies(assemblies!)
                .AddClasses(classes => classes.AssignableTo(typeof(IQueryValidator<>)))
                .AsSelfWithInterfaces()
                .WithSingletonLifetime()
            );
        }

        services.AddTransient<ICommandDispatcher, CommandDispatcher>();

        // TODO: Add validation decorator
        //services.Decorate(typeof(ICommandHandler<>), typeof(ValidationCommandHandlerDecorator<>));

        services.AddTransient<IQueryProcessor, QueryProcessor>();

        // TODO: Add validation decorator
        //services.Decorate(typeof(IQueryHandler<,>), typeof(ValidationQueryHandlerDecorator<,>));

        return services;
    }
}