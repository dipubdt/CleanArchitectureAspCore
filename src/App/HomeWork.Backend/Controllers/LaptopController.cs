using Microsoft.AspNetCore.Mvc;
using HomeWork.Service.Models;
using HomeWork.Core.Query;
using HomeWork.Core.Command;
using HomeWork.Shared.Model;

namespace HomeWork.Backend.Controllers;


public class LaptopController : ApiControllerBase
{

	[HttpGet("{id:int}")]
	public async Task<ActionResult<Service.Models.VmLaptop>> Get(int id)
	{
		return await HandleQueryAsync(new GetLaptopQueryById(id));

	}

	[HttpPost]
	public async Task<ActionResult<VmLaptop>> Post([FromBody] CreateLaptopCommand laptop)
	{
		return await HandleCommandAsync( laptop);
	}

	[HttpPut("{id:int}")]
	public async Task<ActionResult<VmLaptop>> Update([FromBody] VmLaptop laptop, int id)
	{
	

		return await HandleCommandAsync(new UpdateLaptopCommand(id, laptop));

	}

	[HttpDelete("{id:int}")]

	public async Task<ActionResult<VmLaptop>> Delete(int id)

	{

		return await HandleCommandAsync(new DeleteLaptopQuery(id));
	}

	//[HttpGet]

	//public async Task<ActionResult<VmLaptop>> Get()

	//{

	//	return await HandleQueryAsync(new GetlaptopListQuery());


	//}
	[HttpGet]
	public async Task<ActionResult> Get()
	{

		return await HandleQueryAsync(new GetlaptopListQuery());
		//var query = new GetlaptopListQuery();
		//return await HandleQueryAsync<QueryResult<IEnumerable<VmLaptop>>>(query);
	}






}
