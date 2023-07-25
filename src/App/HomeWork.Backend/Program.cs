using Homework.ServiceCollectionExtention; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddServices(builder.Configuration);
builder.Services.AddExtention(builder.Configuration);
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


builder.Services.AddSwaggerGen( option=>
{	option.SwaggerDoc("v1",
		 new Microsoft.OpenApi.Models.OpenApiInfo
		 {

			 Title = " Swager Documentention",
			 Version = "v1",	
			 Description="Explain How to documentation",
			 Contact= new Microsoft.OpenApi.Models.OpenApiContact
			 {
				 Name="Dipan",
				 Email="dipan@gmail.com"
			 }

		 }

		);
}

);

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

app.MapControllers();

app.Run();
