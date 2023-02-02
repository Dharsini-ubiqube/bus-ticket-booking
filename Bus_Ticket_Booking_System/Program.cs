using Bus_Ticket_Booking_System.Interfaces.Repositories;
using Bus_Ticket_Booking_System.Interfaces.Services;
using Bus_Ticket_Booking_System.src.Data;
using Bus_Ticket_Booking_System.src.Repository;
using Bus_Ticket_Booking_System.src.Services;
using Bus_Ticket_Booking_System.Utilis;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    //c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    //{
    //    Description = "Standard Authorization using bearer scheme (\"Bearer {token}\" ) ",
    //    In = ParameterLocation.Header,
    //    Name = "Authorization",
    //    Type = SecuritySchemeType.ApiKey
    //});

    //c.OperationFilter<SecurityRequirementsOperationFilter>();
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows()
        {
            Implicit = new OpenApiOAuthFlow()
            {
                AuthorizationUrl = new Uri("https://login.microsoftonline.com/4cc72284-2d70-4529-b0f3-4e09ebc55558/oauth2/v2.0/authorize"),
                TokenUrl = new Uri("https://login.microsoftonline.com/4cc72284-2d70-4529-b0f3-4e09ebc55558/oauth2/v2.0/token"),
                Scopes = new Dictionary<string, string> {
                        {
                            "api://d70bdf82-3ba7-4b12-85cf-791485a16116/ReadAccess",
                            "Reads all bus ticket booking"
                        }
                    }
            }
        }
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
    {
        new OpenApiSecurityScheme {
            Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "oauth2"
                },
                Scheme = "oauth2",
                Name = "oauth2",
                In = ParameterLocation.Header
        },
        new List < string > ()
    }
});
});





builder.Services.AddDbContext<BusTicketDbContext>(options =>
{
    var connString = builder.Configuration.GetConnectionString("DevConnection");
    options.UseMySql(connString, ServerVersion.AutoDetect(connString));
});

builder.Services.AddTransient<IUserService , UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IBusService, BusService>();
builder.Services.AddTransient<IBusRepository, BusRepository>();
builder.Services.AddTransient<ILocationService, LocationService>();
builder.Services.AddTransient<ILocationRepository, LocationRepository>();
builder.Services.AddSingleton <IJwtTokenUtilis, JwtTokenUtilis>();
builder.Services.AddTransient<ITicketRepository, TicketRepository>();
builder.Services.AddTransient<ITicketService, TicketService>();



builder.Services.AddScoped<BusTicketDbContext>();

//builder.Services.AddAuthentication(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
//    options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuerSigningKey = false,
//            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("my favourite token is here thank you")),
//            ValidateIssuer = false,
//            ValidateAudience = false
//        };
//    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AzureAD_OAuth_API v1");
        //c.RoutePrefix = string.Empty;
        c.OAuthClientId("d70bdf82-3ba7-4b12-85cf-791485a16116");
        c.OAuthClientSecret("Dpc8Q~qrNYoSY4.vHA1TwKqqUl1jv2En~7FHCaE_");
        c.OAuthUseBasicAuthenticationWithAccessCodeGrant();
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

