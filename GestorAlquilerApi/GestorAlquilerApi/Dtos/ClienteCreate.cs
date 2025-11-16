using System.ComponentModel.DataAnnotations;

namespace GestorAlquiler.API.Dtos
{
    public class ClienteCreateDto
    {
        [Required, StringLength(100)]
        public string Nombre { get; set; } = null!;

        [Required, StringLength(100)]
        public string Apellido { get; set; } = null!;

        [Required, RegularExpression(@"^\d{7,15}$", ErrorMessage = "La cédula debe ser sólo dígitos (7-15).")]
        
        public string Telefono { get; set; } = null!;

        [Required, EmailAddress]
        public string Email { get; set; } = null!;
    }
}
