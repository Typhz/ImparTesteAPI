namespace ImparTesteAPI.DTOs;

public class CarDto
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Status { get; set; }
	public PhotoDto Photo { get; set; }

	public IFormFile ImageFile { get; set; }

}
