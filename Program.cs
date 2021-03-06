using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using rischy.assessment_generator.Builders;
using rischy.assessment_generator.Configuration;
using rischy.assessment_generator.Mappers;
using rischy.assessment_generator.Services;

var builder = WebApplication.CreateBuilder(args);

// Add configuration
builder.Services.Configure<ChemicalHandlerConfiguration>(
     builder.Configuration.GetSection("ChemicalHandlerSettings"));

// Add clients
builder.Services.AddHttpClient<ChemicalHandlerService>();

// Add services
builder.Services.AddScoped<RiskAssessmentService>();
builder.Services.AddScoped<ControlMeasuresMapper>();
builder.Services.AddScoped<EmergencyActionsMapper>();
builder.Services.AddScoped<HazardTableMapper>();
builder.Services.AddScoped<DisposalRecommendationsMapper>();
builder.Services.AddScoped<RiskAssessmentResponseBuilder>();

// Add controllers
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true);

// Add swagger
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
