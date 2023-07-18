using HomeWork.Models;
using HomeWork.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork.Infrastructur.Persistence.Configurations;

internal class LaptopConfiguration : IEntityTypeConfiguration<Laptop>
{
	public void Configure(EntityTypeBuilder<Laptop> builder)
	{
		builder.ToTable("Laptops");
		builder.HasKey(x => x.Id);
		builder.HasData(new
		{
			Id = 1,
			Model = "Walton",
			ScreenSizeInches = "6 inhci",
			RAMSizeGB = 64,
			Color = "Black",
			Created = DateTimeOffset.Now,
			CreatedBy = "1",
			Status = EntityStatus.Created
		});



	}
}
