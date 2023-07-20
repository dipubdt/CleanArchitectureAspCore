using HomeWork.Core;
using AutoMapper;
using HomeWork.Infrastructur;
using HomeWork.Repositories.Base;
using HomeWork.Repositories.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using HomeWork.Core.Behavior;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace Homework.ServiceCollectionExtention;
	public static class ConfigureServices
	{
		public static IServiceCollection AddExtention(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<HomeWorkDbContext>(options =>
			   options.UseSqlServer(configuration.GetConnectionString("Conn")
				   ));


		services.AddAutoMapper(typeof(CommonMapper).Assembly);
		services.AddTransient<ILaptopRepository, LaptopRepository>();
		
		services.AddMediatR(options => options.RegisterServicesFromAssemblies(typeof(ICore).Assembly));
		services.AddValidatorsFromAssembly(typeof(ICore).Assembly);
		services.AddMediatR(cfg =>
		{
			cfg.RegisterServicesFromAssemblies(typeof(ICore).Assembly);
			cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
		});



		return services;
		}
	}


