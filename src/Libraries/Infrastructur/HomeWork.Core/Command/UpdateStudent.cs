

using AutoMapper;
using HomeWork.Models;
using HomeWork.Repositories.Base;
using HomeWork.Repositories.Interfaces;
using HomeWork.Service.Models;
using MediatR;

namespace HomeWork.Core.Command;

public  class UpdateLaptop
{
	public record UpdateLaptopCommand(int id, VmLaptop laptop) : IRequest<VmLaptop>;

	public class UpdateLaptopCommandHandler : IRequestHandler<UpdateLaptopCommand, VmLaptop>
	{
		private readonly ILaptopRepository _laptopRepository;
		private readonly IMapper _mapper;

        public UpdateLaptopCommandHandler(ILaptopRepository laptopRepository, IMapper mapper )
        {
			_laptopRepository=laptopRepository;
			_mapper =mapper;

		}

		public async Task<VmLaptop> Handle(UpdateLaptopCommand request, CancellationToken cancellationToken)
		{
			var datas = _mapper.Map<Laptop>(request.laptop);

			return await _laptopRepository.Update(request.id, datas);
		}
	}







}
