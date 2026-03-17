using ImportWizard.Api.Data;
using ImportWizard.Api.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ── Database ──────────────────────────────────────────────────────────────────
// Connection string is read from the DATABASE_URL env var (set in docker-compose
// or .env) with fallback to ConnectionStrings:DefaultConnection in appsettings.
var connectionString =
    Environment.GetEnvironmentVariable("DATABASE_URL")
    ?? builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException(
        "No database connection string found. " +
        "Set the DATABASE_URL environment variable or ConnectionStrings:DefaultConnection.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// ── OpenAPI / Swagger ─────────────────────────────────────────────────────────
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ── Health endpoint ───────────────────────────────────────────────────────────
app.MapGet("/health", () => Results.Ok(new { status = "healthy" }))
   .WithName("Health")
   .WithTags("Health")
   .WithOpenApi();

// ── Import-run endpoints (stubs — see Endpoints/ImportRunEndpoints.cs) ────────
app.MapImportRunEndpoints();

app.Run();
