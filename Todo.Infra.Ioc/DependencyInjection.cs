using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Todo.Domain.Interfaces;
using Todo.Infra.Data.Context;
using Todo.Infra.Data.Repositories;

namespace Todo.Infra.Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraStructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration
            .GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<ICategoryRespository, CategoryRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();

        return services;
    }
}