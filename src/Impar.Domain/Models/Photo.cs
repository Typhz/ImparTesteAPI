namespace Impar.Domain.Models;

public class Photo
{
	public int Id { get; set; }
	public string? Base64 { get; set; }

	public int CarId { get; set; }
	public Car Car { get; set; }
}
