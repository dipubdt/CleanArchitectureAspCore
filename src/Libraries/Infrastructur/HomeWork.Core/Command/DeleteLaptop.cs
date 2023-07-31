
using AutoMapper;
using HomeWork.Repositories.Interfaces;
using HomeWork.Service.Models;
using HomeWork.Shared.Model;
using MediatR;

namespace HomeWork.Core.Command;


	public record DeleteLaptopQuery ( int id) : IRequest<CommandResult<VmLaptop>> { }


	public class DeleteLaptopQueryHandler :IRequestHandler<DeleteLaptopQuery, CommandResult<VmLaptop>>

	{
		private readonly ILaptopRepository _laptopRepository;
		private IMapper _mapper;


        public DeleteLaptopQueryHandler(ILaptopRepository laptopRepository, IMapper mapper )
        {

			_laptopRepository = laptopRepository;

			_mapper= mapper;
		}

		public async Task<CommandResult<VmLaptop>> Handle(DeleteLaptopQuery request, CancellationToken cancellationToken)
		{
			 await _laptopRepository.Delete(request.id);
		return new CommandResult<VmLaptop>(new VmLaptop(), CommandResultTypeEnum.Success);
	}
	}



