using System.ComponentModel.DataAnnotations;

namespace IceCube.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public DateTime FechaRegistro { get; set; }
    }
}


