using ImparTesteAPI.DTOs;
using ImparTesteAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ImparTesteAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarController : ControllerBase
{

	private readonly ICarService _carService;
	public CarController(ICarService carService)
	{
		_carService = carService;
	}

	[HttpGet]
	public async Task<ActionResult> Index(int pageNumber = 1, int pageSize = 10, string? searchTerm = null)
	{
		var carDtos = await _carService.GetAllCarsAsync(pageNumber, pageSize, searchTerm);
		return Ok(carDtos);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult> Get(int id)
	{
		var carDto = await _carService.GetCarByIdAsync(id);
		return Ok(carDto);
	}

	[HttpPost]
	public async Task<ActionResult> Create([FromForm] CarCreateDto carCreateDto)
	{
		var carDto = await _carService.CreateCarAsync(carCreateDto);
		return Ok(carDto);
	}

	[HttpPut("{id}")]
	public async Task<ActionResult> Update(int id, [FromForm] CarUpdateDto carUpdateDto)
	{
		await _carService.UpdateCarAsync(id, carUpdateDto);
		return Ok();
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult> Delete(int id)
	{
		await _carService.DeleteCarAsync(id);
		return Ok();
	}
}
