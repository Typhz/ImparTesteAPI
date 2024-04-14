using ImparTesteAPI.DTOs.Car;
using ImparTesteAPI.Utilities;

namespace ImparTesteAPI.Services.Interfaces;

public interface ICarService
{
	Task<List<CarReadDto>> GetAllCarsAsync(PaginationAndSearchParameters paginationAndSearchParameters);
	Task<CarReadDto> GetCarByIdAsync(int id);
	Task<CarReadDto> CreateCarAsync(CarCreateDto carCreateDto);
	Task UpdateCarAsync(int id, CarUpdateDto carUpdateDto);
	Task DeleteCarAsync(int id);
}
