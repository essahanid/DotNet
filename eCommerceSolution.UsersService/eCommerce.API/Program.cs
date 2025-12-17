using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommerce.API.Middlewares;
using System.Text.Json.Serialization;
using eCommerce.Core.Mappers;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
// Add Infrastructure Services
builder.Services.AddInfrastructure();
// Add Core Services
builder.Services.AddCore();
// Add Controllers to ther service collection
builder.Services.AddControllers().AddJsonOptions(
    options => {
        options.JsonSerializerOptions.Converters.Add(
           new JsonStringEnumConverter()
            );
        });
builder.Services.AddAutoMapper(cfg => { }, typeof(ApplicationUserMappingProfile));

//add fluentato validation
builder.Services.AddFluentValidationAutoValidation();
var app = builder.Build();

app.UseExceptionHandlingMiddleware();
//Routing
app.UseRouting();
//Authentication
app.UseAuthentication();
//Authorization
app.UseAuthorization();
//Controller routes
app.MapControllers();
app.Run();
