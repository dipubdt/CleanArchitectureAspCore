
using AutoMapper;
using HomeWork.Models;
using HomeWork.Repositories.Interfaces;
using HomeWork.Service.Models;
using HomeWork.Shared.Enums;
using MediatR;

namespace HomeWork.Core.Command;

public  class CreateLaptop
{
	public record CreateLaptopCommand(VmLaptop laptop) : IRequest<VmLaptop>;

	public class CreateLaptopCommandHandler : IRequestHandler<CreateLaptopCommand, VmLaptop>
	{
		private readonly ILaptopRepository _laptopRepository;
		private readonly IMapper _mapper;

        public CreateLaptopCommandHandler(ILaptopRepository laptopRepository, IMapper mapper )
        {
			_laptopRepository = laptopRepository;
			_mapper=mapper;
		}

		public async Task<VmLaptop> Handle(CreateLaptopCommand request, CancellationToken cancellationToken)
		{
			var Datas = _mapper.Map<Laptop>(request.laptop);
			
			return await _laptopRepository.Add(Datas);
		}
	}

}
