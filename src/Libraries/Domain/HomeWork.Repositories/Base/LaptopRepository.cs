using AutoMapper;

using HomeWork.Infrastructur;
using HomeWork.Models;
using HomeWork.Repositories.Interfaces;
using HomeWork.Service.Models;

using HomeWork.Shared.CommonRepository;

namespace HomeWork.Repositories.Base;

public class LaptopRepository : RepositoryBase<Laptop,VmLaptop , int>, ILaptopRepository
{
	public LaptopRepository(IMapper mapper, HomeWorkDbContext dbContext) : base(mapper, dbContext)
	{
	}
}
