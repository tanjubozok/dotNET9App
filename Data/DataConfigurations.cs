namespace Data;

public static class DataConfigurations
{
    public static void AddDataConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("LocalSqlServer"));
        });
    }
}
