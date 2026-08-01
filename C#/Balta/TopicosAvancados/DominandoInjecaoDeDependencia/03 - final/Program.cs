using DependencyInjectionLifetimeSample.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.TryAddSingleton<PrimaryService>();
builder.Services.TryAddSingleton<PrimaryService>();
builder.Services.TryAddScoped<SecondaryService>();
//builder.Services.AddTransient<TertiaryService>();

var app = builder.Build();

app.MapGet("/", (IService service) => {
    return Results.Ok(service.GetType().Name);
});

app.Run();

public interface IService {

}