using System.Reflection;
using AirBnb.Api.Data;
using AirBnb.Application.Listings.Services;
using AirBnb.Application.Locations.Services;
using AirBnb.Infrastructure.Common.Caching.Brokers;
using AirBnb.Infrastructure.Common.Caching.Settings;
using AirBnb.Infrastructure.ListingCategories.Services;
using AirBnb.Infrastructure.Locations.Services;
using AirBnb.Infrastructure.StorageFiles.Settings;
using AirBnb.Persistence.Caching.Brokers;
using AirBnb.Persistence.DataContexts;
using AirBnb.Persistence.Repositories;
using AirBnb.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AirBnb.Api.Configurations;

public static partial class HostConfiguration
{
    private static readonly ICollection<Assembly> Assemblies;

    static HostConfiguration()
    {
        Assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
        Assemblies.Add(Assembly.GetExecutingAssembly());
    }

    /// <summary>
    /// Adds mappers
    /// </summary>
    /// <param name="builder">The <see cref="WebApplicationBuilder"/> instance.</param>
    /// <returns>The <see cref="WebApplicationBuilder"/> instance.</returns>
    private static WebApplicationBuilder AddMappers(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(Assemblies);

        return builder;
    }

    /// <summary>
    /// Adds caching
    /// </summary>
    /// <param name="builder">The <see cref="WebApplicationBuilder"/> instance.</param>
    /// <returns>The <see cref="WebApplicationBuilder"/> instance.</returns>
    private static WebApplicationBuilder AddCaching(this WebApplicationBuilder builder)
    {
        // Register cache settings
        builder.Services.Configure<CacheSettings>(builder.Configuration.GetSection(nameof(CacheSettings)));

        // Register redis cache
        builder.Services.AddStackExchangeRedisCache(
            options =>
            {
                options.Configuration = builder.Configuration.GetConnectionString("RedisConnectionString");
                options.InstanceName = "Caching.SimpleInfra";
            }
        );

        // Register cache broker
        builder.Services.AddSingleton<ICacheBroker, RedisDistributedCacheBroker>();

        return builder;
    }

    /// <summary>
    /// Adds business logic infrastructure
    /// </summary>
    /// <param name="builder">The <see cref="WebApplicationBuilder"/> instance.</param>
    /// <returns>The <see cref="WebApplicationBuilder"/> instance.</returns>
    private static WebApplicationBuilder AddBusinessLogicInfrastructure(this WebApplicationBuilder builder)
    {
        // register db contexts
        builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        # region Locations

        // Register repositories
        builder.Services.AddScoped<ILocationRepository, LocationRepository>();

        // Register foundation data access services
        builder.Services.AddScoped<ILocationService, LocationService>();

        #endregion

        #region Listing Categories

        // Register repositories
        builder.Services.AddScoped<IListingCategoryRepository, ListingCategoryRepository>();

        // Register foundation data access services
        builder.Services.AddScoped<IListingCategoryService, ListingCategoryService>();

        #endregion

        #region Storage files

        builder.Services.Configure<StorageFileSettings>(builder.Configuration.GetSection(nameof(StorageFileSettings)))
            .Configure<ApiSettings>(builder.Configuration.GetSection(nameof(ApiSettings)));

        #endregion

        return builder;
    }

    /// <summary>
    /// Adds cors security
    /// </summary>
    /// <param name="builder">The <see cref="WebApplicationBuilder"/> instance.</param>
    /// <returns>The <see cref="WebApplicationBuilder"/> instance.</returns>
    private static WebApplicationBuilder AddCorsSecurity(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(
            options =>
            {
                options.AddDefaultPolicy(
                    policyBuilder =>
                    {
                        policyBuilder.AllowAnyOrigin();
                        policyBuilder.AllowAnyMethod();
                        policyBuilder.AllowAnyHeader();
                    }
                );
            }
        );

        return builder;
    }

    /// <summary>
    /// Adds route and controller
    /// </summary>
    /// <param name="builder">The <see cref="WebApplicationBuilder"/> instance.</param>
    /// <returns>The <see cref="WebApplicationBuilder"/> instance.</returns>
    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers();

        return builder;
    }

    /// <summary>
    /// Configures the middleware to seed data
    /// </summary>
    /// <param name="app">The <see cref="WebApplication"/> instance.</param>
    /// <returns>The <see cref="WebApplication"/> instance.</returns>
    private static async Task<WebApplication> SeedDataAsync(this WebApplication app)
    {
        var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
        using var scope = scopeFactory.CreateScope();
        await scope.ServiceProvider.SeedDataAsync();

        return app;
    }

    /// <summary>
    /// Configures the middleware to use media infrastructure.
    /// </summary>
    /// <param name="app">The <see cref="WebApplication"/> instance.</param>
    /// <returns>The <see cref="WebApplication"/> instance.</returns>
    private static WebApplication UseMediaInfrastructure(this WebApplication app)
    {
        app.UseStaticFiles();

        return app;
    }

    /// <summary>
    /// Configures the middleware to use cors security.
    /// </summary>
    /// <param name="app">The <see cref="WebApplication"/> instance.</param>
    /// <returns>The <see cref="WebApplication"/> instance.</returns>
    private static WebApplication UseCorsSecurity(this WebApplication app)
    {
        app.UseCors();

        return app;
    }

    /// <summary>
    /// Configures the middleware to use exposers.
    /// </summary>
    /// <param name="app">The <see cref="WebApplication"/> instance.</param>
    /// <returns>The <see cref="WebApplication"/> instance.</returns>
    private static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }
}