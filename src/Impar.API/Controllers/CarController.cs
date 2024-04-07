using Impar.Domain.Models;
using Impar.Infra.Context;
using ImparTesteAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ImparTesteAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarController : ControllerBase
{

	private readonly EntityContext _context;

	public CarController(EntityContext context)
	{
		_context = context;
	}

	// GET
	[HttpGet]
	public async Task<ActionResult> Index()
	{
		var cars = await _context.Cars.ToListAsync();

		return Ok(cars);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult> Get(int id)
	{
		var car = await _context.Cars.FindAsync(id);

		if (car == null)
		{
			return NotFound();
		}

		var carDto = new CarDto
		{
			Id = car.Id,
			Name = car.Name,
			Status = car.Status,
			Photo = new PhotoDto
			{
				Base64 = car.Photo.Base64
			}
		};

		return Ok(carDto);
	}

	[HttpPost]
	public async Task<ActionResult> Create([FromForm] CarDto carDto)
	{

		var car = new Car
		{
			Name = carDto.Name,
			Status = carDto.Status,
		};

		_context.Cars.Add(car);
		await _context.SaveChangesAsync();

		if (carDto.ImageFile != null && carDto.ImageFile.Length > 0)
		{
			using var ms = new MemoryStream();
			await carDto.ImageFile.CopyToAsync(ms);
			var fileBytes = ms.ToArray();
			string base64String = Convert.ToBase64String(fileBytes);

			var photo = new Photo
			{
				Base64 = base64String,
				CarId = car.Id
			};

			_context.Photos.Add(photo);
			await _context.SaveChangesAsync();

			car.PhotoId = photo.Id;
			_context.Cars.Update(car);
			await _context.SaveChangesAsync();
		}

		return CreatedAtAction("Get", new { id = car.Id }, car);
	}
}
