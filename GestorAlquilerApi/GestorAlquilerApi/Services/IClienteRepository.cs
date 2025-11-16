using GestorAlquiler.API.Contract;
using GestorAlquiler.API.Dtos;
using GestorAlquiler.API.Models;
using GestorAlquiler.API.Repositories;

namespace GestorAlquiler.API.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repo;

        public ClienteService(IClienteRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ClienteDto>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Select(MapToDto);
        }

        public async Task<ClienteDto?> GetByIdAsync(int id)
        {
            var c = await _repo.GetByIdAsync(id);
            return c == null ? null : MapToDto(c);
        }

        public async Task<ClienteDto> CreateAsync(ClienteCreateDto dto)
        {
            // Validaciones adicionales de negocio (si aplica)
            var entity = new Cliente
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Cedula = dto.Cedula,
                Telefono = dto.Telefono,
                Email = dto.Email
            };

            var created = await _repo.AddAsync(entity);
            return MapToDto(created);
        }

        public async Task<ClienteDto?> UpdateAsync(ClienteUpdateDto dto)
        {
            var existing = await _repo.GetByIdAsync(dto.ClienteId);
            if (existing == null) return null;

            existing.Nombre = dto.Nombre;
            existing.Apellido = dto.Apellido;
            existing.Cedula = dto.Cedula;
            existing.Telefono = dto.Telefono;
            existing.Email = dto.Email;

            var updated = await _repo.UpdateAsync(existing);
            return MapToDto(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        // Mapping manual — simple y directo
        private static ClienteDto MapToDto(Cliente c) => new ClienteDto
        {
            ClienteId = c.ClienteId,
            Nombre = c.Nombre,
            Apellido = c.Apellido,
            Cedula = c.Cedula,
            Telefono = c.Telefono,
            Email = c.Email
        };
    }
}
