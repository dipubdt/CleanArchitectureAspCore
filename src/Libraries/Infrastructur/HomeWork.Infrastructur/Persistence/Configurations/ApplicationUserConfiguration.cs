using HomeWork.Models.IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork.Infrastructure.Persistence.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var hasher = new PasswordHasher<ApplicationUser>();

        builder.HasData(new ApplicationUser
        {
            Id = "b74ddd14-6340-4840-95c2-db12554843e5",
            UserName = "admin",
            NormalizedUserName="ADMIN",
            Email = "admin@gmail.com",
            NormalizedEmail="ADMIN@GMAIL.COM",
            PasswordHash=hasher.HashPassword(null, "P@ssword1"),
            LockoutEnabled = false,
            PhoneNumber = "1234567890",
            EmailConfirmed = true,
        });
    }
}
