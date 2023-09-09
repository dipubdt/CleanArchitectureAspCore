
using HomeWork.Models.IdentityModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HomeWork.Infrastructur;
public class HomeWorkDbContext : IdentityDbContext<ApplicationUser>
{
    public HomeWorkDbContext(DbContextOptions<HomeWorkDbContext> options):base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }



}