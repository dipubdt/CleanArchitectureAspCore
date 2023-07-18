
using AutoMapper;
using HomeWork.Repositories.Interfaces;
using HomeWork.Service.Models;
using MediatR;

namespace HomeWork.Core.Command;

public class DeleteLaptop
{
	public record DeleteLaptopQuery ( int id):IRequest<VmLaptop>;


	public class DeleteLaptopQueryHandler :IRequestHandler<DeleteLaptopQuery, VmLaptop>

	{
		private readonly ILaptopRepository _laptopRepository;
		private IMapper _mapper;


        public DeleteLaptopQueryHandler(ILaptopRepository laptopRepository, IMapper mapper )
        {

			_laptopRepository = laptopRepository;

			_mapper= mapper;


		}

		public async Task<VmLaptop> Handle(DeleteLaptopQuery request, CancellationToken cancellationToken)
		{
			 await _laptopRepository.Delete(request.id);

			return new VmLaptop();
		}
	}



}
