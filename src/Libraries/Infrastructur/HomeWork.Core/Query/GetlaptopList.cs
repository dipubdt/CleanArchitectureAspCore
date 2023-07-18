

using AutoMapper;
using HomeWork.Repositories.Interfaces;
using HomeWork.Service.Models;
using MediatR;

namespace HomeWork.Core.Query;

public class GetlaptopList
{
	public record GetlaptopListQuery() : IRequest<IEnumerable<VmLaptop>>;



	public class GetlaptopListQueryHandler : IRequestHandler<GetlaptopListQuery, IEnumerable<VmLaptop>>
	{

		private readonly ILaptopRepository _laptopRepository;
		private readonly IMapper _mapper;

        public GetlaptopListQueryHandler(ILaptopRepository laptopRepository, IMapper mapper)
        {
			_laptopRepository = laptopRepository;
			_mapper = mapper;
				
        }

		public async Task<IEnumerable<VmLaptop>> Handle(GetlaptopListQuery request, CancellationToken cancellationToken)
		{

			var Data = await _laptopRepository.GetList();
			return Data;

		}
	}

}
