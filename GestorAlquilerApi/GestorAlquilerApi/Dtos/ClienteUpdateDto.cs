using System.ComponentModel.DataAnnotations;

namespace GestorAlquiler.API.Dtos
{
    public class ClienteUpdateDto
    {
        [Required]
        public int ClienteId { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; } = null!;

        [Required, StringLength(100)]
        public string Apellido { get; set; } = null!;

        [Required, Phone]
        public string Telefono { get; set; } = null!;

        [Required, EmailAddress]
        public string Email { get; set; } = null!;
    }
}
