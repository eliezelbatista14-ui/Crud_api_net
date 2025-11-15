using GestorAlquiler.Domain.Entities;
using GestorAlquiler.Domain.Interfaces;


namespace GestorAlquiler.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _repo;

        public ClienteController(IClienteRepository repo)
        {
            _repo = repo;
        }


        // GET api/clientes
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var clientes = await _repo.GetAllAsync();
            return Ok(clientes);
        }

        // GET api/clientes/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var cliente = await _repo.GetByIdAsync(id);

            if (cliente == null)
                return NotFound(new { message = "Cliente no encontrado." });

            return Ok(cliente);
        }

        // POST api/clientes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Evitar IDs en POST
            cliente.ClienteId = 0;

            var newCliente = await _repo.AddAsync(cliente);

            return CreatedAtAction(nameof(Get),
                new { id = newCliente.ClienteId },
                newCliente);
        }

        // PUT api/clientes/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != cliente.ClienteId)
                return BadRequest(new { message = "El ID de la URL no coincide con el ID del cliente." });

            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
                return NotFound(new { message = "Cliente no encontrado." });

            var updatedCliente = await _repo.UpdateAsync(cliente);
            return Ok(updatedCliente);
        }

        // DELETE api/clientes/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repo.DeleteAsync(id);

            if (!deleted)
                return NotFound(new { message = "Cliente no encontrado." });

            return NoContent();
        }
    }
}
