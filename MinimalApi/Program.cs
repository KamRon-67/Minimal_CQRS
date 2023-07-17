using MinimalApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServices();

var app = builder.Build();

app.Use(async (ctx, next) =>
{
    try
    {
        await next();
    }
    catch (Exception ex)
    {
        ctx.Response.StatusCode = 500;
        await ctx.Response.WriteAsync("An error occurred");
    }
});

app.UseHttpsRedirection();

app.RegisterEndpointDefinitions();

app.Run();

// Make the implicit Program class public so test projects can access it
public partial class Program { }
