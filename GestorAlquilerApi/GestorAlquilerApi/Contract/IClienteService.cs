using GestorAlquiler.API.Dtos;

namespace GestorAlquiler.API.Contract
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDto>> GetAllAsync();
        Task<ClienteDto?> GetByIdAsync(int id);
        Task<ClienteDto> CreateAsync(ClienteCreateDto dto);
        Task<ClienteDto?> UpdateAsync(ClienteUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
