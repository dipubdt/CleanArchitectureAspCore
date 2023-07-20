using HomeWork.Models;
using HomeWork.Service.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static HomeWork.Core.Command.CreateLaptop;
using static HomeWork.Core.Command.DeleteLaptop;
using static HomeWork.Core.Command.UpdateLaptop;
using static HomeWork.Core.Query.GetById;
using static HomeWork.Core.Query.GetlaptopList;

namespace HomeWork.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LaptopController : ControllerBase
{

	private readonly IMediator _mediator;

	public LaptopController(IMediator mediator)
	{
		_mediator = mediator;
	}


	[HttpGet("{id:int}")]

	public async Task<ActionResult<VmLaptop>> Get(int id)

	{

		var data= await _mediator.Send(new GetLaptopQueryById(id));

		return(data);
	}

	[HttpPost]
	public async Task<ActionResult<VmLaptop>> Post([FromBody] VmLaptop laptop)
	{
		var Data = await _mediator.Send(new CreateLaptopCommand(laptop));
		return Ok(Data);
	}

	[HttpPut("{id:int}")]
	public async Task<ActionResult<VmLaptop>> Update([FromBody] VmLaptop laptop, int id)
	{
		var Data = await _mediator.Send(new UpdateLaptopCommand(id, laptop));
		return Ok(Data);
	}

	[HttpDelete("{id:int}")]

	public async Task<ActionResult<VmLaptop>> Delete(int id)


	{
		
		return await _mediator.Send(new DeleteLaptopQuery(id));
	}

	[HttpGet]

	public async Task<ActionResult<VmLaptop>> Get()

	{

		var data = await _mediator.Send(new GetlaptopListQuery());
		return Ok(data);

	}





}
