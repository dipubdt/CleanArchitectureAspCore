using HomeWork.Core;
using AutoMapper;
using HomeWork.Infrastructur;
using HomeWork.Repositories.Base;
using HomeWork.Repositories.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
			services.AddMediatR(typeof(ICore).Assembly);


		//services.AddMediatR(options=>options.regis)
			return services;
		}
	}


