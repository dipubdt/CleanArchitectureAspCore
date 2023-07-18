using MediatR;
using System.Text.Json.Serialization;
using HomeWork.Service.Models;
using HomeWork.Repositories.Interfaces;
using JetBrains.Annotations;
using FluentValidation;

namespace HomeWork.Core.Query;

public class GetById
{
	public class GetLaptopQueryById : IRequest<VmLaptop>
	{
		[JsonConstructor]
		public GetLaptopQueryById(int id)
		{
			Id = id;
		}
		public int Id { get; set; }
	}
	public class GetStudentQueryByIdHandler : IRequestHandler<GetLaptopQueryById, Service.Models.VmLaptop>
	{
		private readonly ILaptopRepository _laptopRepository;
		private readonly IValidator<GetLaptopQueryById> _validator;

		public GetStudentQueryByIdHandler(ILaptopRepository laptopRepository, IValidator<GetLaptopQueryById> validator)
		{
			_laptopRepository = laptopRepository;
			_validator = validator;

		}
		public async Task<VmLaptop> Handle(GetLaptopQueryById request, CancellationToken cancellationToken)
		{
			var validationResult = await _validator.ValidateAsync(request, cancellationToken);
			if (!validationResult.IsValid)
				throw new ValidationException(validationResult.Errors);
			return await _laptopRepository.GetById(request.Id);
		}
	}
	public class GetLaptopByIdQueryValidator : AbstractValidator<GetLaptopQueryById>
	{
		public GetLaptopByIdQueryValidator()
		{
			RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
		}
	}
}