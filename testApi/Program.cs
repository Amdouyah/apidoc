using FastEndpoints;
using QuestPDF.Infrastructure;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

QuestPDF.Settings.License = LicenseType.Community;

builder.Services.AddFastEndpoints()
                .SwaggerDocument();
    
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthorization();
app.UseFastEndpoints();
app.UseSwaggerGen();

app.Run();