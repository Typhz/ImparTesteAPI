namespace ImparTesteAPI.DTOs.Car;

public class CarCreateDto
{
	public string Name { get; set; } = null!;
	public IFormFile ImageFile { get; set; } = null!;
}
