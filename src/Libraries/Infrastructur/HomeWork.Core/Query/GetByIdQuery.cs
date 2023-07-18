using MediatR;
using System.Text.Json.Serialization;
using HomeWork.Service.Models;
using HomeWork.Repositories.Interfaces;
using JetBrains.Annotations;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace HomeWork.Core.Query;

public class GetById
{
	public class GetByIdQuery : IRequest<VmLaptop>
	{
		[JsonConstructor]
		public GetByIdQuery(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
	}

	[UsedImplicitly]
	public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, VmLaptop>
	{
		private readonly ILaptopRepository _laptopRepository;
		//private readonly IValidator _validator;


		public GetByIdQueryHandler(ILaptopRepository laptopRepository)
		{
			_laptopRepository = laptopRepository;
			//_validator = validator;


		}

		public async Task<VmLaptop> Handle(GetByIdQuery request, CancellationToken cancellationToken)
		{
			//var validationResult = await _validator.ValidateAsync(request, cancellationToken);
			//if (!validationResult.IsValid)
			//{
			//	throw new ValidationException(validationResult.Errors);
			//}

			var laptop = await _laptopRepository.GetById(request.Id);
			return laptop;
		}
	}


	//public class GetByIdQueryValidator : AbstractValidator<GetByIdQuery>
	//{
	//	public GetByIdQueryValidator()
	//	{
	//		RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
	//	}
	//}


}
