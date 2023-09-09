using Homework.ServiceCollectionExtention;
using HomeWork.Core.AuthServices;
using HomeWork.Infrastructur;
using HomeWork.Models.IdentityModel;
using HomeWork.Service.Models.AuthModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                 .RequireAuthenticatedUser()
                 .Build();
    config.Filters.Add(new AuthorizeFilter(policy));

});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
	options.Password.RequiredLength = 6;
	options.Password.RequireNonAlphanumeric = true;
	options.Password.RequireDigit = true;
	options.Password.RequireLowercase = true;
	options.Password.RequireUppercase = true;

}).AddEntityFrameworkStores<HomeWorkDbContext>().AddDefaultTokenProviders();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddServices(builder.Configuration);
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddExtention(builder.Configuration);
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = false,
		ValidateAudience = false,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ClockSkew = TimeSpan.Zero,
		ValidIssuer = builder.Configuration["JwtSettings:validIssuer"],
		ValidAudience = builder.Configuration["JwtSettings:validAudience"],
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
    };
});

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddCors(options =>
//{
//	options.AddDefaultPolicy(
//		builder =>
//		{
//			builder.WithOrigins("https://localhost:44351", "http://localhost:4200")
//								.AllowAnyHeader()
//								.AllowAnyMethod();
//		});
//});

builder.Services.AddCors(p => p.AddPolicy("cors", builder => builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader()));

builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = " Swager Documentention",
        Version = "v1",
        Description = "Explain How to documentation",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Dipan",
            Email = "dipan@gmail.com"
        }

    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

	
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI( a=>a.SwaggerEndpoint("/swagger/v1/swagger.json",
		"Swagger Demo Documentation v1"	
		));
	
	app.UseReDoc(a =>
	{
		a.DocumentTitle = "swagger Demo Documentation";
		a.SpecUrl = "/swagger/v1/swagger.json";

	}


		);


}
app.UseCors("cors");
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
