using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Capa_Presentacion.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Cédula")]
        public string Cedula { get; set; }

        [Required]
        [StringLength(40)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo Nombre solo acepta letras")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(20)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo Primer Apellido solo acepta letras")]
        [Display(Name = "Primer Apellido")]
        public string Apellido1 { get; set; }

        [Required]
        [StringLength(20)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo Segundo Apellido solo acepta letras")]
        [Display(Name = "Segundo Apellido")]
        public string Apellido2 { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "Contraseña")]
        public string Clave { get; set; }

        [Required]
        [Display(Name = "Rol")]
        public int IdRol { get; set; }
    }
}