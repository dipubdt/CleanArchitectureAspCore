

using AutoMapper;
using HomeWork.Models;
using HomeWork.Repositories.Base;
using HomeWork.Repositories.Interfaces;
using HomeWork.Service.Models;
using HomeWork.Shared.Model;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HomeWork.Core.Command;


	public record UpdateLaptopCommand(int id, VmLaptop laptop) : IRequest<CommandResult<VmLaptop>> { }

	public class UpdateLaptopCommandHandler : IRequestHandler<UpdateLaptopCommand, CommandResult<VmLaptop>>
	{
		private readonly ILaptopRepository _laptopRepository;
		private readonly IMapper _mapper;

        public UpdateLaptopCommandHandler(ILaptopRepository laptopRepository, IMapper mapper )
        {
			_laptopRepository=laptopRepository;
			_mapper =mapper;

		}

		public async Task <CommandResult<VmLaptop>> Handle(UpdateLaptopCommand request, CancellationToken cancellationToken)
	{
			var datas = _mapper.Map<Laptop>(request.laptop);
		   var returnData = await _laptopRepository.Update(request.id, datas);

		if (returnData is not null and { Id: var id } && id > 0)
		{
			return new CommandResult<VmLaptop>(returnData, CommandResultTypeEnum.Success);
		}
		return new CommandResult<VmLaptop>(null, CommandResultTypeEnum.UnprocessableEntity);


	}
}








