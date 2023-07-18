
using Microsoft.EntityFrameworkCore;

namespace HomeWork.Infrastructur;
public class HomeWorkDbContext:DbContext
{
	public HomeWorkDbContext(DbContextOptions<HomeWorkDbContext> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(HomeWorkDbContext).Assembly);
	}




}