using AutoMapper;
using HomeWork.Models;

using HomeWork.Service.Models;


public class CommonMapper : Profile
{

	public CommonMapper()
	{
		CreateMap<VmLaptop, Laptop>().ReverseMap();
	}


}