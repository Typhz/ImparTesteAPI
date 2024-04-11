using ImparTesteAPI.DTOs;

namespace ImparTesteAPI.Services.Interfaces;

public interface ICarService
{
	Task<List<CarReadDto>> GetAllCarsAsync(int pageNumber = 1, int pageSize = 10 , string? searchTerm = null);
	Task<CarReadDto> GetCarByIdAsync(int id);
	Task<CarReadDto> CreateCarAsync(CarCreateDto carCreateDto);
	Task UpdateCarAsync(int id, CarUpdateDto carUpdateDto);
	Task DeleteCarAsync(int id);
}
