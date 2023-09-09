using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork.Infrastructure.Persistence.Configurations;

public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(new IdentityUserRole<string>
        {
            RoleId = "db12554843e5-6340-4840-95c2-b74ddd14",
            UserId = "b74ddd14-6340-4840-95c2-db12554843e5",
        });
    }
}
