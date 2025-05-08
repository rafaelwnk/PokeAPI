using System.IO.Compression;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.ResponseCompression;
using PokeAPI.Data;
using PokeAPI.Interfaces;
using PokeAPI.Services;

namespace PokeAPI;

class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigureMvc(builder);
        ConfigureServices(builder);

        var app = builder.Build();

        app.UseResponseCompression();

        app.MapControllers();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.Run();
    }

    public static void ConfigureMvc(WebApplicationBuilder builder)
    {
        builder.Services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
            });
        builder.Services.Configure<GzipCompressionProviderOptions>(options =>
        {
            options.Level = CompressionLevel.Optimal;
        });
        builder.Services.AddControllers()
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            })
            .AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
            });
    }
    public static void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<DataContext>();
        builder.Services.AddScoped<ITypeService, TypeService>();
        builder.Services.AddScoped<IRegionService, RegionService>();
        builder.Services.AddScoped<IPokemonService, PokemonService>();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }
}
