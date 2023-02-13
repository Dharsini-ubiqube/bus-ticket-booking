using AspNet.Security.OAuth.Validation;
using Bus_Ticket_Booking_System.Interfaces.Repositories;
using Bus_Ticket_Booking_System.Interfaces.Services;
using Bus_Ticket_Booking_System.src.Data;
using Bus_Ticket_Booking_System.src.Repository;
using Bus_Ticket_Booking_System.src.Services;
//using Bus_Ticket_Booking_System.Utilis;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

Console.WriteLine(builder.Configuration.GetSection("TokenUrl"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
builder.Services.Configure<JwtBearerOptions>(JwtBearerDefaults.AuthenticationScheme, options =>
{
    var existingOnTokenValidatedHandler = options.Events.OnTokenValidated;
    options.Events.OnTokenValidated = async context =>
    {
        await existingOnTokenValidatedHandler(context);
        options.TokenValidationParameters.ValidIssuers = new[] { "https://login.microsoftonline.com/9188040d-6c67-4c5b-b112-36a304b66dad/v2.0" };
        options.TokenValidationParameters.ValidAudiences = new[] { "b3928819-0855-44bf-873c-15de7c8bc46e" };
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Bus Ticket Booking Api", Version = "v1" });
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows()
        {
            AuthorizationCode = new OpenApiOAuthFlow()
            {
                AuthorizationUrl = new Uri(builder.Configuration["AuthorizationUrl"]),
                TokenUrl = new Uri(builder.Configuration["TokenUrl"]),
                Scopes = new Dictionary<string, string> {
                        {
                            builder.Configuration["ApiScope"],
                            "Access the Api"
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
        },
        new [] {builder.Configuration["ApiScope"] }
    }
});
});


builder.Services.AddDbContext<BusTicketDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"));
});

builder.Services.AddTransient<IUserService , UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IBusService, BusService>();
builder.Services.AddTransient<IBusRepository, BusRepository>();
builder.Services.AddTransient<ILocationService, LocationService>();
builder.Services.AddTransient<ILocationRepository, LocationRepository>();
//builder.Services.AddSingleton <IJwtTokenUtilis, JwtTokenUtilis>();
builder.Services.AddTransient<ITicketRepository, TicketRepository>();
builder.Services.AddTransient<ITicketService, TicketService>();



builder.Services.AddScoped<BusTicketDbContext>();

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
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Online_Bus_Ticket_Booking v1");

        c.OAuthClientId(builder.Configuration["AzureAd:ClientId"]);
  
        c.OAuthUsePkce();
        c.OAuthScopeSeparator(" ");
    });
//}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

