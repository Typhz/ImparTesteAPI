namespace Impar.Domain.Models;

public class Car
{
	public int Id { get; set; }

	public int PhotoId { get; set; }
	public Photo Photo { get; set; }
	public string? Name { get; set; }
}
