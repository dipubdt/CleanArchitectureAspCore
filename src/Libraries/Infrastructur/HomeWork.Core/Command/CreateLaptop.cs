
using AutoMapper;
using FluentValidation;
using HomeWork.Models;
using HomeWork.Repositories.Interfaces;
using HomeWork.Service.Models;
using HomeWork.Shared.Enums;
using HomeWork.Shared.Model;
using MediatR;

namespace HomeWork.Core.Command;


	public record CreateLaptopCommand(VmLaptop laptop) : IRequest<CommandResult<VmLaptop>> { }

	public class CreateLaptopCommandHandler : IRequestHandler<CreateLaptopCommand, CommandResult<VmLaptop>>
	{
		private readonly ILaptopRepository _laptopRepository;

		private readonly IMapper _mapper;

        public CreateLaptopCommandHandler(ILaptopRepository laptopRepository, IMapper mapper )
        {
			_laptopRepository = laptopRepository;
			_mapper=mapper;
		}

		public async Task<CommandResult<VmLaptop>> Handle(CreateLaptopCommand request, CancellationToken cancellationToken)
		{
			var data = _mapper.Map<Laptop>(request.laptop);
			var returnData = await _laptopRepository.Add(data);

			if (returnData is not null and { Id: var id } && id > 0)
			{
				return new CommandResult<VmLaptop>(returnData, CommandResultTypeEnum.Created);
			}
			return new CommandResult<VmLaptop>(null, CommandResultTypeEnum.UnprocessableEntity);


		}




		public class CreatelaptopCommandValidator : AbstractValidator<CreateLaptopCommand>
		{
			public CreatelaptopCommandValidator()
			{
				RuleFor(X => X.laptop).NotNull();
				RuleFor(x => x.laptop.Id).Empty();
				RuleFor(x => x.laptop.Model).NotEmpty();
				RuleFor(x => x.laptop.ScreenSizeInches).NotEmpty();
				RuleFor(x => x.laptop.RAMSizeGB).NotEmpty();
			}
		}
	}


