

using AutoMapper;
using HomeWork.Repositories.Interfaces;
using HomeWork.Service.Models;
using HomeWork.Shared.Model;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HomeWork.Core.Query;


public record GetlaptopListQuery() : IRequest<QueryResult<IEnumerable<VmLaptop>>> { }


	public class GetlaptopListQueryHandler : IRequestHandler<GetlaptopListQuery, QueryResult<IEnumerable<VmLaptop>>>
{

		private readonly ILaptopRepository _laptopRepository;
		private readonly IMapper _mapper;

        public GetlaptopListQueryHandler(ILaptopRepository laptopRepository, IMapper mapper)
        {
			_laptopRepository = laptopRepository;
			_mapper = mapper;
				
        }
		public async Task<QueryResult<IEnumerable<VmLaptop>>> Handle(GetlaptopListQuery request, CancellationToken cancellationToken)
		{
			var Data = await _laptopRepository.GetList();
			
		return new QueryResult<IEnumerable<VmLaptop>>(Data, QueryResultTypeEnum.Success);

	}
	}


