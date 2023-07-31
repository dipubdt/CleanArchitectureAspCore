using MediatR;
using System.Text.Json.Serialization;
using HomeWork.Service.Models;
using HomeWork.Repositories.Interfaces;
using FluentValidation;
using HomeWork.Shared.Model;

namespace HomeWork.Core.Query;


public class GetLaptopQueryById : IRequest<QueryResult<VmLaptop>>
{
	[JsonConstructor]
	public GetLaptopQueryById(int id)
	{
		Id = id;
	}
	public int Id { get; set; }
}
public class GetStudentQueryByIdHandler : IRequestHandler<GetLaptopQueryById, QueryResult<VmLaptop>>
{
	private readonly ILaptopRepository _laptopRepository;
	private readonly IValidator<GetLaptopQueryById> _validator;

	public GetStudentQueryByIdHandler(ILaptopRepository laptopRepository, IValidator<GetLaptopQueryById> validator)
	{
		_laptopRepository = laptopRepository;
		_validator = validator;

	}
	public async Task<QueryResult<VmLaptop>> Handle(GetLaptopQueryById request, CancellationToken cancellationToken)
	{
		var validationResult = await _validator.ValidateAsync(request, cancellationToken);
		if (!validationResult.IsValid)
			throw new ValidationException(validationResult.Errors);
		
		var data =  await _laptopRepository.GetById(request.Id);

		if (data is null)
		{
			return new QueryResult<VmLaptop>(null, QueryResultTypeEnum.NotFound);
		}
		return new QueryResult<VmLaptop>(data, QueryResultTypeEnum.Success);
	}
}
public class GetLaptopByIdQueryValidator : AbstractValidator<GetLaptopQueryById>
{
	public GetLaptopByIdQueryValidator()
	{
		RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
	}
}