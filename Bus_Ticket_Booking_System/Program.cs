using Bus_Ticket_Booking_System.Interfaces.Repositories;
using Bus_Ticket_Booking_System.Interfaces.Services;
using Bus_Ticket_Booking_System.src.Data;
using Bus_Ticket_Booking_System.src.Repository;
using Bus_Ticket_Booking_System.src.Services;
using Bus_Ticket_Booking_System.Utilis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
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
                //Scheme = "oauth2",
                //Name = "oauth2",
                //In = ParameterLocation.Header
        },
        new [] {builder.Configuration["ApiScope"] }
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

builder.Services.AddAuthentication(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme).AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
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
        c.OAuthClientId(builder.Configuration["AzureAd:ClientId"]);
        //c.OAuthClientSecret(builder.Configuration["ClientSecretKey"]);
        c.OAuthUsePkce();
        //c.OAuthUseBasicAuthenticationWithAccessCodeGrant();
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

