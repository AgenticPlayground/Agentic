var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Register InMemoryPrincipleRepository for IPrincipleRepository
builder.Services.AddSingleton<WebApi.Features.Principles.Domain.IPrincipleRepository, WebApi.Features.Principles.Domain.InMemoryPrincipleRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
    app.UseForwardedHeaders();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.UseStaticFiles();
if (app.Environment.IsDevelopment())
{
    app.UseSpa(spa => { spa.UseProxyToSpaDevelopmentServer("http://localhost:3000"); });
}
else
{
    app.MapFallbackToFile("index.html");
}

await app.RunAsync();