using Infrastructure.Persistence.Contexts;
using Meziantou.Extensions.Logging.Xunit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace MinimalApi.Tests;

internal class IntegrationTestsFactory : WebApplicationFactory<Program>
{
    private readonly ITestOutputHelper _testOutputHelper;

    public IntegrationTestsFactory(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddProvider(new XUnitLoggerProvider(_testOutputHelper));
        });

        builder.ConfigureAppConfiguration((_, _) =>
        {
        });

        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll<DbContextOptions<BookDbContext>>();
            services.RemoveAll<BookDbContext>();
            services.AddDbContext<BookDbContext>(options =>
            {
                options.UseSqlite("Data Source=BooksDatabaseForTests.db");
            });

            var serviceProvider = services.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();
            var scopedServiceProvider = scope.ServiceProvider;
            var context = scopedServiceProvider.GetRequiredService<BookDbContext>();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        });
    }
}